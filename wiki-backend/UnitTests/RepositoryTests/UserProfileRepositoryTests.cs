using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using wiki_backend.DatabaseServices;
using wiki_backend.DatabaseServices.Repositories;
using wiki_backend.Models;
using wiki_backend.Services.Settings;

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
        _wikiDbContext = new WikiDbContext(options, configuration: null!); 
        _wikiDbContext.Database.EnsureCreated(); // Ensure the in-memory database is created
        _wikiDbContext.Database.EnsureDeleted();
        var storageSettings = Options.Create(new StorageSettings { PicturesPath = "test_path" });
        _userProfileRepository = new UserProfileRepository(_wikiDbContext, storageSettings);
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
        var userProfileId = Guid.NewGuid();
        var testUserProfile = new UserProfile { Id = userProfileId, UserName = "testuser" };
        _wikiDbContext.UserProfiles.Add(testUserProfile);
        await _wikiDbContext.SaveChangesAsync();

        // Act
        var result = await _userProfileRepository.GetByIdAsync(userProfileId);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Id, Is.EqualTo(testUserProfile.Id));
    }
    
    [Test]
    public async Task GetByUsernameAsync_ExistingUsername_ShouldReturnUserProfile()
    {
        // Arrange
        var userProfileId = Guid.NewGuid();
        var testUserProfile = new UserProfile { Id = userProfileId, UserName = "testuser" };
        _wikiDbContext.UserProfiles.Add(testUserProfile);
        await _wikiDbContext.SaveChangesAsync();

        // Act
        var result = await _userProfileRepository.GetByUsernameAsync("testuser");

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.UserName, Is.EqualTo(testUserProfile.UserName));
    }

    [Test]
    public async Task GetByUserIdAsync_ExistingUserId_ShouldReturnUserProfile()
    {
        // Arrange
        var userProfileId = Guid.NewGuid();
        var testUserProfile = new UserProfile { Id = userProfileId, UserId = "testuserid" };
        _wikiDbContext.UserProfiles.Add(testUserProfile);
        await _wikiDbContext.SaveChangesAsync();

        // Act
        var result = await _userProfileRepository.GetByUserIdAsync("testuserid");

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.UserId, Is.EqualTo(testUserProfile.UserId));
    }

    [Test]
    public async Task UpdateAsync_ExistingId_ShouldUpdateUserProfile()
    {
        var userProfileId = Guid.NewGuid();
        // Arrange
        var testUserProfile = new UserProfile { Id = userProfileId, UserName = "testuser" };
        _wikiDbContext.UserProfiles.Add(testUserProfile);
        await _wikiDbContext.SaveChangesAsync();

        var updatedProfile = new UserProfile { Id = userProfileId, DisplayName = "Updated Display Name" };

        // Act
        await _userProfileRepository.UpdateAsync(userProfileId, updatedProfile, null);
        await _wikiDbContext.SaveChangesAsync();

        // Assert
        var result = await _wikiDbContext.UserProfiles.FindAsync(userProfileId);
        Assert.That(result, Is.Not.Null);
        Assert.That(result.DisplayName, Is.EqualTo(updatedProfile.DisplayName));
    }

    [Test]
    public async Task UpdateAsync_NonExistingId_ShouldThrowException()
    {
        // Arrange
        var userProfileId = Guid.NewGuid();
        var testUserProfile = new UserProfile { Id = userProfileId, UserName = "testuser" };
        _wikiDbContext.UserProfiles.Add(testUserProfile);
        await _wikiDbContext.SaveChangesAsync();

        var fakeId = Guid.NewGuid();
        var updatedProfile = new UserProfile { Id = fakeId, DisplayName = "Updated Display Name" };

        // Act & Assert
        Assert.ThrowsAsync<InvalidOperationException>(async () => await _userProfileRepository.UpdateAsync(fakeId, updatedProfile, null));
        }
        
        [Test]
        public async Task DeleteAsync_ExistingId_ShouldDeleteUserProfile()
        {
            // Arrange
            var userProfileId = Guid.NewGuid();
            var testUserProfile = new UserProfile { Id = userProfileId, UserName = "testuser" };
            _wikiDbContext.UserProfiles.Add(testUserProfile);
            await _wikiDbContext.SaveChangesAsync();

            // Act
            await _userProfileRepository.DeleteAsync(userProfileId);
            await _wikiDbContext.SaveChangesAsync();

            // Assert
            var result = await _wikiDbContext.UserProfiles.FindAsync(userProfileId);
            Assert.That(result, Is.Null);
        }
}