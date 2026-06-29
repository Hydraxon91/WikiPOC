using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using wiki_backend.DatabaseServices.Repositories;
using wiki_backend.Models;
using wiki_backend.Services.Settings;

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
            var storageSettings = Options.Create(new StorageSettings { PicturesPath = PicturesPathContainer });
            _repository = new UserProfileRepository(DbContext, storageSettings);
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
            Assert.That(result, Is.Not.Null);
            Assert.That(result.UserName, Is.EqualTo(userProfile.UserName));
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
            Assert.That(result, Is.Not.Null);
            Assert.That(result.UserName, Is.EqualTo(userProfile.UserName));
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
            Assert.That(result, Is.Not.Null);
            Assert.That(result.UserId, Is.EqualTo(userProfile.UserId));
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
            Assert.That(result, Is.Not.Null);
            Assert.That(result.DisplayName, Is.EqualTo(updatedProfile.DisplayName));
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
            Assert.That(result, Is.Null);
        }
        
        [Test]
        public async Task GetByIdAsync_ShouldReturnNull_WhenUserProfileDoesNotExist()
        {
            // Act
            var result = await _repository.GetByIdAsync(Guid.NewGuid());

            // Assert
            Assert.That(result, Is.Null);
        }
        
        [Test]
        public async Task GetByUsernameAsync_ShouldReturnNull_WhenUserProfileDoesNotExist()
        {
            // Act
            var result = await _repository.GetByUsernameAsync("nonexistentuser");

            // Assert
            Assert.That(result, Is.Null);
        }
        
        [Test]
        public async Task GetByUserIdAsync_ShouldReturnNull_WhenUserProfileDoesNotExist()
        {
            // Act
            var result = await _repository.GetByUserIdAsync(Guid.NewGuid().ToString());

            // Assert
            Assert.That(result, Is.Null);
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
            Assert.That(result, Is.Not.Null);
            Assert.That(result.UserName, Is.EqualTo("testuser")); // Ensure UserName was not changed
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
            Assert.That(count, Is.EqualTo(0));
        }
    }
}
