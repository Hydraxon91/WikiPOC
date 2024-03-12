using Microsoft.EntityFrameworkCore;
using wiki_backend.DatabaseServices;
using wiki_backend.DatabaseServices.Repositories;
using wiki_backend.Models;

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
        _wikiDbContext = new WikiDbContext(options, configuration: null); 
        _wikiDbContext.Database.EnsureCreated(); // Ensure the in-memory database is created
        _wikiDbContext.Database.EnsureDeleted();
        _wikiDbContext.SaveChanges();
        
        _styleRepository = new StyleRepository(_wikiDbContext);
    }
    
    [TearDown]
    public void TearDown()
    {
        // Dispose the context to release the in-memory database
        _wikiDbContext.Database.EnsureDeleted();
        _wikiDbContext.Dispose();
    }
    
    [Test]
    public async Task GetStylesAsync_ShouldReturnStyles()
    {
        //Arrange
        _wikiDbContext.Styles.Add(new StyleModel
        {
            Logo = "default_logo.png",
            WikiName = "Test Wiki",
            BodyColor = "#ffffff",
            ArticleRightColor = "#eeeeee",
            ArticleRightInnerColor = "#cccccc",
            ArticleColor = "#dddddd",
            FooterListLinkTextColor = "#bbbbbb",
            FooterListTextColor = "#aaaaaa"
        });
        await _wikiDbContext.SaveChangesAsync();
        // Act
        var result = await _styleRepository.GetStylesAsync();
        // Assert
        Assert.IsNotNull(result);
        // Add more assertions as needed based on the expected data model
    }
    
    [Test]
    public async Task UpdateStylesAsync_ShouldUpdateExistingStyles()
    {
        // Arrange
        // Arrange
        _wikiDbContext.Styles.Add(new StyleModel
        {
            Logo = "default_logo.png",
            WikiName = "Test Wiki",
            BodyColor = "#ffffff",
            ArticleRightColor = "#eeeeee",
            ArticleRightInnerColor = "#cccccc",
            ArticleColor = "#dddddd",
            FooterListLinkTextColor = "#bbbbbb",
            FooterListTextColor = "#aaaaaa"
        });
        await _wikiDbContext.SaveChangesAsync();
        
        var updatedStyles = new StyleModel
        {
            Id = 1,
            Logo = "new_logo.png",
            WikiName = "New Wiki",
            BodyColor = "#000000",
            ArticleRightColor = "#111111",
            ArticleRightInnerColor = "#222222",
            ArticleColor = "#333333",
            FooterListLinkTextColor = "#444444",
            FooterListTextColor = "#555555"
        };

        // Act
        await _styleRepository.UpdateStylesAsync(updatedStyles);
        await _wikiDbContext.SaveChangesAsync();

        // Assert
        var result = await _wikiDbContext.Styles.SingleOrDefaultAsync();
        Assert.IsNotNull(result);
        Assert.AreEqual(updatedStyles.Logo, result.Logo);
        Assert.AreEqual(updatedStyles.WikiName, result.WikiName);
        Assert.AreEqual(updatedStyles.BodyColor, result.BodyColor);
        Assert.AreEqual(updatedStyles.ArticleRightColor, result.ArticleRightColor);
        Assert.AreEqual(updatedStyles.ArticleRightInnerColor, result.ArticleRightInnerColor);
        Assert.AreEqual(updatedStyles.ArticleColor, result.ArticleColor);
        Assert.AreEqual(updatedStyles.FooterListLinkTextColor, result.FooterListLinkTextColor);
        Assert.AreEqual(updatedStyles.FooterListTextColor, result.FooterListTextColor);
    }
    
    [Test]
    public async Task UpdateStylesAsync_NoExistingStyle()
    {
        
        var updatedStyles = new StyleModel
        {
            Id = 1,
            Logo = "new_logo.png",
            WikiName = "New Wiki",
            BodyColor = "#000000",
            ArticleRightColor = "#111111",
            ArticleRightInnerColor = "#222222",
            ArticleColor = "#333333",
            FooterListLinkTextColor = "#444444",
            FooterListTextColor = "#555555"
        };

        // Act
        await _styleRepository.UpdateStylesAsync(updatedStyles);
        await _wikiDbContext.SaveChangesAsync();

        // Assert
        var result = await _wikiDbContext.Styles.SingleOrDefaultAsync();
        Assert.IsNotNull(result);
        Assert.AreEqual(updatedStyles.Logo, result.Logo);
        Assert.AreEqual(updatedStyles.WikiName, result.WikiName);
        Assert.AreEqual(updatedStyles.BodyColor, result.BodyColor);
        Assert.AreEqual(updatedStyles.ArticleRightColor, result.ArticleRightColor);
        Assert.AreEqual(updatedStyles.ArticleRightInnerColor, result.ArticleRightInnerColor);
        Assert.AreEqual(updatedStyles.ArticleColor, result.ArticleColor);
        Assert.AreEqual(updatedStyles.FooterListLinkTextColor, result.FooterListLinkTextColor);
        Assert.AreEqual(updatedStyles.FooterListTextColor, result.FooterListTextColor);
    }
}