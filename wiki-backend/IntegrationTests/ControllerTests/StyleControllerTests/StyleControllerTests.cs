using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using wiki_backend.Contracts;
using wiki_backend.Controllers;
using wiki_backend.DatabaseServices.Repositories;
using wiki_backend.Models;

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
        _styleRepository = new StyleRepository(DbContext);
        _controller = new StyleController(_styleRepository);
        ResetDatabase();
        await EnsureUserRoleExistsAsync();
    }

    [Test]
    public async Task GetStyles_ShouldReturnStyles()
    {
        // Arrange
        var style = await DbContext.Styles.FirstOrDefaultAsync();
        // Act
        var result = await _controller.GetStyles();

        // Assert
        Assert.IsInstanceOf<OkObjectResult>(result.Result);
        var okResult = result.Result as OkObjectResult;
        var returnedStyle = okResult.Value;
        
        Assert.IsNotNull(returnedStyle);
        Assert.AreEqual(style, returnedStyle);
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
        Assert.IsInstanceOf<OkObjectResult>(result);
        var updatedStyleInDb = await DbContext.Styles.FindAsync(style.Id);
        
        Assert.AreEqual("NewStyle", updatedStyleInDb.WikiName);
        Assert.AreEqual("#000000", updatedStyleInDb.BodyColor);
    }
}