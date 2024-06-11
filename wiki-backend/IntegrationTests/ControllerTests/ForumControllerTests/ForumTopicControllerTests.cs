using DotNetEnv;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using wiki_backend.Controllers.ForumControllers;
using wiki_backend.DatabaseServices.Repositories.ForumRepositories;
using wiki_backend.Models;
using wiki_backend.Models.ForumModels;

namespace IntegrationTests.ControllerTests.ForumControllerTests;

[TestFixture]
[NonParallelizable]
public class ForumTopicControllerTests : IntegrationTestBase 
{
    private ForumTopicController _controller;
    private IForumTopicRepository _forumTopicRepository;
    private UserManager<ApplicationUser> _userManager;
    private string? _token;
    private string? _userName;
    private string? _email;
    
    [SetUp]
    public async Task SetUp()
    {
        // Check JWT configuration, This shouldn't fix anything but somehow it did?
        Env.TraversePath().Load();
        var signingKey = Environment.GetEnvironmentVariable("JWT_ISSUER_SIGNING_KEY");
            
        _forumTopicRepository = new ForumTopicRepository(DbContext);
        _userManager = ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        _controller = new ForumTopicController(_forumTopicRepository);
        ResetDatabase();
        await EnsureUserRoleExistsAsync();
        _userName = $"{GetRandomizedString("testuser")}";
        _email = $"{GetRandomizedString("test")}@example.com";
        await CreateAdminUserAsync(_email, _userName, "@Password123");
        _token = await GetValidUserToken(_email, _userName, "@Password123");
    }
    
    [Test]
    public async Task GetForumTopics_ShouldReturnForumTopics()
    {
        // Arrange
        var forumTopic = new ForumTopic { Title = "Test Topic", Description = "Test Description", Slug = "test-topic" };
        await _forumTopicRepository.AddForumTopicAsync(forumTopic);

        // Act
        var result = await _controller.GetForumTopics() as ActionResult<IEnumerable<ForumTopic>>;

        // Assert
        Assert.IsNotNull(result);
        var okResult = result.Result as OkObjectResult;
        Assert.IsNotNull(okResult);
        var forumTopics = okResult.Value as IEnumerable<ForumTopic>;
        Assert.IsNotNull(forumTopics);
        Assert.IsNotEmpty(forumTopics);
    }
    
    [Test]
    public async Task AddForumTopic_ShouldCreateForumTopic()
    {
        // Arrange
        var forumTopic = new ForumTopic { Title = "New Topic", Description = "New Description", Slug = "new-topic" };

        // Act
        var result = await _controller.AddForumTopic(forumTopic) as ActionResult<ForumTopic>;

        // Assert
        Assert.IsNotNull(result);
        var createdForumTopic = await _forumTopicRepository.GetForumTopicBySlugAsync(forumTopic.Slug);
        Assert.IsNotNull(createdForumTopic);
        Assert.AreEqual(forumTopic.Title, createdForumTopic.Title);
    }

    [Test]
    public async Task UpdateForumTopic_ShouldUpdateForumTopic()
    {
        // Arrange
        var forumTopic = new ForumTopic { Title = "Update Topic", Description = "Update Description", Slug = "update-topic" };
        await _forumTopicRepository.AddForumTopicAsync(forumTopic);

        // Act
        forumTopic.Title = "Updated Topic";
        var result = await _controller.UpdateForumTopic(forumTopic.Id, forumTopic) as NoContentResult;

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(204, result.StatusCode);
        var updatedForumTopic = await _forumTopicRepository.GetForumTopicBySlugAsync(forumTopic.Slug);
        Assert.AreEqual("Updated Topic", updatedForumTopic.Title);
    }

    [Test]
    public async Task DeleteForumTopic_ShouldDeleteForumTopic()
    {
        // Arrange
        var forumTopic = new ForumTopic { Title = "Delete Topic", Description = "Delete Description", Slug = "delete-topic" };
        await _forumTopicRepository.AddForumTopicAsync(forumTopic);

        // Act
        var result = await _controller.DeleteForumTopic(forumTopic.Id) as NoContentResult;

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(204, result.StatusCode);
        var deletedForumTopic = await _forumTopicRepository.GetForumTopicBySlugAsync(forumTopic.Slug);
        Assert.IsNull(deletedForumTopic);
    }
}