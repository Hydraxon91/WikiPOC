using NUnit.Framework;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using wiki_backend.DatabaseServices;
using wiki_backend.DatabaseServices.Repositories.ForumRepositories;
using wiki_backend.Models;
using wiki_backend.Models.ForumModels;

namespace UnitTests.RepositoryTests
{
    [TestFixture]
    public class ForumCommentRepositoryTests
    {
        private ForumCommentRepository _forumCommentRepository;
        private WikiDbContext _wikiDbContext;

        [SetUp]
        public void Setup()
        {
            var databaseName = $"TestDatabase_{TestContext.CurrentContext.Test.Name}";
            var options = new DbContextOptionsBuilder<WikiDbContext>()
                .UseInMemoryDatabase(databaseName: databaseName)
                .Options;

            _wikiDbContext = new WikiDbContext(options, configuration: null);
            _wikiDbContext.Database.EnsureCreated();
            _wikiDbContext.Database.EnsureDeleted();
            _forumCommentRepository = new ForumCommentRepository(_wikiDbContext);
        }

        [TearDown]
        public void TearDown()
        {
            _wikiDbContext.Database.EnsureDeleted();
            _wikiDbContext.Dispose();
        }

        [Test]
        public async Task AddAsync_ShouldAddCommentToDatabase()
        {
            // Arrange
            var userProfileId = Guid.NewGuid();
            var forumPostId = Guid.NewGuid();
            var comment = new ForumComment
            {
                Id = Guid.NewGuid(),
                Content = "Test comment",
                UserProfileId = userProfileId,
                ForumPostId = forumPostId,
                PostDate = DateTime.UtcNow,
                IsReply = false
            };

            // Act
            await _forumCommentRepository.AddAsync(comment);

            // Assert
            var commentInDb = await _wikiDbContext.ForumComments.FirstOrDefaultAsync(c => c.Id == comment.Id);
            Assert.NotNull(commentInDb);
            Assert.AreEqual("Test comment", commentInDb.Content);
            Assert.AreEqual(userProfileId, commentInDb.UserProfileId);
            Assert.AreEqual(forumPostId, commentInDb.ForumPostId);
            Assert.IsFalse(commentInDb.IsReply);
        }
        
        [Test]
        public async Task GetByIdAsync_ShouldReturnCorrectComment()
        {
            // Arrange
            var userProfileId = Guid.NewGuid();
            var userProfile = new UserProfile
            {
                Id = userProfileId,
                UserName = "user"
            };
            await _wikiDbContext.UserProfiles.AddAsync(userProfile);
            await _wikiDbContext.SaveChangesAsync();
            
            var forumPostId = Guid.NewGuid();
            var commentId = Guid.NewGuid();
            var comment = new ForumComment
            {
                Id = commentId,
                Content = "Test comment",
                UserProfileId = userProfileId,
                ForumPostId = forumPostId,
                PostDate = DateTime.UtcNow,
                IsReply = false
            };
            await _wikiDbContext.ForumComments.AddAsync(comment);
            await _wikiDbContext.SaveChangesAsync();

            // Act
            var retrievedComment = await _forumCommentRepository.GetByIdAsync(commentId);

            // Assert
            Assert.NotNull(retrievedComment);
            Assert.AreEqual(commentId, retrievedComment.Id);
            Assert.AreEqual("Test comment", retrievedComment.Content);
            Assert.AreEqual(userProfileId, retrievedComment.UserProfileId);
            Assert.AreEqual(forumPostId, retrievedComment.ForumPostId);
            Assert.IsFalse(retrievedComment.IsReply);
        }


        [Test]
        public async Task UpdateAsync_ShouldUpdateCommentContent()
        {
            // Arrange
            var commentId = Guid.NewGuid();
            var originalComment = new ForumComment
            {
                Id = commentId,
                Content = "Original content",
                UserProfileId = Guid.NewGuid(),
                ForumPostId = Guid.NewGuid(),
                PostDate = DateTime.UtcNow,
                IsReply = false
            };
            await _wikiDbContext.ForumComments.AddAsync(originalComment);
            await _wikiDbContext.SaveChangesAsync();

            // Act
            await _forumCommentRepository.UpdateAsync(commentId, "Updated content");

            // Assert
            var updatedComment = await _wikiDbContext.ForumComments.FindAsync(commentId);
            Assert.NotNull(updatedComment);
            Assert.AreEqual("Updated content", updatedComment.Content);
            Assert.IsTrue(updatedComment.IsEdited);
        }

        [Test]
        public async Task DeleteAsync_ShouldDeleteCommentFromDatabase()
        {
            // Arrange
            var commentId = Guid.NewGuid();
            var comment = new ForumComment
            {
                Id = commentId,
                Content = "Test comment",
                UserProfileId = Guid.NewGuid(),
                ForumPostId = Guid.NewGuid(),
                PostDate = DateTime.UtcNow,
                IsReply = false
            };
            await _wikiDbContext.ForumComments.AddAsync(comment);
            await _wikiDbContext.SaveChangesAsync();

            // Act
            await _forumCommentRepository.DeleteAsync(commentId);

            // Assert
            var deletedComment = await _wikiDbContext.ForumComments.FindAsync(commentId);
            Assert.Null(deletedComment);
        }
    }
}
