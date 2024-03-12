using Microsoft.EntityFrameworkCore;
using wiki_backend.DatabaseServices;
using wiki_backend.DatabaseServices.Repositories;
using wiki_backend.Models;

namespace UnitTests.RepositoryTests;
[TestFixture]
public class UserCommentRepositoryTests
{
    private UserCommentRepository _userCommentRepository;
    private WikiDbContext _wikiDbContext;

    [SetUp]
    public void Setup()
    {
        // Generate a unique database name based on the test name
        var databaseName = $"TestDatabase_{TestContext.CurrentContext.Test.Name}";
        // Use an in-memory database for testing
        var options = new DbContextOptionsBuilder<WikiDbContext>()
            .UseInMemoryDatabase(databaseName: databaseName)
            .Options;

        // Use AddDbContext to configure the WikiDbContext
        _wikiDbContext = new WikiDbContext(options, configuration: null); 
        _wikiDbContext.Database.EnsureCreated(); // Ensure the in-memory database is created
        _wikiDbContext.Database.EnsureDeleted();
        _userCommentRepository = new UserCommentRepository(_wikiDbContext);
    }
    
    [TearDown]
    public void TearDown()
    {
        // Dispose the context to release the in-memory database
        _wikiDbContext.Database.EnsureDeleted();
        _wikiDbContext.Dispose();
    }
    
    [Test]
    public async Task GetByIdAsync_ShouldReturnUserCommentWhenExists()
    {
        // Arrange
        var testUserComment = new UserComment
        {
            Id = 1,
            Content = "Test comment",
            UserProfileId = 1,
            UserProfile = new UserProfile { Id = 1, UserName = "test_user" }
        };

        _wikiDbContext.UserComments.Add(testUserComment);
        await _wikiDbContext.SaveChangesAsync();

        // Act
        var result = await _userCommentRepository.GetByIdAsync(1);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(testUserComment.Id, result.Id);
        Assert.AreEqual(testUserComment.Content, result.Content);
        Assert.AreEqual(testUserComment.UserProfileId, result.UserProfileId);
        Assert.AreEqual(testUserComment.UserProfile.UserName, result.UserProfile.UserName);
    }
    
    [Test]
    public async Task AddAsync_ShouldAddCommentToDatabase()
    {
        // Arrange
        var testComment = new UserComment
        {
            Content = "Test comment",
            UserProfileId = 1,
            WikiPageId = 1,
            PostDate = DateTime.Now,
            IsReply = false,
            IsEdited = false
        };

        // Act
        await _userCommentRepository.AddAsync(testComment);
        await _wikiDbContext.SaveChangesAsync();

        // Assert
        var savedComment = await _wikiDbContext.UserComments.FirstOrDefaultAsync(c => c.Content == "Test comment");
        Assert.IsNotNull(savedComment);
        Assert.AreEqual(testComment.Content, savedComment.Content);
    }
    
    [Test]
    public async Task UpdateAsync_ShouldUpdateComment()
    {
        // Arrange
        var testComment = new UserComment
        {
            Content = "Original comment",
            UserProfileId = 1,
            WikiPageId = 1,
            PostDate = DateTime.Now,
            IsReply = false,
            IsEdited = false
        };
        await _wikiDbContext.UserComments.AddAsync(testComment);
        await _wikiDbContext.SaveChangesAsync();

        var updatedContent = "Updated comment";

        // Act
        await _userCommentRepository.UpdateAsync(testComment.Id, updatedContent);
        await _wikiDbContext.SaveChangesAsync();

        // Assert
        var updatedComment = await _wikiDbContext.UserComments.FindAsync(testComment.Id);
        Assert.IsNotNull(updatedComment);
        Assert.AreEqual(updatedContent, updatedComment.Content);
        Assert.IsTrue(updatedComment.IsEdited);
    }
    
    [Test]
    public async Task UpdateAsync_InvalidId_ShouldThrowException()
    {
        // Arrange
        var invalidCommentId = 999;

        // Act & Assert
        var exception = Assert.ThrowsAsync<InvalidOperationException>(async () =>
        {
            await _userCommentRepository.UpdateAsync(invalidCommentId, "Updated content");
            await _wikiDbContext.SaveChangesAsync();
        });

        Assert.AreEqual($"Comment with ID {invalidCommentId} not found.", exception.Message);
    }

    [Test]
    public async Task DeleteAsync_ShouldDeleteComment()
    {
        // Arrange
        var testComment = new UserComment
        {
            Content = "Comment to delete",
            UserProfileId = 1,
            WikiPageId = 1,
            PostDate = DateTime.Now,
            IsReply = false,
            IsEdited = false
        };
        await _wikiDbContext.UserComments.AddAsync(testComment);
        await _wikiDbContext.SaveChangesAsync();

        // Act
        await _userCommentRepository.DeleteAsync(testComment.Id);
        await _wikiDbContext.SaveChangesAsync();

        // Assert
        var deletedComment = await _wikiDbContext.UserComments.FindAsync(testComment.Id);
        Assert.IsNull(deletedComment);
    }
}