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
        Assert.That(result, Is.Not.Null);
        var okResult = result.Result as OkObjectResult;
        Assert.That(okResult, Is.Not.Null);
        var forumTopics = okResult.Value as IEnumerable<ForumTopic>;
        Assert.That(forumTopics, Is.Not.Null);
        Assert.That(forumTopics, Is.Not.Empty);
    }
    
    [Test]
    public async Task AddForumTopic_ShouldCreateForumTopic()
    {
        // Arrange
        var forumTopic = new ForumTopic { Title = "New Topic", Description = "New Description", Slug = "new-topic" };

        // Act
        var result = await _controller.AddForumTopic(forumTopic) as ActionResult<ForumTopic>;

        // Assert
        Assert.That(result, Is.Not.Null);
        var createdForumTopic = await _forumTopicRepository.GetForumTopicBySlugAsync(forumTopic.Slug);
        Assert.That(createdForumTopic, Is.Not.Null);
        Assert.That(createdForumTopic.Title, Is.EqualTo(forumTopic.Title));
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
        Assert.That(result, Is.Not.Null);
        Assert.That(result.StatusCode, Is.EqualTo(204));
        var updatedForumTopic = await _forumTopicRepository.GetForumTopicBySlugAsync(forumTopic.Slug);
        Assert.That(updatedForumTopic, Is.Not.Null);
        Assert.That(updatedForumTopic!.Title, Is.EqualTo("Updated Topic"));
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
        Assert.That(result, Is.Not.Null);
        Assert.That(result.StatusCode, Is.EqualTo(204));
        var deletedForumTopic = await _forumTopicRepository.GetForumTopicBySlugAsync(forumTopic.Slug);
        Assert.That(deletedForumTopic, Is.Null);
    }

    [Test]
    public async Task SearchForumTopics_ShouldReturnMatchingTopics()
    {
        var forumTopic = new ForumTopic { Title = "Search Topic", Description = "Description for search", Slug = "search-topic" };
        await _forumTopicRepository.AddForumTopicAsync(forumTopic);

        var result = await _controller.SearchForumTopics("Search");
        var okResult = result.Result as OkObjectResult;
        Assert.That(okResult, Is.Not.Null);
        Assert.That(okResult.StatusCode, Is.EqualTo(200));
        var topics = okResult.Value as List<ForumTopic>;
        Assert.That(topics, Is.Not.Null);
        Assert.That(topics.Count, Is.EqualTo(1));
        Assert.That(topics[0].Title, Is.EqualTo("Search Topic"));
    }
}