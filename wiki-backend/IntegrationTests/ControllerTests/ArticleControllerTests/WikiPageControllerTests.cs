using DotNetEnv;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using wiki_backend.Controllers;
using wiki_backend.DatabaseServices.Repositories;
using wiki_backend.Models;
using wiki_backend.Services.Settings;
using wiki_backend.Services.Storage;

namespace IntegrationTests.ControllerTests.ArticleControllerTests;

[NonParallelizable]
[TestFixture]
public class WikiPageControllerTests : IntegrationTestBase
{
    private IWikiPageRepository _wikiPageRepository;
    private WikiPagesController _controller;
    private UserManager<ApplicationUser> _userManager;
    private string? _adminToken;
    private string? _userToken;
    private string? _userName;
    private string? _email;
    private Guid _catId;
    
    [SetUp]
    public async Task SetUp()
    {
        // Check JWT configuration
        Env.TraversePath().Load();
        var signingKey = Environment.GetEnvironmentVariable("JWT_ISSUER_SIGNING_KEY");
        
        var categoryRepository = new CategoryRepository(DbContext);
        var storageSettings = Options.Create(new StorageSettings { PicturesPath = PicturesPathContainer });
        var imageStorage = new ImageStorageService(storageSettings);
        _wikiPageRepository = new WikiPageRepository(DbContext, categoryRepository, imageStorage);
        _userManager = ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        _controller = new WikiPagesController(_wikiPageRepository, categoryRepository);
        ResetDatabase();
        await EnsureUserRoleExistsAsync();
    
        // Create an admin user
        _userName = $"{GetRandomizedString("adminuser")}";
        _email = $"{GetRandomizedString("admin")}@example.com";
        await CreateAdminUserAsync(_email, _userName, "@Password123");
        _adminToken = await GetValidUserToken(_email, _userName, "@Password123");

        // Create a regular user
        _userName = $"{GetRandomizedString("testuser")}";
        _email = $"{GetRandomizedString("test")}@example.com";
        await CreateTestUserAsync(_email, _userName, "@Password123");
        _userToken = await GetValidUserToken(_email, _userName, "@Password123");

        // Add category to the database
        _catId = Guid.NewGuid();
        var category = new Category { Id = _catId, CategoryName = "TestCat"};
        await DbContext.Categories.AddAsync(category);
        await DbContext.SaveChangesAsync();
    }
    
    [Test]
    public async Task GetWikiPages_ShouldReturnAllPages()
    {
        // Arrange
        // Add some test data to the database
        var page1 = new WikiPage { Title = "Page 1", Content = "Content of page 1" };
        var page2 = new WikiPage { Title = "Page 2", Content = "Content of page 2" };
        await DbContext.WikiPages.AddRangeAsync(page1, page2);
        await DbContext.SaveChangesAsync();

        // Act
        var result = await _controller.GetWikiPages();

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Result, Is.InstanceOf<OkObjectResult>());
        var okResult = result.Result as OkObjectResult;
        var pages = okResult!.Value as IEnumerable<WikiPage>;
        Assert.That(pages, Is.Not.Null);
        Assert.That(pages, Does.Contain(page1));
        Assert.That(pages, Does.Contain(page2));
    }

    [Test]
    public async Task GetWikiPageBySlug_ShouldReturnPage()
    {
        // Arrange
        var pageId = Guid.NewGuid();
        var page = new WikiPage {Id = pageId, Title = "IntTestPage", Slug = "inttestpage", Content = "Content of page" };
        await DbContext.WikiPages.AddAsync(page);
        await DbContext.SaveChangesAsync();

        // Act
        var result = await _controller.GetWikiPageBySlug(page.Slug!);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Result, Is.InstanceOf<OkObjectResult>());
        var okResult = result.Result as OkObjectResult;
        var returnedPage = okResult!.Value as WPWithImagesOutputModel;
        Assert.That(returnedPage, Is.Not.Null);
        Assert.That(returnedPage.WikiPage!.Id, Is.EqualTo(page.Id));
    }
    
    [Test]
    public async Task GetWikiPageBySlug_NonExistentSlug_ShouldReturnNull()
    {
        // Arrange & Act
        var result = await _controller.GetWikiPageBySlug("non-existent-slug");

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Result, Is.InstanceOf<NotFoundResult>());
    }
    
    [Test]
    public async Task CreateWikiPageForAdmin_ShouldCreatePage()
    {
        // Arrange
        _controller.ControllerContext.HttpContext = new DefaultHttpContext
        {
            Request = { Headers = { ["Authorization"] = $"Bearer {_adminToken}" } }
        };
        var pageModel = new WikiPageWithImagesInputModel
        {
            Title = "Test Page",
            Content = "Test content",
            CategoryId = _catId
        };

        // Act
        var result = await _controller.CreateWikiPageForAdmin(pageModel);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Result, Is.InstanceOf<OkObjectResult>());
        var createdPage = await DbContext.WikiPages.FirstOrDefaultAsync(wp => wp.Title == pageModel.Title);
        Assert.That(createdPage, Is.Not.Null);
        Assert.That(createdPage.Title, Is.EqualTo(pageModel.Title));
    }
    
    [Test]
    public async Task CreateWikiPageForAdmin_InvalidTitle_ShouldReturnBadRequest()
    {
        // Arrange
        _controller.ControllerContext.HttpContext = new DefaultHttpContext
        {
            Request = { Headers = { ["Authorization"] = $"Bearer {_adminToken}" } }
        };
        var pageModel = new WikiPageWithImagesInputModel
        {
            Content = "Test content",
            CategoryId = _catId
        };

        // Act
        var result = await _controller.CreateWikiPageForAdmin(pageModel);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Result, Is.InstanceOf<BadRequestObjectResult>());
    }
    
    [Test]
    public async Task CreateWikiPageForAdmin_NoCategoryId_ShouldReturn500()
    {
        // Arrange
        _controller.ControllerContext.HttpContext = new DefaultHttpContext
        {
            Request = { Headers = { ["Authorization"] = $"Bearer {_adminToken}" } }
        };
        var pageModel = new WikiPageWithImagesInputModel
        {
            Content = "Test content",
            Title = "Title"
        };

        // Act
        var result = await _controller.CreateWikiPageForAdmin(pageModel);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Result, Is.InstanceOf<ObjectResult>());
        var objectResult = result.Result as ObjectResult;
        Assert.That(objectResult!.StatusCode, Is.EqualTo(500));
    }
    
    [Test]
    public async Task UpdateWikiPageForAdmin_ShouldUpdatePage()
    {
        // Arrange
        // Add existing WikiPage data to the database
        var existingId = Guid.NewGuid();
        var existingPage = new WikiPage { Id = existingId, Title = "Test Title UpdateAdmin"};
        await DbContext.WikiPages.AddAsync(existingPage);
        await DbContext.SaveChangesAsync();

        _controller.ControllerContext.HttpContext = new DefaultHttpContext
        {
            Request = { Headers = { ["Authorization"] = $"Bearer {_adminToken}" } }
        };
        var pageModel = new WikiPageWithImagesInputModel
        {
            Title = "Updated Test Page",
            Content = "Updated test content",
            CategoryId = _catId
        };

        // Act
        var result = await _controller.UpdateWikiPageForAdmin(existingPage.Id, pageModel);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.InstanceOf<OkObjectResult>());
        var updatedPage = await DbContext.WikiPages.FindAsync(existingPage.Id);
        Assert.That(updatedPage, Is.Not.Null);
        Assert.That(updatedPage.Title, Is.EqualTo(pageModel.Title));
    }
    
    [Test]
    public async Task UpdateWikiPageForAdmin_NonExistentPage_ShouldReturnNotFoundResult()
    {
        // Arrange
        // Add existing WikiPage data to the database
        var existingId = Guid.NewGuid();

        _controller.ControllerContext.HttpContext = new DefaultHttpContext
        {
            Request = { Headers = { ["Authorization"] = $"Bearer {_adminToken}" } }
        };
        var pageModel = new WikiPageWithImagesInputModel
        {
            Content = "Updated test content",
            CategoryId = _catId
        };

        // Act
        var result = await _controller.UpdateWikiPageForAdmin(existingId, pageModel);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.InstanceOf<NotFoundResult>());
    }
    
    [Test]
    public async Task UpdateWikiPageForAdmin_InvalidCategoryId_ShouldReturnBadRequest()
    {
        // Arrange
        // Add existing WikiPage data to the database
        var existingId = Guid.NewGuid();
        var existingPage = new WikiPage { Id = existingId, Title = "Test Title UpdateAdmin"};
        await DbContext.WikiPages.AddAsync(existingPage);
        await DbContext.SaveChangesAsync();

        _controller.ControllerContext.HttpContext = new DefaultHttpContext
        {
            Request = { Headers = { ["Authorization"] = $"Bearer {_adminToken}" } }
        };
        var pageModel = new WikiPageWithImagesInputModel
        {
            Content = "Updated test content",
            CategoryId = Guid.NewGuid()
        };

        // Act
        var result = await _controller.UpdateWikiPageForAdmin(existingId, pageModel);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.InstanceOf<BadRequestObjectResult>());
        var badRequestResult = result as BadRequestObjectResult;
        
        // Ensure the Value is not null
        Assert.That(badRequestResult!.Value, Is.Not.Null);

        // Cast Value to dynamic
        dynamic value = badRequestResult.Value;

        // Access the Message property
        string message = $"'{value}'";

        Assert.That(message, Is.EqualTo($"'{{ Message = Invalid CategoryId }}'"));
    }
    
    [Test]
    public async Task CreateWikiPageForUser_ShouldCreatePage()
    {
        // Arrange
    
        _controller.ControllerContext.HttpContext = new DefaultHttpContext
        {
            Request = { Headers = { ["Authorization"] = $"Bearer {_userToken}" } }
        };
        var pageModel = new WikiPageWithImagesInputModel
        {
            Title = "Test Page",
            Content = "Test content",
            CategoryId = _catId
            // Add other necessary properties
        };

        // Act
        var result = await _controller.CreateWikiPageForUser(pageModel);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Result, Is.InstanceOf<CreatedAtActionResult>());
        var createdPage = await DbContext.WikiPages.FirstOrDefaultAsync(wp => wp.Title == pageModel.Title);
        Assert.That(createdPage, Is.Not.Null);
        Assert.That(createdPage.Title, Is.EqualTo(pageModel.Title));
    }
    
    [Test]
    public async Task UpdateWikiPageForUser_ShouldUpdatePage()
    {
        // Arrange
        // Add existing WikiPage data to the database
        var existingId = Guid.NewGuid();
        var existingPage = new WikiPage { Id = existingId, Title = "Test Title UpdateUser"};
        await DbContext.WikiPages.AddAsync(existingPage);
        await DbContext.SaveChangesAsync();

        _controller.ControllerContext.HttpContext = new DefaultHttpContext
        {
            Request = { Headers = { ["Authorization"] = $"Bearer {_userToken}" } }
        };
        var pageModel = new WikiPageWithImagesInputModel
        {
            Title = "Updated Test Page",
            Content = "Updated test content",
            CategoryId = _catId
            // Add other necessary properties
        };

        // Act
        var result = await _controller.UpdateWikiPageForUser(existingPage.Id, pageModel);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.InstanceOf<CreatedAtActionResult>());
        var updatedPage = await DbContext.WikiPages.FindAsync(existingPage.Id);
        Assert.That(updatedPage, Is.Not.Null);
        Assert.That(updatedPage.Title, Is.Not.EqualTo(pageModel.Title));
    }
    
    [Test]
    public async Task DeleteWikiPageForAdmin_ShouldDeletePage()
    {
        // Arrange
        var pageId = Guid.NewGuid();
        var page = new WikiPage { Id = pageId, Title = "PageToDelete", Content = "Content of page to delete" };
        await DbContext.WikiPages.AddAsync(page);
        await DbContext.SaveChangesAsync();

        _controller.ControllerContext.HttpContext = new DefaultHttpContext
        {
            Request = { Headers = { ["Authorization"] = $"Bearer {_adminToken}" } }
        };

        // Act
        var result = await _controller.DeleteWikiPageForAdmin(pageId);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.InstanceOf<OkObjectResult>());
        var deletedPage = await DbContext.WikiPages.FindAsync(pageId);
        Assert.That(deletedPage, Is.Null);
    }
    
    [Test]
    public async Task DeleteWikiPageForAdmin_NonExistentPage_ShouldReturnNotFoundObjectResult()
    {
        // Arrange
        var pageId = Guid.NewGuid();

        _controller.ControllerContext.HttpContext = new DefaultHttpContext
        {
            Request = { Headers = { ["Authorization"] = $"Bearer {_adminToken}" } }
        };

        // Act
        var result = await _controller.DeleteWikiPageForAdmin(pageId);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.InstanceOf<NotFoundObjectResult>());
    }

    [Test]
    public async Task DeleteUserSubmittedWikiPage_ShouldDeletePage()
    {
        // Arrange
        var pageId = Guid.NewGuid();
        var page = new UserSubmittedWikiPage { Id = pageId, Title = "UserSubmittedPageToDelete", Content = "Content of user submitted page to delete" };
        await DbContext.UserSubmittedWikiPages.AddAsync(page);
        await DbContext.SaveChangesAsync();

        _controller.ControllerContext.HttpContext = new DefaultHttpContext
        {
            Request = { Headers = { ["Authorization"] = $"Bearer {_adminToken}" } }
        };

        // Act
        var result = await _controller.DeleteUserSubmittedWikiPage(pageId);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.InstanceOf<OkObjectResult>());
        var deletedPage = await DbContext.UserSubmittedWikiPages.FindAsync(pageId);
        Assert.That(deletedPage, Is.Null);
    }
    
    [Test]
    public async Task DeleteUserSubmittedWikiPage_NonExistentPage_ShouldReturnNotFoundObjectResult()
    {
        // Arrange
        var pageId = Guid.NewGuid();

        _controller.ControllerContext.HttpContext = new DefaultHttpContext
        {
            Request = { Headers = { ["Authorization"] = $"Bearer {_adminToken}" } }
        };

        // Act
        var result = await _controller.DeleteUserSubmittedWikiPage(pageId);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.InstanceOf<NotFoundObjectResult>());
    }

    [Test]
    public async Task GetSubmittedPageById_ShouldReturnPage()
    {
        // Arrange
        var pageId = Guid.NewGuid();
        var page = new UserSubmittedWikiPage { Id = pageId, Title = "TestSubmittedPage", Content = "Content of submitted page", IsNewPage = true};
        await DbContext.UserSubmittedWikiPages.AddAsync(page);
        await DbContext.SaveChangesAsync();

        _controller.ControllerContext.HttpContext = new DefaultHttpContext
        {
            Request = { Headers = { ["Authorization"] = $"Bearer {_adminToken}" } }
        };

        // Act
        var result = await _controller.GetSubmittedPageById(pageId);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Result, Is.InstanceOf<OkObjectResult>());
        var okResult = result.Result as OkObjectResult;
        Assert.That(okResult, Is.Not.Null);
        var returnedPage = okResult.Value as WPWithImagesOutputModel;
        Assert.That(returnedPage, Is.Not.Null);
        Assert.That(returnedPage.UserSubmittedWikiPage!.Id, Is.EqualTo(pageId));
    }

    [Test]
    public async Task GetSubmittedUpdateByTitle_ShouldReturnUpdate()
    {
        // Arrange
        var updateId = Guid.NewGuid();
        var update = new UserSubmittedWikiPage { Id = updateId, Title = "TestUpdate", Content = "Content of update" };
        await DbContext.UserSubmittedWikiPages.AddAsync(update);
        await DbContext.SaveChangesAsync();

        _controller.ControllerContext.HttpContext = new DefaultHttpContext
        {
            Request = { Headers = { ["Authorization"] = $"Bearer {_adminToken}" } }
        };

        // Act
        var result = await _controller.GetSubmittedUpdateByTitle(updateId);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Result, Is.InstanceOf<OkObjectResult>());
        var okResult = result.Result as OkObjectResult;
        Assert.That(okResult, Is.Not.Null);
        var returnedPage = okResult.Value as WPWithImagesOutputModel;
        Assert.That(returnedPage, Is.Not.Null);
        Assert.That(returnedPage.UserSubmittedWikiPage!.Id, Is.EqualTo(updateId));
    }
    
    [Test]
    public async Task GetSubmittedUpdateByTitle_NonExistentPage_ShouldReturnNotFoundResult()
    {
        // Arrange
        var updateId = Guid.NewGuid();

        _controller.ControllerContext.HttpContext = new DefaultHttpContext
        {
            Request = { Headers = { ["Authorization"] = $"Bearer {_adminToken}" } }
        };

        // Act
        var result = await _controller.GetSubmittedUpdateByTitle(updateId);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Result, Is.InstanceOf<NotFoundResult>());
    }

    [Test]
    public async Task GetSubmittedPages_ShouldReturnTitlesAndIds()
    {
        // Arrange
        var page1 = new UserSubmittedWikiPage { Id = Guid.NewGuid(), Title = "SubmittedPage1", Content = "Content of submitted page 1", IsNewPage = true };
        var page2 = new UserSubmittedWikiPage { Id = Guid.NewGuid(), Title = "SubmittedPage2", Content = "Content of submitted page 2", IsNewPage = true };
        await DbContext.UserSubmittedWikiPages.AddRangeAsync(page1, page2);
        await DbContext.SaveChangesAsync();

        _controller.ControllerContext.HttpContext = new DefaultHttpContext
        {
            Request = { Headers = { ["Authorization"] = $"Bearer {_adminToken}" } }
        };

        // Act
        var result = await _controller.GetSubmittedPages();

        
        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Result, Is.InstanceOf<OkObjectResult>());
        var okResult = result.Result as OkObjectResult;
        Assert.That(okResult, Is.Not.Null);
        var titlesAndIds = okResult.Value as IEnumerable<WikiPageTitleEntry>;
        Assert.That(titlesAndIds, Is.Not.Null);
        // Assert.IsTrue(titlesAndIds.Value.Any());
    }
    
    [Test]
    public async Task GetSubmittedPages_EmptyDb_ShouldReturnEmptyList()
    {
        // Arrange
        DbContext.UserSubmittedWikiPages.RemoveRange(await DbContext.UserSubmittedWikiPages.ToListAsync());
        await DbContext.SaveChangesAsync();

        _controller.ControllerContext.HttpContext = new DefaultHttpContext
        {
            Request = { Headers = { ["Authorization"] = $"Bearer {_adminToken}" } }
        };

        // Act
        var result = await _controller.GetSubmittedPages();

        
        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Result, Is.InstanceOf<OkObjectResult>());
        var okResult = result.Result as OkObjectResult;
        Assert.That(okResult, Is.Not.Null);
        var titlesAndIds = okResult.Value as IEnumerable<WikiPageTitleEntry>;
        Assert.That(titlesAndIds, Is.Not.Null);
        Assert.That(titlesAndIds.Count(), Is.EqualTo(0));
        // Assert.IsTrue(titlesAndIds.Value.Any());
    }
    
    [Test]
    public async Task GetSubmittedUpdates_ShouldReturnTitlesAndIds()
    {
        // Arrange
        var update1 = new UserSubmittedWikiPage { Id = Guid.NewGuid(), Title = "Update1", Content = "Content of update 1", IsNewPage = false};
        var update2 = new UserSubmittedWikiPage { Id = Guid.NewGuid(), Title = "Update2", Content = "Content of update 2", IsNewPage = false };
        await DbContext.UserSubmittedWikiPages.AddRangeAsync(update1, update2);
        await DbContext.SaveChangesAsync();

        _controller.ControllerContext.HttpContext = new DefaultHttpContext
        {
            Request = { Headers = { ["Authorization"] = $"Bearer {_adminToken}" } }
        };

        // Act
        var result = await _controller.GetSubmittedUpdates();

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Result, Is.InstanceOf<OkObjectResult>());
        var titlesAndIds = result.Result as ActionResult;
        Assert.That(titlesAndIds, Is.Not.Null);
        // Assert.IsTrue(titlesAndIds.Value.Any());
    }
}