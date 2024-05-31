using DotNetEnv;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using wiki_backend.Contracts;
using wiki_backend.Controllers;
using wiki_backend.DatabaseServices.Repositories;
using wiki_backend.Models;
using wiki_backend.Services.Authentication;

namespace IntegrationTests.ControllerTests.UserControllers;

[TestFixture]
[NonParallelizable]
public class UserCommentControllerTests : IntegrationTestBase
{
    private UserCommentController _controller;
    private AuthController _authController;
    private string? _token;
    private string? _userName;

    [SetUp]
    public async Task SetUp()
    {
        // Check JWT configuration, This shouldn't fix anything but somehow it did?
        Env.TraversePath().Load();
        var signingKey = Environment.GetEnvironmentVariable("JWT_ISSUER_SIGNING_KEY");
        if (string.IsNullOrEmpty(signingKey))
        {
            throw new InvalidOperationException("JWT_ISSUER_SIGNING_KEY is not configured.");
        }
        // Ensure necessary setup
        await EnsureUserRoleExistsAsync();
        // await AddTestUser("testuser99");
        _controller = CreateUserCommentController();
        _authController = CreateAuthController();
        _userName = $"{GetRandomizedString("testuser")}";
        _token = await GetValidUserToken($"{GetRandomizedString("test")}@example.com", _userName, "@Password123");
    }
    private UserCommentController CreateUserCommentController()
    {
        var userCommentRepository = new UserCommentRepository(DbContext);
        var userManager = ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        return new UserCommentController(userCommentRepository, userManager);
    }

    private AuthController CreateAuthController()
    {
        var tokenService = new TokenServices();
        var userManager = ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        return new AuthController(new AuthService(userManager, tokenService));
    }

    private async Task<UserComment> AddTestComment(string content)
    {
        // var userProfile = await AddTestUser(userName);
        var userProfile = await DbContext.UserProfiles.FirstOrDefaultAsync(up => up.UserName == _userName);
        var wikiPage = new WikiPage
        {
            Id = Guid.NewGuid(),
            Title = "Test Page"
        };
        DbContext.WikiPages.Add(wikiPage);
        await DbContext.SaveChangesAsync();

        var comment = new UserComment
        {
            Id = Guid.NewGuid(),
            Content = content,
            UserProfileId = userProfile.Id,
            UserProfile = userProfile,
            WikiPageId = wikiPage.Id
        };

        DbContext.UserComments.Add(comment);
        await DbContext.SaveChangesAsync();

        return comment;
    }

    private async Task<UserProfile> AddTestUser(string userName)
    {
        var userId = Guid.NewGuid().ToString();
        var userProfileId = Guid.NewGuid();
        var user = new ApplicationUser
        {
            UserName = userName,
            Id = userId,
            ProfileId = userProfileId,
            Profile = new UserProfile
            {
                Id = userProfileId,
                UserName = userName,
                UserId = userId,
            }
        };
        DbContext.ApplicationUsers.Add(user);
        DbContext.UserProfiles.Add(user.Profile);
        await DbContext.SaveChangesAsync();

        return user.Profile;
    }

    private async Task EnsureUserRoleExistsAsync()
    {
        var roleManager = ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        if (!await roleManager.RoleExistsAsync("USER"))
        {
            await roleManager.CreateAsync(new IdentityRole("USER"));
        }
    }

    private async Task<string> GetValidUserToken(string email, string username, string password)
    {
        // Register the user
        var registerRequest = new RegistrationRequest(email, username, password);
        var registerResult = await _authController.Register(registerRequest);
        if (!(registerResult.Result is CreatedAtActionResult))
        {
            throw new InvalidOperationException("User registration failed.");
        }

        // Login the user
        var loginRequest = new AuthRequest(email, password);
        var loginResult = await _authController.Authenticate(loginRequest);
        if (!(loginResult.Result is OkObjectResult okResult))
        {
            throw new InvalidOperationException("User login failed.");
        }

        var authResponse = okResult.Value as AuthResponse;
        return authResponse?.Token;
    }

    [Test]
    public async Task GetComment_ExistingId_ShouldReturnComment()
    {
        // Arrange
        var testComment = await AddTestComment("Test comment");
        var commentId = testComment.Id;

        // Act
        var result = await _controller.GetComment(commentId);

        // Assert
        if (result.Result is OkObjectResult okResult)
        {
            var comment = okResult.Value as UserComment;
            Assert.IsNotNull(comment);
            Assert.AreEqual(testComment.Id, comment.Id);
        }
        else
        {
            Assert.Fail("Expected OkObjectResult but got a different result type.");
        }
    }

    [Test]
    public async Task GetComment_NonExistingId_ShouldReturnNotFound()
    {
        // Arrange
        var nonExistingId = Guid.NewGuid();

        // Act
        var result = await _controller.GetComment(nonExistingId);

        // Assert
        Assert.IsInstanceOf<NotFoundObjectResult>(result.Result);
    }

    [Test]
    public async Task PostComment_ValidComment_ShouldCreateComment()
    {
        // Arrange
        _controller.ControllerContext.HttpContext = new DefaultHttpContext
        {
            Request = { Headers = { ["Authorization"] = $"Bearer {_token}" } }
        };

        var comment = await AddTestComment("content");
        comment.Id = new Guid();

        // Act
        var result = await _controller.PostComment(comment);

        // Assert
        Assert.IsInstanceOf<CreatedAtActionResult>(result.Result);
    }

    [Test]
    public async Task EditComment_ValidRequest_ShouldEditComment()
    {
        // Arrange
        _controller.ControllerContext.HttpContext = new DefaultHttpContext
        {
            Request = { Headers = { ["Authorization"] = $"Bearer {_token}" } }
        };
        var testComment = await AddTestComment("Original Comment");
        var updatedContent = "Updated Comment";
    
        // Detach the entity before modifying it
        DbContext.Entry(testComment).State = EntityState.Detached;

        // Modify the entity
        testComment.Content = updatedContent;
        DbContext.Entry(testComment).State = EntityState.Modified;
    
        await DbContext.SaveChangesAsync();
    
        // Act
        var result = await _controller.EditComment(testComment.Id, updatedContent);

        // Assert
        Assert.IsInstanceOf<OkObjectResult>(result);
    }


    [Test]
    public async Task DeleteComment_ValidRequest_ShouldDeleteComment()
    {
        // Arrange
        _controller.ControllerContext.HttpContext = new DefaultHttpContext
        {
            Request = { Headers = { ["Authorization"] = $"Bearer {_token}" } }
        };
        var testComment = await AddTestComment("Test Comment");

        // Act
        var result = await _controller.DeleteComment(testComment.Id);

        // Assert
        Assert.IsInstanceOf<OkObjectResult>(result);
    }
}
