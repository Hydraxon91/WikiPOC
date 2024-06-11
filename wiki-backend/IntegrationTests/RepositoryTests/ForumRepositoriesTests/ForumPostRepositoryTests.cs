using Microsoft.EntityFrameworkCore;
using wiki_backend.DatabaseServices.Repositories.ForumRepositories;
using wiki_backend.Models;
using wiki_backend.Models.ForumModels;

namespace IntegrationTests.ForumRepositoriesTests;

[TestFixture]
public class ForumPostRepositoryTests : IntegrationTestBase
{
    private ForumPostRepository _repository;

    [SetUp]
    public void SetUp()
    {
        ResetDatabase(); // Ensure a clean database for each test
        _repository = new ForumPostRepository(DbContext);
    }

    [Test]
    public async Task GetAllForumPostTitlesAsync_ShouldReturnAllPostTitles()
    {
        // Arrange
        await AddSampleForumPostsToDatabase();
        var expectedPostTitles = new List<string> { "Post 1", "Post 2", "Post 3" };

        // Act
        var result = await _repository.GetAllForumPostTitlesAsync();

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(expectedPostTitles.Count, result.Count());
        CollectionAssert.AreEquivalent(expectedPostTitles, result);
    }

    [Test]
    public async Task GetForumPostByIdAsync_ShouldReturnPost()
    {
        // Arrange
        await AddSampleForumPostsToDatabase();
        var topic = await DbContext.ForumTopics.FirstOrDefaultAsync();
        var userprofile = await DbContext.UserProfiles.FirstOrDefaultAsync();
        var postId = Guid.NewGuid();
        var post = new ForumPost { Id = postId, PostTitle = "New Post", Content = "New Content", Slug = "new-post", UserName = userprofile.UserName, UserId = userprofile.Id, ForumTopicId = topic.Id};
        DbContext.ForumPosts.Add(post);
        await DbContext.SaveChangesAsync();

        // Act
        var result = await _repository.GetForumPostByIdAsync(postId);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(postId, result.Id);
        Assert.AreEqual(post.PostTitle, result.PostTitle);
        Assert.AreEqual(post.Content, result.Content);
    }

    [Test]
    public async Task GetForumPostBySlugAsync_ShouldReturnPost()
    {
        // Arrange
        await AddSampleForumPostsToDatabase();
        var topic = await DbContext.ForumTopics.FirstOrDefaultAsync();
        var userprofile = await DbContext.UserProfiles.FirstOrDefaultAsync();
        var postSlug = "sample-post";
        var post = new ForumPost { PostTitle = "New Post", Content = "New Content", Slug = postSlug, UserName = userprofile.UserName, UserId = userprofile.Id, ForumTopicId = topic.Id};
        DbContext.ForumPosts.Add(post);
        await DbContext.SaveChangesAsync();

        // Act
        var result = await _repository.GetForumPostBySlugAsync(postSlug);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(postSlug, result.Slug);
    }

    [Test]
    public async Task AddForumPostAsync_ShouldAddPost()
    {
        // Arrange
        await AddSampleForumPostsToDatabase();
        var topic = await DbContext.ForumTopics.FirstOrDefaultAsync();
        var userprofile = await DbContext.UserProfiles.FirstOrDefaultAsync();
        var post = new ForumPost { PostTitle = "New Post", Content = "New Content", UserName = userprofile.UserName, UserId = userprofile.Id, ForumTopicId = topic.Id};

        // Act
        await _repository.AddForumPostAsync(post);

        // Assert
        var addedPost = await DbContext.ForumPosts.FirstOrDefaultAsync(p => p.PostTitle == "New Post");
        Assert.IsNotNull(addedPost);
        Assert.AreEqual("new-post", addedPost.Slug); // Ensure slug is generated correctly
        Assert.AreEqual(post.Content, addedPost.Content);
    }

    [Test]
    public async Task UpdateForumPostAsync_ShouldUpdatePost()
    {
        // Arrange
        await AddSampleForumPostsToDatabase();
        var topic = await DbContext.ForumTopics.FirstOrDefaultAsync();
        var userprofile = await DbContext.UserProfiles.FirstOrDefaultAsync();
        var existingPost = new ForumPost { PostTitle = "New Post", Content = "New Content", Slug = "new-post", UserName = userprofile.UserName, UserId = userprofile.Id, ForumTopicId = topic.Id};
        DbContext.ForumPosts.Add(existingPost);
        await DbContext.SaveChangesAsync();

        existingPost.PostTitle = "Updated Title";
        existingPost.Content = "Updated Content";

        // Act
        await _repository.UpdateForumPostAsync(existingPost, existingPost);

        // Assert
        var updatedPost = await DbContext.ForumPosts.FirstOrDefaultAsync(p => p.PostTitle == "Updated Title");
        Assert.IsNotNull(updatedPost);
        Assert.AreEqual("updated-title", updatedPost.Slug); // Ensure slug is updated correctly
        Assert.AreEqual("Updated Content", updatedPost.Content);
    }

    [Test]
    public async Task DeleteForumPostAsync_ShouldDeletePost()
    {
        // Arrange
        await AddSampleForumPostsToDatabase();
        var topic = await DbContext.ForumTopics.FirstOrDefaultAsync();
        var userprofile = await DbContext.UserProfiles.FirstOrDefaultAsync();
        var existingPost = new ForumPost { PostTitle = "New Post", Content = "New Content", Slug = "new-post", UserName = userprofile.UserName, UserId = userprofile.Id, ForumTopicId = topic.Id};
        DbContext.ForumPosts.Add(existingPost);
        await DbContext.SaveChangesAsync();

        // Act
        await _repository.DeleteForumPostAsync(existingPost.Id);

        // Assert
        var deletedPost = await DbContext.ForumPosts.FindAsync(existingPost.Id);
        Assert.IsNull(deletedPost);
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
