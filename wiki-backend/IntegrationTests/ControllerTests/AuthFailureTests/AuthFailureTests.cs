using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using wiki_backend.Controllers;
using wiki_backend.DatabaseServices.Repositories;
using wiki_backend.Models;
using wiki_backend.Services;

namespace IntegrationTests.ControllerTests.AuthFailureTests;

[TestFixture]
public class AuthFailureTests : IntegrationTestBase
{
    [Test]
    public async Task UserCommentController_Delete_WithoutUser_ShouldReturn401()
    {
        ResetDatabase();
        await EnsureUserRoleExistsAsync();

        var userManager = ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        var commentRepo = new UserCommentRepository(DbContext);

        var wikiPage = new WikiPage { Title = "TestPage", Content = "test" };
        var profile = new UserProfile { UserName = "author" };
        DbContext.UserProfiles.Add(profile);
        DbContext.WikiPages.Add(wikiPage);
        await DbContext.SaveChangesAsync();

        var comment = new UserComment
        {
            Content = "test",
            UserProfileId = profile.Id,
            UserProfile = profile,
            WikiPageId = wikiPage.Id,
            WikiPage = wikiPage,
            PostDate = DateTime.UtcNow
        };
        DbContext.UserComments.Add(comment);
        await DbContext.SaveChangesAsync();
        var authService = new UserAuthorizationService(userManager);
        var controller = new UserCommentController(commentRepo, authService, null!, null!);

        controller.ControllerContext.HttpContext = new DefaultHttpContext();

        var result = await controller.DeleteComment(comment.Id);

        Assert.That(result, Is.InstanceOf<UnauthorizedObjectResult>());
    }

    [Test]
    public async Task UserCommentController_Delete_WithOwnerUser_ShouldNotReturn401()
    {
        ResetDatabase();
        await EnsureUserRoleExistsAsync();

        var userManager = ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        var commentRepo = new UserCommentRepository(DbContext);

        var wikiPage = new WikiPage { Title = "TestPage2", Content = "test" };
        var profile = new UserProfile { UserName = "owninguser" };
        DbContext.UserProfiles.Add(profile);
        DbContext.WikiPages.Add(wikiPage);
        await DbContext.SaveChangesAsync();

        var comment = new UserComment
        {
            Content = "test",
            UserProfileId = profile.Id,
            UserProfile = profile,
            WikiPageId = wikiPage.Id,
            WikiPage = wikiPage,
            PostDate = DateTime.UtcNow
        };
        DbContext.UserComments.Add(comment);
        await DbContext.SaveChangesAsync();

        var authService = new UserAuthorizationService(userManager);
        var controller = new UserCommentController(commentRepo, authService, null!, null!);
        controller.ControllerContext.HttpContext = new DefaultHttpContext
        {
            User = new ClaimsPrincipal(new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, "owninguser")
            }, "Test"))
        };

        var result = await controller.DeleteComment(comment.Id);

        Assert.That(result, Is.InstanceOf<OkObjectResult>());
    }
}
