using Microsoft.EntityFrameworkCore;
using wiki_backend.DatabaseServices;
using wiki_backend.DatabaseServices.Repositories;
using wiki_backend.Models;

namespace UnitTests.RepositoryTests;

[TestFixture]
public class UserProfileRepositoryTests
{
    private UserProfileRepository _userProfileRepository;
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
        _userProfileRepository = new UserProfileRepository(_wikiDbContext);
    }
    
    [TearDown]
    public void TearDown()
    {
        // Dispose the context to release the in-memory database
        _wikiDbContext.Database.EnsureDeleted();
        _wikiDbContext.Dispose();
    }
    
    [Test]
    public async Task GetByIdAsync_ExistingId_ShouldReturnUserProfile()
    {
        // Arrange
        var testUserProfile = new UserProfile { Id = 1, UserName = "testuser" };
        _wikiDbContext.UserProfiles.Add(testUserProfile);
        await _wikiDbContext.SaveChangesAsync();

        // Act
        var result = await _userProfileRepository.GetByIdAsync(1);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(testUserProfile.Id, result.Id);
    }
    
    [Test]
        public async Task GetByUsernameAsync_ExistingUsername_ShouldReturnUserProfile()
        {
            // Arrange
            var testUserProfile = new UserProfile { Id = 1, UserName = "testuser" };
            _wikiDbContext.UserProfiles.Add(testUserProfile);
            await _wikiDbContext.SaveChangesAsync();

            // Act
            var result = await _userProfileRepository.GetByUsernameAsync("testuser");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(testUserProfile.UserName, result.UserName);
        }

        [Test]
        public async Task GetByUserIdAsync_ExistingUserId_ShouldReturnUserProfile()
        {
            // Arrange
            var testUserProfile = new UserProfile { Id = 1, UserId = "testuserid" };
            _wikiDbContext.UserProfiles.Add(testUserProfile);
            await _wikiDbContext.SaveChangesAsync();

            // Act
            var result = await _userProfileRepository.GetByUserIdAsync("testuserid");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(testUserProfile.UserId, result.UserId);
        }

        [Test]
        public async Task UpdateAsync_ExistingId_ShouldUpdateUserProfile()
        {
            // Arrange
            var testUserProfile = new UserProfile { Id = 1, UserName = "testuser" };
            _wikiDbContext.UserProfiles.Add(testUserProfile);
            await _wikiDbContext.SaveChangesAsync();

            var updatedProfile = new UserProfile { Id = 1, DisplayName = "Updated Display Name" };

            // Act
            await _userProfileRepository.UpdateAsync(1, updatedProfile, null);
            await _wikiDbContext.SaveChangesAsync();

            // Assert
            var result = await _wikiDbContext.UserProfiles.FindAsync(1);
            Assert.IsNotNull(result);
            Assert.AreEqual(updatedProfile.DisplayName, result.DisplayName);
        }

        [Test]
        public async Task UpdateAsync_NonExistingId_ShouldThrowException()
        {
            // Arrange
            var testUserProfile = new UserProfile { Id = 1, UserName = "testuser" };
            _wikiDbContext.UserProfiles.Add(testUserProfile);
            await _wikiDbContext.SaveChangesAsync();

            var updatedProfile = new UserProfile { Id = 2, DisplayName = "Updated Display Name" };

            // Act & Assert
            Assert.ThrowsAsync<InvalidOperationException>(async () => await _userProfileRepository.UpdateAsync(2, updatedProfile, null));
        }
        
        [Test]
        public async Task DeleteAsync_ExistingId_ShouldDeleteUserProfile()
        {
            // Arrange
            var testUserProfile = new UserProfile { Id = 1, UserName = "testuser" };
            _wikiDbContext.UserProfiles.Add(testUserProfile);
            await _wikiDbContext.SaveChangesAsync();

            // Act
            await _userProfileRepository.DeleteAsync(1);
            await _wikiDbContext.SaveChangesAsync();

            // Assert
            var result = await _wikiDbContext.UserProfiles.FindAsync(1);
            Assert.IsNull(result);
        }
}