using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using wiki_backend.Controllers;
using wiki_backend.Models;

namespace IntegrationTests.ControllerTests.UserControllers;

[TestFixture]
public class UserProfileControllerTests : IntegrationTestBase
{
    private UserProfileController _controller;
    
    [SetUp]
    public void SetUp()
    {
        ResetDatabase(); // Ensure a clean database for each test
        _controller = CreateUserProfileController();
    }
    [Test]
    public async Task GetProfileById_ExistingId_ShouldReturnProfile()
    {
        // Arrange
        var testProfile = new UserProfile
        {
            UserName = "test_user",
            DisplayName = "Test User",
            ProfilePicture = "test_picture.png"
        };
        await DbContext.UserProfiles.AddAsync(testProfile);
        await DbContext.SaveChangesAsync();

        // Act
        var result = await _controller.GetProfileById(testProfile.Id);

        // Assert
        var okResult = result.Result as OkObjectResult;
        Assert.That(okResult, Is.Not.Null);
        Assert.That(okResult.StatusCode, Is.EqualTo((int)HttpStatusCode.OK));

        var profile = okResult.Value as UserProfile;
        Assert.That(profile, Is.Not.Null);
        Assert.That(profile.Id, Is.EqualTo(testProfile.Id));
    }
    
    [Test]
    public async Task GetProfileById_NonExistingId_ShouldReturnNotFound()
    {
        // Arrange
        var nonExistingId = Guid.NewGuid();

        // Act
        var result = await _controller.GetProfileById(nonExistingId);

        // Assert
        Assert.That(result.Result, Is.InstanceOf<NotFoundResult>());
    }
    
    [Test]
    public async Task GetProfileByName_ExistingName_ShouldReturnUserProfile()
    {
        // Arrange
        await AddTestUser("UserNameGetbyNameTest");
        var testUserProfile = await DbContext.UserProfiles.FirstAsync();
        var username = testUserProfile.UserName;

        // Act
        var result = await _controller.GetProfileByName(username!);

        // Assert
        var okResult = result.Result as OkObjectResult;
        Assert.That(okResult, Is.Not.Null);
        Assert.That(okResult.StatusCode, Is.EqualTo((int)HttpStatusCode.OK));

        var userProfile = okResult.Value as UserProfile;
        Assert.That(userProfile, Is.Not.Null);
        Assert.That(userProfile.UserName, Is.EqualTo(testUserProfile.UserName));
    }
    
    [Test]
    public async Task GetProfileByName_NonExistingName_ShouldReturnNotFound()
    {
        // Arrange
        var nonExistingUsername = "non_existing_username";

        // Act
        var result = await _controller.GetProfileByName(nonExistingUsername);

        // Assert
        Assert.That(result.Result, Is.InstanceOf<NotFoundResult>());
    }
    
    [Test]
    public async Task UpdateUserProfile_ValidModel_ShouldUpdateUserProfile()
    {
        // Arrange
        await AddTestUser("UserNameUpdateTest");
        var testUserProfile = await DbContext.UserProfiles.FirstAsync();
        var profileId = testUserProfile.Id;
        var updatedUserProfile = new UserProfile
        {
            Id = profileId,
            DisplayName = "Updated Display Name"
        };

        // Act
        var result = await _controller.UpdateUserProfile(profileId, new UserUpdateForm
        {
            UserProfile = updatedUserProfile,
            ProfilePictureFile = null // Set profile picture file if required
        });

        // Assert
        var okResult = result as OkObjectResult;
        Assert.That(okResult, Is.Not.Null);
        Assert.That(okResult.StatusCode, Is.EqualTo((int)HttpStatusCode.OK));
    
        var messageObject = okResult.Value as dynamic;
        Assert.That(messageObject, Is.Not.Null);
        // Assert.That(messageObject.Message, Is.EqualTo("UserProfile updated successfully"));

        // Check if the user profile is updated in the database
        var userProfileInDb = await DbContext.UserProfiles.FindAsync(profileId);
        Assert.That(userProfileInDb, Is.Not.Null);
        Assert.That(userProfileInDb.UserName, Is.EqualTo(testUserProfile.UserName)); // Username should remain unchanged
        Assert.That(userProfileInDb.DisplayName, Is.EqualTo(updatedUserProfile.DisplayName));
    }

    
    [Test]
    public async Task UpdateUserProfile_InvalidModel_ShouldReturnBadRequest()
    {
        // Act
        var result = await _controller.UpdateUserProfile(Guid.NewGuid(), new UserUpdateForm());

        // Assert
        Assert.That(result, Is.InstanceOf<BadRequestObjectResult>());
    }
    
    [Test]
    public async Task DeleteUserProfile_ExistingId_ShouldDeleteUserProfile()
    {
        // Arrange
        await AddTestUser("UserNameDeleteTest");
        var testUserProfile = await DbContext.UserProfiles.FirstAsync();
        var profileId = testUserProfile.Id;

        // Act
        var result = await _controller.DeleteUserProfile(profileId);

        // Assert
        var okResult = result as OkObjectResult;
        Assert.That(okResult, Is.Not.Null);
        Assert.That(okResult.StatusCode, Is.EqualTo((int)HttpStatusCode.OK));

        var message = okResult.Value as string;
        Assert.That(message, Is.Not.Null);
        Assert.That(message, Is.EqualTo("UserProfile deleted successfully"));

        // Check if the user profile is deleted from the database
        var userProfileInDb = await DbContext.UserProfiles.FindAsync(profileId);
        Assert.That(userProfileInDb, Is.Null);
    }

    [Test]
    public async Task DeleteUserProfile_NonExistingId_ShouldReturnNotFound()
    {
        // Act
        var result = await _controller.DeleteUserProfile(Guid.NewGuid());

        // Assert
        Assert.That(result, Is.InstanceOf<NotFoundResult>());
    }

    private async Task AddTestUser(string userName)
    {
        var testUserProfile = new UserProfile
        {
            UserName = userName,
            UserId = "testId",
        };

        await DbContext.UserProfiles.AddAsync(testUserProfile);
        await DbContext.SaveChangesAsync();
    }
}