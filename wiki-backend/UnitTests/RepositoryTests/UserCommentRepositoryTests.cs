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
        var commentId = Guid.NewGuid();
        var profileId = Guid.NewGuid();
        var testUserComment = new UserComment
        {
            Id = commentId,
            Content = "Test comment",
            UserProfileId = profileId,
            UserProfile = new UserProfile { Id = profileId, UserName = "test_user" }
        };

        _wikiDbContext.UserComments.Add(testUserComment);
        await _wikiDbContext.SaveChangesAsync();

        // Act
        var result = await _userCommentRepository.GetByIdAsync(commentId);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Id, Is.EqualTo(testUserComment.Id));
        Assert.That(result.Content, Is.EqualTo(testUserComment.Content));
        Assert.That(result.UserProfileId, Is.EqualTo(testUserComment.UserProfileId));
        Assert.That(result.UserProfile.UserName, Is.EqualTo(testUserComment.UserProfile.UserName));
    }
    
    [Test]
    public async Task AddAsync_ShouldAddCommentToDatabase()
    {
        // Arrange
        var articleId = Guid.NewGuid();
        var profileId = Guid.NewGuid();
        var testComment = new UserComment
        {
            Content = "Test comment",
            UserProfileId = profileId,
            WikiPageId = articleId,
            PostDate = DateTime.Now,
            IsEdited = false
        };

        // Act
        await _userCommentRepository.AddAsync(testComment);
        await _wikiDbContext.SaveChangesAsync();

        // Assert
        var savedComment = await _wikiDbContext.UserComments.FirstOrDefaultAsync(c => c.Content == "Test comment");
        Assert.That(savedComment, Is.Not.Null);
        Assert.That(savedComment.Content, Is.EqualTo(testComment.Content));
    }
    
    [Test]
    public async Task UpdateAsync_ShouldUpdateComment()
    {
        // Arrange
        var articleId = Guid.NewGuid();
        var profileId = Guid.NewGuid();
        var testComment = new UserComment
        {
            Content = "Original comment",
            UserProfileId = profileId,
            WikiPageId = articleId,
            PostDate = DateTime.Now,
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
        Assert.That(updatedComment, Is.Not.Null);
        Assert.That(updatedComment.Content, Is.EqualTo(updatedContent));
        Assert.That(updatedComment.IsEdited, Is.True);
    }
    
    [Test]
    public async Task UpdateAsync_InvalidId_ShouldThrowException()
    {
        // Arrange
        var invalidCommentId = Guid.NewGuid();

        // Act & Assert
        var exception = Assert.ThrowsAsync<InvalidOperationException>(async () =>
        {
            await _userCommentRepository.UpdateAsync(invalidCommentId, "Updated content");
            await _wikiDbContext.SaveChangesAsync();
        });

        Assert.That(exception.Message, Is.EqualTo($"Comment with ID {invalidCommentId} not found."));
    }

    [Test]
    public async Task DeleteAsync_ShouldDeleteComment()
    {
        // Arrange
        var articleId = Guid.NewGuid();
        var profileId = Guid.NewGuid();
        var testComment = new UserComment
        {
            Content = "Comment to delete",
            UserProfileId = profileId,
            WikiPageId = articleId,
            PostDate = DateTime.Now,
            IsEdited = false
        };
        await _wikiDbContext.UserComments.AddAsync(testComment);
        await _wikiDbContext.SaveChangesAsync();

        // Act
        await _userCommentRepository.DeleteAsync(testComment.Id);
        await _wikiDbContext.SaveChangesAsync();

        // Assert
        var deletedComment = await _wikiDbContext.UserComments.FindAsync(testComment.Id);
        Assert.That(deletedComment, Is.Null);
    }
}