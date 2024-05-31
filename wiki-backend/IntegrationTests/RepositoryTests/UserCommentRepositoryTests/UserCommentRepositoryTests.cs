using Microsoft.EntityFrameworkCore;
using wiki_backend.DatabaseServices.Repositories;
using wiki_backend.Models;

namespace IntegrationTests.Repositories
{
    [TestFixture]
    public class UserCommentRepositoryTests : IntegrationTestBase
    {
        private UserCommentRepository _repository;

        [SetUp]
        public void SetUp()
        {
            ResetDatabase();
            _repository = new UserCommentRepository(DbContext);
        }

        [Test]
        public async Task GetByIdAsync_ShouldReturnUserComment()
        {
            // Arrange
            var wikiPage = new WikiPage {Title = "test page"};
            DbContext.WikiPages.Add(wikiPage);
            var userProfile = new UserProfile { UserName = "testuser", DisplayName = "Test User" };
            DbContext.UserProfiles.Add(userProfile);
            await DbContext.SaveChangesAsync();

            var userComment = new UserComment { Content = "Test Comment", UserProfileId = userProfile.Id, WikiPageId = wikiPage.Id};
            DbContext.UserComments.Add(userComment);
            await DbContext.SaveChangesAsync();

            // Act
            var result = await _repository.GetByIdAsync(userComment.Id);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(userComment.Content, result.Content);
        }

        [Test]
        public async Task AddAsync_ShouldAddUserComment()
        {
            // Arrange
            var wikiPage = new WikiPage {Title = "test page"};
            DbContext.WikiPages.Add(wikiPage);
            var userProfile = new UserProfile { UserName = GetRandomizedString("testuser"), DisplayName = "Test User" };
            DbContext.UserProfiles.Add(userProfile);
            await DbContext.SaveChangesAsync();

            var userComment = new UserComment { Content = "Test Comment", UserProfileId = userProfile.Id, WikiPageId = wikiPage.Id};

            // Act
            await _repository.AddAsync(userComment);

            // Assert
            var result = await _repository.GetByIdAsync(userComment.Id);
            Assert.IsNotNull(result);
            Assert.AreEqual(userComment.Content, result.Content);
        }

        [Test]
        public async Task AddAsync_ShouldAddReplyToComment()
        {
            // Arrange
            var wikiPage = new WikiPage {Title = "test page"};
            DbContext.WikiPages.Add(wikiPage);
            var userProfile = new UserProfile { UserName = GetRandomizedString("testuser"), DisplayName = "Test User" };
            DbContext.UserProfiles.Add(userProfile);
            await DbContext.SaveChangesAsync();

            var parentComment = new UserComment { Content = "Parent Comment", UserProfileId = userProfile.Id, WikiPageId = wikiPage.Id};
            DbContext.UserComments.Add(parentComment);
            await DbContext.SaveChangesAsync();

            var replyComment = new UserComment { Content = "Reply Comment", UserProfileId = userProfile.Id, ReplyToCommentId = parentComment.Id, WikiPageId = wikiPage.Id};

            // Act
            await _repository.AddAsync(replyComment);

            // Assert
            var result = await _repository.GetByIdAsync(replyComment.Id);
            Assert.IsNotNull(result);
            Assert.AreEqual(replyComment.Content, result.Content);
            Assert.AreEqual(parentComment.Id, result.ReplyToCommentId);
        }

        [Test]
        public async Task UpdateAsync_ShouldUpdateUserComment()
        {
            // Arrange
            var wikiPage = new WikiPage {Title = "test page"};
            DbContext.WikiPages.Add(wikiPage);
            var userProfile = new UserProfile { UserName = GetRandomizedString("testuser"), DisplayName = "Test User" };
            DbContext.UserProfiles.Add(userProfile);
            await DbContext.SaveChangesAsync();

            var userComment = new UserComment { Content = "Original Comment", UserProfileId = userProfile.Id, WikiPageId = wikiPage.Id};
            DbContext.UserComments.Add(userComment);
            await DbContext.SaveChangesAsync();

            var updatedContent = "Updated Comment";

            // Act
            await _repository.UpdateAsync(userComment.Id, updatedContent);

            // Assert
            var result = await _repository.GetByIdAsync(userComment.Id);
            Assert.IsNotNull(result);
            Assert.AreEqual(updatedContent, result.Content);
            Assert.IsTrue(result.IsEdited);
        }

        [Test]
        public void UpdateAsync_ShouldThrowException_WhenCommentNotFound()
        {
            // Arrange
            var nonExistentId = Guid.NewGuid();
            var updatedContent = "Updated Comment";

            // Act & Assert
            var ex = Assert.ThrowsAsync<InvalidOperationException>(() => _repository.UpdateAsync(nonExistentId, updatedContent));
            Assert.That(ex.Message, Is.EqualTo($"Comment with ID {nonExistentId} not found."));
        }

        [Test]
        public async Task DeleteAsync_ShouldRemoveUserComment()
        {
            // Arrange
            var wikiPage = new WikiPage {Title = "test page"};
            DbContext.WikiPages.Add(wikiPage);
            var userProfile = new UserProfile { UserName = GetRandomizedString("testuser"), DisplayName = "Test User" };
            DbContext.UserProfiles.Add(userProfile);
            await DbContext.SaveChangesAsync();

            var userComment = new UserComment { Content = "Test Comment", UserProfileId = userProfile.Id, WikiPageId = wikiPage.Id};
            DbContext.UserComments.Add(userComment);
            await DbContext.SaveChangesAsync();

            // Act
            await _repository.DeleteAsync(userComment.Id);

            // Assert
            var result = await _repository.GetByIdAsync(userComment.Id);
            Assert.IsNull(result);
        }

        [Test]
        public async Task GetByIdAsync_ShouldReturnNull_WhenUserCommentDoesNotExist()
        {
            // Act
            var result = await _repository.GetByIdAsync(Guid.NewGuid());

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public async Task AddAsync_ShouldHandleNullReplyToCommentId()
        {
            // Arrange
            var wikiPage = new WikiPage {Title = "test page"};
            DbContext.WikiPages.Add(wikiPage);
            var userProfile = new UserProfile { UserName = GetRandomizedString("testuser"), DisplayName = "Test User" };
            DbContext.UserProfiles.Add(userProfile);
            await DbContext.SaveChangesAsync();

            var userComment = new UserComment { Content = "Test Comment", UserProfileId = userProfile.Id, ReplyToCommentId = null, WikiPageId = wikiPage.Id};

            // Act
            await _repository.AddAsync(userComment);

            // Assert
            var result = await _repository.GetByIdAsync(userComment.Id);
            Assert.IsNotNull(result);
            Assert.IsNull(result.ReplyToCommentId);
        }

        [Test]
        public async Task DeleteAsync_ShouldDoNothing_WhenUserCommentDoesNotExist()
        {
            // Arrange
            var nonExistentId = Guid.NewGuid();

            // Act
            await _repository.DeleteAsync(nonExistentId);

            // Assert
            // No exception should be thrown and the count of user comments should remain the same
            var count = await DbContext.UserComments.CountAsync();
            Assert.AreEqual(0, count);
        }
    }
}
