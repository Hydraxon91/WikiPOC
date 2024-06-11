using System.Net;
using DotNetEnv;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework.Internal;
using wiki_backend.Controllers.ForumControllers;
using wiki_backend.DatabaseServices.Repositories.ForumRepositories;
using wiki_backend.Models;
using wiki_backend.Models.ForumModels;

namespace IntegrationTests.ControllerTests.ForumControllerTests;

[TestFixture]
[NonParallelizable]
public class ForumCommentControllerTests : IntegrationTestBase
{
    private ForumCommentRepository _commentRepository;
    private UserManager<ApplicationUser> _userManager;
    private ForumCommentController _controller;
    private string? _token;
    private string? _userName;
    private string? _email;

    [SetUp]
    public async Task SetUp()
    {
        // Check JWT configuration, This shouldn't fix anything but somehow it did?
        Env.TraversePath().Load();
        var signingKey = Environment.GetEnvironmentVariable("JWT_ISSUER_SIGNING_KEY");
        
        _commentRepository = new ForumCommentRepository(DbContext);
        _userManager = ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        _controller = new ForumCommentController(_commentRepository, _userManager);
        ResetDatabase();
        await EnsureUserRoleExistsAsync();
        _userName = $"{GetRandomizedString("testuser")}";
        _email = $"{GetRandomizedString("test")}@example.com";
        await CreateAdminUserAsync(_email, _userName, "@Password123");
        _token = await GetValidUserToken(_email, _userName, "@Password123");
    }

    [Test]
    public async Task GetComment_Should_Return_Comment()
    {
        // Arrange
        var userProfileId = await AddUserProfile();
        
        var comment = await AddTestComment(userProfileId);
        
        // Act
        var result = await _controller.GetComment(comment.Id);
        
        // Assert
        var okResult = result.Result as OkObjectResult;
        Assert.NotNull(okResult);
        Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);

        var returnComment = okResult.Value as ForumComment;
        Assert.AreEqual(comment.Content, returnComment.Content);
    }

    [Test]
    public async Task PostComment_Should_Post_Comment()
    {
        // Arrange
        _controller.ControllerContext.HttpContext = new DefaultHttpContext
        {
            Request = { Headers = { ["Authorization"] = $"Bearer {_token}" } }
        };
        
        var userProfileId = await AddUserProfile();
        var forumpostId = await AddForumTopicAndPost(userProfileId);

        var postCommentId = Guid.NewGuid();
        var postComment = new ForumComment
        {
            Id = postCommentId,
            UserProfileId = userProfileId,
            ForumPostId = forumpostId,
            Content = "Post Test Comment",
        };
        
        // Act
        await _controller.PostComment(postComment);
        
        // Assert
        var comment = await DbContext.ForumComments.FirstOrDefaultAsync(fc => fc.Id == postCommentId);

        Assert.NotNull(comment);
        Assert.AreEqual(comment, postComment);
    }
    
    [Test]
    public async Task Authorized_EditComment_Should_Edit_Comment()
    {
        // Arrange
        _controller.ControllerContext.HttpContext = new DefaultHttpContext
        {
            Request = { Headers = { ["Authorization"] = $"Bearer {_token}" } }
        };
        
        var userProfileId = await AddUserProfile();
        await AddForumTopicAndPost(userProfileId);
        var comment = await AddTestComment(userProfileId);
        
        // Act
        var updatedContent = "Updated Content";
        var result = await _controller.EditComment(comment.Id, updatedContent);
        
        // Assert
        var okResult = result as OkObjectResult;
        Assert.IsNotNull(okResult);
        Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);

        var editedComment = await DbContext.ForumComments.FirstOrDefaultAsync(fc => fc.Id == comment.Id);
        Assert.AreEqual(editedComment.Content, updatedContent);
    }
    
    [Test]
    public async Task Authorized_DeleteComment_Should_Delete_Comment()
    {
        // Arrange
        _controller.ControllerContext.HttpContext = new DefaultHttpContext
        {
            Request = { Headers = { ["Authorization"] = $"Bearer {_token}" } }
        };
        
        var userProfileId = await AddUserProfile();
        await AddForumTopicAndPost(userProfileId);
        var comment = await AddTestComment(userProfileId);
        
        // Act
        var result = await _controller.DeleteComment(comment.Id);
        
        // Assert
        var okResult = result as OkObjectResult;
        Assert.IsNotNull(okResult);
        Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);

        var deletedComment = await DbContext.ForumComments.FirstOrDefaultAsync(fc => fc.Id == comment.Id);
        Assert.IsNull(deletedComment);
    }

    private async Task<Guid> AddUserProfile()
    {
        var userProfileId = Guid.NewGuid();
        var userProfile = new UserProfile
        {
            Id = userProfileId,
        };
        await DbContext.UserProfiles.AddAsync(userProfile);
        await DbContext.SaveChangesAsync();

        return userProfileId;
    }
    
    private async Task<Guid> AddForumTopicAndPost(Guid userProfileId)
    {
        var forumTopicId = Guid.NewGuid();
        var forumTopic = new ForumTopic
        {
            Id = forumTopicId,
            Title = "Test",
            Description = "test",
            Slug = "test"
        };
        await DbContext.ForumTopics.AddAsync(forumTopic);
        await DbContext.SaveChangesAsync();
        
        var forumPostId = Guid.NewGuid();
        var forumPost = new ForumPost
        {
            Id = forumPostId,
            UserId = userProfileId,
            Content = "test",
            PostTitle = "test",
            Slug = "test",
            UserName = "Tester",
            ForumTopicId = forumTopicId
        };
        await DbContext.ForumPosts.AddAsync(forumPost);
        await DbContext.SaveChangesAsync();

        return forumPostId;
    }

    private async Task<ForumComment> AddTestComment(Guid userProfileId)
    {
        var userProfile = await DbContext.UserProfiles.FirstOrDefaultAsync(up => up.UserName == _userName);
        var forumPostId = await AddForumTopicAndPost(userProfileId);
        
        var commentId = Guid.NewGuid();
        var comment = new ForumComment
        {
            Id = commentId,
            Content = "Test comment",
            PostDate = DateTime.Now,
            UserProfileId = userProfile.Id,
            ForumPostId = forumPostId
        };
        await DbContext.ForumComments.AddAsync(comment);
        await DbContext.SaveChangesAsync();

        return comment;
    }
}