using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using wiki_backend.Controllers;
using wiki_backend.DatabaseServices.Repositories;
using wiki_backend.Models;
using wiki_backend.Services.Settings;

namespace IntegrationTests.ControllerTests.StyleControllerTests;

[TestFixture]
[NonParallelizable]
public class StyleControllerTests : IntegrationTestBase
{
    private StyleController _controller;
    private IStyleRepository _styleRepository;

    [SetUp]
    public async Task SetUp()
    {
        var storageSettings = Options.Create(new StorageSettings { PicturesPath = PicturesPathContainer });
        _styleRepository = new StyleRepository(DbContext, storageSettings);
        _controller = new StyleController(_styleRepository);
        ResetDatabase();
        await EnsureUserRoleExistsAsync();
        // Seed a default active style
        if (!await DbContext.Styles.AnyAsync())
        {
            DbContext.Styles.Add(new StyleModel
            {
                IsActive = true,
                IsSystemPreset = true,
                InterfaceEra = "wikipedia",
                BodyColor = "#507ced",
                ArticleRightColor = "#3c5fb8",
                ArticleRightInnerColor = "#2b4ea6",
                ArticleColor = "#526cad",
                FooterListLinkTextColor = "#1d305e",
                FooterListTextColor = "#233a71",
                FontFamily = "Arial, sans-serif",
                GlassBgOpacity = 1.0,
                GlassBlurRadius = 0,
                GlassBorderReflection = 0,
                BgMeshGradient = "none",
                BorderRadius = "0px",
                BorderStyle = "1px solid #a2a9b1",
            });
            await DbContext.SaveChangesAsync();
        }
    }

    [Test]
    public async Task GetActiveStyles_ShouldReturnActiveStyle()
    {
        // Arrange
        var style = await DbContext.Styles.FirstOrDefaultAsync();
        // Act
        var result = await _controller.GetActiveStyles();

        // Assert
        Assert.That(result.Result, Is.InstanceOf<OkObjectResult>());
        var okResult = result.Result as OkObjectResult;
        var returnedStyle = okResult!.Value;
        
        Assert.That(returnedStyle, Is.Not.Null);
        Assert.That(returnedStyle, Is.EqualTo(style));
    }

    [Test]
    public async Task GetSystemPresets_ShouldReturnPresets()
    {
        // Arrange — seed 4 system presets
        DbContext.Styles.RemoveRange(await DbContext.Styles.ToListAsync());
        DbContext.Styles.AddRange(
            new StyleModel { IsSystemPreset = true, InterfaceEra = "wikipedia", IsActive = true, ThemeName = "Wikipedia Classic" },
            new StyleModel { IsSystemPreset = true, InterfaceEra = "glass", IsActive = false, ThemeName = "Liquid Glass" },
            new StyleModel { IsSystemPreset = true, InterfaceEra = "modern", IsActive = false, ThemeName = "Modern Sleek" },
            new StyleModel { IsSystemPreset = true, InterfaceEra = "frutiger", IsActive = false, ThemeName = "Frutiger Aero" }
        );
        await DbContext.SaveChangesAsync();

        // Act
        var result = await _controller.GetSystemPresets();

        // Assert
        Assert.That(result.Result, Is.InstanceOf<OkObjectResult>());
        var okResult = result.Result as OkObjectResult;
        var presets = okResult!.Value as List<StyleModel>;
        Assert.That(presets, Has.Count.EqualTo(4));
    }

    [Test]
    public async Task UpdateStyles_WithValidData_ShouldUpdateStyles()
    {
        // Arrange
        var email = "test333@example.com";
        var username = "32324124";
        var password = "@AdminPassword123";
        await CreateAdminUserAsync(email, username, password);
        var token = await GetValidUserToken(email, username, password);

        _controller.ControllerContext.HttpContext = new DefaultHttpContext
        {
            Request = { Headers = { ["Authorization"] = $"Bearer {token}" } }
        };

        var style = await DbContext.Styles.FirstOrDefaultAsync();

        // Prepare the update model with the same Id
        var updatedStyle = new StyleModel
        {
            BodyColor = "#000000"
        };

        var styleUpdateForm = new StyleUpdateForm
        {
            StyleModel = updatedStyle,
            LogoPictureFile = null
        };

        // Act
        var result = await _controller.UpdateStyles(styleUpdateForm);

        // Assert
        Assert.That(result, Is.InstanceOf<OkObjectResult>());
        var updatedStyleInDb = await DbContext.Styles.FindAsync(style!.Id);
        
        Assert.That(updatedStyleInDb!.BodyColor, Is.EqualTo("#000000"));
    }

    [Test]
    public async Task ActivateTheme_ShouldSwapActiveTheme()
    {
        // Arrange
        var email = "admin_activate@example.com";
        var username = "activate_admin";
        var password = "@AdminPassword123";
        await CreateAdminUserAsync(email, username, password);
        var token = await GetValidUserToken(email, username, password);

        _controller.ControllerContext.HttpContext = new DefaultHttpContext
        {
            Request = { Headers = { ["Authorization"] = $"Bearer {token}" } }
        };

        // Seed two themes
        DbContext.Styles.RemoveRange(await DbContext.Styles.ToListAsync());
        DbContext.Styles.AddRange(
            new StyleModel { InterfaceEra = "wikipedia", IsActive = true, IsSystemPreset = true, ThemeName = "Wikipedia Classic" },
            new StyleModel { InterfaceEra = "glass", IsActive = false, IsSystemPreset = true, ThemeName = "Liquid Glass" }
        );
        await DbContext.SaveChangesAsync();
        var glassTheme = await DbContext.Styles.FirstAsync(s => s.InterfaceEra == "glass");

        // Act
        var result = await _controller.ActivateTheme(glassTheme.Id);

        // Assert
        Assert.That(result, Is.InstanceOf<OkObjectResult>());
        var wikipediaTheme = await DbContext.Styles.FirstAsync(s => s.InterfaceEra == "wikipedia");
        var glassThemeAfter = await DbContext.Styles.FirstAsync(s => s.InterfaceEra == "glass");
        Assert.That(wikipediaTheme.IsActive, Is.False);
        Assert.That(glassThemeAfter.IsActive, Is.True);
    }
}
