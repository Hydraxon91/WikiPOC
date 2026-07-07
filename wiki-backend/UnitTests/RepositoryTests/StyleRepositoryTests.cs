using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using wiki_backend.DatabaseServices;
using wiki_backend.DatabaseServices.Repositories;
using wiki_backend.Models;
using wiki_backend.Services.Settings;

namespace UnitTests.RepositoryTests;
[TestFixture]
public class StyleRepositoryTests
{
    private StyleRepository _styleRepository;
    private WikiDbContext _wikiDbContext;
    
    [SetUp]
    public void Setup()
    {
        // Generate a unique database name based on the test name
        var databaseName = $"TestDatabase_{TestContext.CurrentContext.Test.Name}";
        // Use an in-memory database for testing
        var options = new DbContextOptionsBuilder<WikiDbContext>()
            .UseInMemoryDatabase(databaseName: databaseName)
            .Options;

        // Use AddDbContext to configure the WikiDbContext
        _wikiDbContext = new WikiDbContext(options, configuration: null!); 
        _wikiDbContext.Database.EnsureCreated(); // Ensure the in-memory database is created
        _wikiDbContext.Database.EnsureDeleted();
        _wikiDbContext.SaveChanges();
        
        var storageSettings = Options.Create(new StorageSettings { PicturesPath = "test_path" });
        _styleRepository = new StyleRepository(_wikiDbContext, storageSettings);
    }
    
    [TearDown]
    public void TearDown()
    {
        // Dispose the context to release the in-memory database
        _wikiDbContext.Database.EnsureDeleted();
        _wikiDbContext.Dispose();
    }
    
    [Test]
    public async Task GetActiveStylesAsync_ShouldReturnActiveStyles()
    {
        //Arrange
        _wikiDbContext.Styles.Add(new StyleModel
        {
            IsActive = true,
            BodyColor = "#ffffff",
            ArticleRightColor = "#eeeeee",
            ArticleRightInnerColor = "#cccccc",
            ArticleColor = "#dddddd",
            FooterListLinkTextColor = "#bbbbbb",
            FooterListTextColor = "#aaaaaa",
            InterfaceEra = "wikipedia",
            GlassBgOpacity = 1.0,
            GlassBlurRadius = 0,
            GlassBorderReflection = 0,
            BgMeshGradient = "none",
            BorderRadius = "0px",
            BorderStyle = "1px solid #a2a9b1",
        });
        await _wikiDbContext.SaveChangesAsync();
        // Act
        var result = await _styleRepository.GetActiveStylesAsync();
        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.IsActive, Is.True);
    }

    [Test]
    public async Task GetActiveStylesAsync_NoActiveStyle_ShouldThrow()
    {
        // Arrange — no styles added
        // Act & Assert
        var ex = Assert.ThrowsAsync<InvalidOperationException>(() =>
            _styleRepository.GetActiveStylesAsync());
        Assert.That(ex.Message, Is.EqualTo("No active theme configured."));
    }

    [Test]
    public async Task GetSystemPresetsAsync_ShouldReturnPresets()
    {
        // Arrange
        _wikiDbContext.Styles.AddRange(
            new StyleModel { IsSystemPreset = true, InterfaceEra = "wikipedia", IsActive = false },
            new StyleModel { IsSystemPreset = true, InterfaceEra = "glass", IsActive = false },
            new StyleModel { IsSystemPreset = false, InterfaceEra = "wikipedia", IsActive = true, UserId = "user1" }
        );
        await _wikiDbContext.SaveChangesAsync();
        // Act
        var result = await _styleRepository.GetSystemPresetsAsync();
        // Assert
        Assert.That(result, Has.Count.EqualTo(2));
    }

    [Test]
    public async Task GetUserThemesAsync_ShouldReturnUserThemes()
    {
        // Arrange
        _wikiDbContext.Styles.AddRange(
            new StyleModel { UserId = "user1", InterfaceEra = "wikipedia", IsActive = false, IsSystemPreset = false },
            new StyleModel { UserId = "user2", InterfaceEra = "glass", IsActive = false, IsSystemPreset = false },
            new StyleModel { UserId = "user1", InterfaceEra = "modern", IsActive = false, IsSystemPreset = false }
        );
        await _wikiDbContext.SaveChangesAsync();
        // Act
        var result = await _styleRepository.GetUserThemesAsync("user1");
        // Assert
        Assert.That(result, Has.Count.EqualTo(2));
    }

    [Test]
    public async Task CreateUserThemeAsync_ShouldCreateUserTheme()
    {
        // Arrange
        var theme = new StyleModel
        {
            ThemeName = "My Theme",
            InterfaceEra = "glass",
            BodyColor = "#ff0000",
            ArticleColor = "#ffffff",
        };
        // Act
        var result = await _styleRepository.CreateUserThemeAsync(theme);
        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.IsSystemPreset, Is.False);
        Assert.That(result.IsActive, Is.False);
        Assert.That(result.ThemeName, Is.EqualTo("My Theme"));
    }

    [Test]
    public async Task UpdateStylesAsync_ShouldUpdateExistingStyles()
    {
        // Arrange
        _wikiDbContext.Styles.Add(new StyleModel
        {
            IsActive = true,
            BodyColor = "#ffffff",
            ArticleRightColor = "#eeeeee",
            ArticleRightInnerColor = "#cccccc",
            ArticleColor = "#dddddd",
            FooterListLinkTextColor = "#bbbbbb",
            FooterListTextColor = "#aaaaaa",
            InterfaceEra = "wikipedia",
            GlassBgOpacity = 1.0,
            GlassBlurRadius = 0,
            GlassBorderReflection = 0,
            BgMeshGradient = "none",
            BorderRadius = "0px",
            BorderStyle = "1px solid #a2a9b1",
        });
        await _wikiDbContext.SaveChangesAsync();
        
        var updatedStyles = new StyleModel
        {
            Id = 1,
            BodyColor = "#000000",
            ArticleRightColor = "#111111",
            ArticleRightInnerColor = "#222222",
            ArticleColor = "#333333",
            FooterListLinkTextColor = "#444444",
            FooterListTextColor = "#555555",
            InterfaceEra = "glass",
            GlassBgOpacity = 0.5,
            GlassBlurRadius = 8,
            GlassBorderReflection = 0.1,
            BgMeshGradient = "radial-gradient(circle, #000, #fff)",
            BorderRadius = "8px",
            BorderStyle = "1px solid rgba(255,255,255,0.2)",
        };

        // Act
        await _styleRepository.UpdateStylesAsync(updatedStyles, null);
        await _wikiDbContext.SaveChangesAsync();

        // Assert
        var result = await _wikiDbContext.Styles.SingleOrDefaultAsync();
        Assert.That(result, Is.Not.Null);
        Assert.That(result.BodyColor, Is.EqualTo(updatedStyles.BodyColor));
        Assert.That(result.ArticleRightColor, Is.EqualTo(updatedStyles.ArticleRightColor));
        Assert.That(result.ArticleRightInnerColor, Is.EqualTo(updatedStyles.ArticleRightInnerColor));
        Assert.That(result.ArticleColor, Is.EqualTo(updatedStyles.ArticleColor));
        Assert.That(result.FooterListLinkTextColor, Is.EqualTo(updatedStyles.FooterListLinkTextColor));
        Assert.That(result.FooterListTextColor, Is.EqualTo(updatedStyles.FooterListTextColor));
        Assert.That(result.InterfaceEra, Is.EqualTo(updatedStyles.InterfaceEra));
        Assert.That(result.GlassBgOpacity, Is.EqualTo(updatedStyles.GlassBgOpacity));
        Assert.That(result.GlassBlurRadius, Is.EqualTo(updatedStyles.GlassBlurRadius));
        Assert.That(result.GlassBorderReflection, Is.EqualTo(updatedStyles.GlassBorderReflection));
        Assert.That(result.BgMeshGradient, Is.EqualTo(updatedStyles.BgMeshGradient));
        Assert.That(result.BorderRadius, Is.EqualTo(updatedStyles.BorderRadius));
        Assert.That(result.BorderStyle, Is.EqualTo(updatedStyles.BorderStyle));
    }
    
    [Test]
    public async Task UpdateStylesAsync_NoExistingStyle()
    {
        
        var updatedStyles = new StyleModel
        {
            Id = 1,
            BodyColor = "#000000",
            ArticleRightColor = "#111111",
            ArticleRightInnerColor = "#222222",
            ArticleColor = "#333333",
            FooterListLinkTextColor = "#444444",
            FooterListTextColor = "#555555",
            InterfaceEra = "wikipedia",
        };

        // Act
        await _styleRepository.UpdateStylesAsync(updatedStyles, null);
        await _wikiDbContext.SaveChangesAsync();

        // Assert
        var result = await _wikiDbContext.Styles.SingleOrDefaultAsync();
        Assert.That(result, Is.Not.Null);
        Assert.That(result.BodyColor, Is.EqualTo(updatedStyles.BodyColor));
        Assert.That(result.ArticleRightColor, Is.EqualTo(updatedStyles.ArticleRightColor));
        Assert.That(result.ArticleRightInnerColor, Is.EqualTo(updatedStyles.ArticleRightInnerColor));
        Assert.That(result.ArticleColor, Is.EqualTo(updatedStyles.ArticleColor));
        Assert.That(result.FooterListLinkTextColor, Is.EqualTo(updatedStyles.FooterListLinkTextColor));
        Assert.That(result.FooterListTextColor, Is.EqualTo(updatedStyles.FooterListTextColor));
    }

    [Test]
    public async Task ActivateThemeAsync_ShouldSwapIsActive()
    {
        // Arrange
        _wikiDbContext.Styles.AddRange(
            new StyleModel { InterfaceEra = "wikipedia", IsActive = true, IsSystemPreset = true },
            new StyleModel { InterfaceEra = "glass", IsActive = false, IsSystemPreset = true }
        );
        await _wikiDbContext.SaveChangesAsync();
        var glassTheme = await _wikiDbContext.Styles.FirstAsync(s => s.InterfaceEra == "glass");

        // Act
        await _styleRepository.ActivateThemeAsync(glassTheme.Id);

        // Assert
        var wikipediaTheme = await _wikiDbContext.Styles.FirstAsync(s => s.InterfaceEra == "wikipedia");
        var glassThemeAfter = await _wikiDbContext.Styles.FirstAsync(s => s.InterfaceEra == "glass");
        Assert.That(wikipediaTheme.IsActive, Is.False);
        Assert.That(glassThemeAfter.IsActive, Is.True);
    }
}
