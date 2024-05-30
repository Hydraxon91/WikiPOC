using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using wiki_backend.DatabaseServices.Repositories;
using wiki_backend.Models;

namespace IntegrationTests.Repositories
{
    [TestFixture]
    public class UserProfileRepositoryTests : IntegrationTestBase
    {
        private UserProfileRepository _repository;

        [SetUp]
        public void SetUp()
        {
            ResetDatabase();
            _repository = new UserProfileRepository(DbContext);
        }

        [Test]
        public async Task GetByIdAsync_ShouldReturnUserProfile()
        {
            // Arrange
            var userProfile = new UserProfile { UserName = "testuser", DisplayName = "Test User" };
            DbContext.UserProfiles.Add(userProfile);
            await DbContext.SaveChangesAsync();

            // Act
            var result = await _repository.GetByIdAsync(userProfile.Id);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(userProfile.UserName, result.UserName);
        }

        [Test]
        public async Task GetByUsernameAsync_ShouldReturnUserProfile()
        {
            // Arrange
            var userProfile = new UserProfile { UserName = "testuser", DisplayName = "Test User" };
            DbContext.UserProfiles.Add(userProfile);
            await DbContext.SaveChangesAsync();

            // Act
            var result = await _repository.GetByUsernameAsync(userProfile.UserName);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(userProfile.UserName, result.UserName);
        }

        [Test]
        public async Task GetByUserIdAsync_ShouldReturnUserProfile()
        {
            // Arrange
            var userProfile = new UserProfile { UserId = Guid.NewGuid().ToString(), UserName = "testuser", DisplayName = "Test User" };
            DbContext.UserProfiles.Add(userProfile);
            await DbContext.SaveChangesAsync();

            // Act
            var result = await _repository.GetByUserIdAsync(userProfile.UserId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(userProfile.UserId, result.UserId);
        }

        [Test]
        public async Task UpdateAsync_ShouldUpdateUserProfile()
        {
            // Arrange
            var userProfile = new UserProfile { UserName = "testuser", DisplayName = "Test User" };
            DbContext.UserProfiles.Add(userProfile);
            await DbContext.SaveChangesAsync();

            var updatedProfile = new UserProfile { DisplayName = "Updated User" };
            IFormFile? profilePictureFile = null; // If you have a file to test with, replace this with a mock IFormFile

            // Act
            await _repository.UpdateAsync(userProfile.Id, updatedProfile, profilePictureFile);

            // Assert
            var result = await _repository.GetByIdAsync(userProfile.Id);
            Assert.IsNotNull(result);
            Assert.AreEqual(updatedProfile.DisplayName, result.DisplayName);
        }

        [Test]
        public void UpdateAsync_ShouldThrowException_WhenUserProfileNotFound()
        {
            // Arrange
            var nonExistentId = Guid.NewGuid();
            var updatedProfile = new UserProfile { DisplayName = "Updated User" };
            IFormFile? profilePictureFile = null;

            // Act & Assert
            var ex = Assert.ThrowsAsync<InvalidOperationException>(() => _repository.UpdateAsync(nonExistentId, updatedProfile, profilePictureFile));
            Assert.That(ex.Message, Is.EqualTo($"UserProfile with ID {nonExistentId} not found."));
        }

        [Test]
        public async Task DeleteAsync_ShouldRemoveUserProfile()
        {
            // Arrange
            var userProfile = new UserProfile { UserName = "testuser", DisplayName = "Test User" };
            DbContext.UserProfiles.Add(userProfile);
            await DbContext.SaveChangesAsync();

            // Act
            await _repository.DeleteAsync(userProfile.Id);

            // Assert
            var result = await _repository.GetByIdAsync(userProfile.Id);
            Assert.IsNull(result);
        }
        
        [Test]
        public async Task GetByIdAsync_ShouldReturnNull_WhenUserProfileDoesNotExist()
        {
            // Act
            var result = await _repository.GetByIdAsync(Guid.NewGuid());

            // Assert
            Assert.IsNull(result);
        }
        
        [Test]
        public async Task GetByUsernameAsync_ShouldReturnNull_WhenUserProfileDoesNotExist()
        {
            // Act
            var result = await _repository.GetByUsernameAsync("nonexistentuser");

            // Assert
            Assert.IsNull(result);
        }
        
        [Test]
        public async Task GetByUserIdAsync_ShouldReturnNull_WhenUserProfileDoesNotExist()
        {
            // Act
            var result = await _repository.GetByUserIdAsync(Guid.NewGuid().ToString());

            // Assert
            Assert.IsNull(result);
        }
        
        [Test]
        public async Task UpdateAsync_ShouldNotChangeOtherFields()
        {
            // Arrange
            var userProfile = new UserProfile { UserName = "testuser", DisplayName = "Test User" };
            DbContext.UserProfiles.Add(userProfile);
            await DbContext.SaveChangesAsync();

            var updatedProfile = new UserProfile { DisplayName = "Updated User" };
            IFormFile? profilePictureFile = null;

            // Act
            await _repository.UpdateAsync(userProfile.Id, updatedProfile, profilePictureFile);

            // Assert
            var result = await _repository.GetByIdAsync(userProfile.Id);
            Assert.IsNotNull(result);
            Assert.AreEqual("testuser", result.UserName); // Ensure UserName was not changed
        }
        
        [Test]
        public async Task DeleteAsync_ShouldDoNothing_WhenUserProfileDoesNotExist()
        {
            // Arrange
            var nonExistentId = Guid.NewGuid();

            // Act
            await _repository.DeleteAsync(nonExistentId);

            // Assert
            // No exception should be thrown and the count of user profiles should remain the same
            var count = await DbContext.UserProfiles.CountAsync();
            Assert.AreEqual(0, count);
        }
    }
}
