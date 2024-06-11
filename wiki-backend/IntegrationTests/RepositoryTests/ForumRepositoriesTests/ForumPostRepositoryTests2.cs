using Microsoft.EntityFrameworkCore;
using wiki_backend.DatabaseServices.Repositories.ForumRepositories;
using wiki_backend.Models;
using wiki_backend.Models.ForumModels;

namespace IntegrationTests.ForumRepositoriesTests;

[TestFixture]
public class ForumPostRepositoryTests2 : IntegrationTestBase
{
    private ForumPostRepository _repository;

    [SetUp]
    public void SetUp()
    {
        ResetDatabase(); // Ensure a clean database for each test
        _repository = new ForumPostRepository(DbContext);
    }
    
    [Test]
    public async Task AddForumPostAsync_ShouldThrowException_WhenTitleIsEmpty()
    {
        // Arrange
        var post = new ForumPost { PostTitle = "", Content = "New Content" };

        // Act & Assert
        Assert.ThrowsAsync<DbUpdateException>(async () => await _repository.AddForumPostAsync(post));
    }

    [Test]
    public async Task AddForumPostAsync_ShouldThrowException_WhenContentIsEmpty()
    {
        // Arrange
        var post = new ForumPost { PostTitle = "New Post", Content = "" };

        // Act & Assert
        Assert.ThrowsAsync<DbUpdateException>(async () => await _repository.AddForumPostAsync(post));
    }

    [Test]
    public async Task AddForumPostAsync_ShouldThrowException_WhenPostIsNull()
    {
        // Act & Assert
        Assert.ThrowsAsync<NullReferenceException>(async () => await _repository.AddForumPostAsync(null));
    }
    

    [Test]
    public async Task UpdateForumPostAsync_ShouldThrowException_WhenPostIsNull()
    {
        // Act & Assert
        Assert.ThrowsAsync<NullReferenceException>(async () => await _repository.UpdateForumPostAsync(null, null));
    }

    [Test]
    public async Task DeleteForumPostAsync_ShouldNotThrowException_WhenPostDoesNotExist()
    {
        // Arrange
        var nonExistentId = Guid.NewGuid();

        // Act & Assert
        Assert.DoesNotThrowAsync(async () => await _repository.DeleteForumPostAsync(nonExistentId));
    }
    private async Task AddSampleForumPostsToDatabase()
    {
        var forumTopic = new ForumTopic
        {
            Title = "Test Topic",
            Description = "Test Description",
            Slug = "test-topic"
        };
        await DbContext.ForumTopics.AddAsync(forumTopic);

        var userProfiles = new List<UserProfile>
        {
            new UserProfile { UserName = "User1" },
            new UserProfile { UserName = "User2" },
            new UserProfile { UserName = "User3" }
        };
        await DbContext.UserProfiles.AddRangeAsync(userProfiles);

        var posts = new List<ForumPost>
        {
            new ForumPost { PostTitle = "Post 1", Content = "Content for Post 1", Slug = "post-1", UserId = userProfiles[0].Id, UserName = userProfiles[0]?.UserName, ForumTopicId = forumTopic.Id },
            new ForumPost { PostTitle = "Post 2", Content = "Content for Post 2", Slug = "post-2", UserId = userProfiles[1].Id, UserName = userProfiles[1].UserName, ForumTopicId = forumTopic.Id },
            new ForumPost { PostTitle = "Post 3", Content = "Content for Post 3", Slug = "post-3", UserId = userProfiles[2].Id, UserName = userProfiles[2].UserName, ForumTopicId = forumTopic.Id }
        };

        await DbContext.ForumPosts.AddRangeAsync(posts);
        await DbContext.SaveChangesAsync();
    }
}