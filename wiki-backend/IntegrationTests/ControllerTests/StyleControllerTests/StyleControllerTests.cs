using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using wiki_backend.Contracts;
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
        // Seed a default style (was previously provided by HasData in OnModelCreating)
        if (!await DbContext.Styles.AnyAsync())
        {
            DbContext.Styles.Add(new StyleModel
            {
                Id = 1,
                Logo = "logo/logo_pfp.png",
                WikiName = "Your Wiki",
                BodyColor = "#507ced",
                ArticleRightColor = "#3c5fb8",
                ArticleRightInnerColor = "#2b4ea6",
                ArticleColor = "#526cad",
                FooterListLinkTextColor = "#1d305e",
                FooterListTextColor = "#233a71",
                FontFamily = "Arial, sans-serif",
            });
            await DbContext.SaveChangesAsync();
        }
    }

    [Test]
    public async Task GetStyles_ShouldReturnStyles()
    {
        // Arrange
        var style = await DbContext.Styles.FirstOrDefaultAsync();
        // Act
        var result = await _controller.GetStyles();

        // Assert
        Assert.That(result.Result, Is.InstanceOf<OkObjectResult>());
        var okResult = result.Result as OkObjectResult;
        var returnedStyle = okResult!.Value;
        
        Assert.That(returnedStyle, Is.Not.Null);
        Assert.That(returnedStyle, Is.EqualTo(style));
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
            WikiName = "NewStyle",
            Logo = "newlogo.png",
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
        
        Assert.That(updatedStyleInDb!.WikiName, Is.EqualTo("NewStyle"));
        Assert.That(updatedStyleInDb!.BodyColor, Is.EqualTo("#000000"));
    }
}