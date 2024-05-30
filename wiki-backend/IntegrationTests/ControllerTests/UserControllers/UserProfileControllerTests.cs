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
        Assert.IsNotNull(okResult);
        Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);

        var profile = okResult.Value as UserProfile;
        Assert.IsNotNull(profile);
        Assert.AreEqual(testProfile.Id, profile.Id);
    }
    
    [Test]
    public async Task GetProfileById_NonExistingId_ShouldReturnNotFound()
    {
        // Arrange
        var nonExistingId = Guid.NewGuid();

        // Act
        var result = await _controller.GetProfileById(nonExistingId);

        // Assert
        Assert.IsInstanceOf<NotFoundResult>(result.Result);
    }
    
    [Test]
    public async Task GetProfileByName_ExistingName_ShouldReturnUserProfile()
    {
        // Arrange
        await AddTestUser("UserNameGetbyNameTest");
        var testUserProfile = await DbContext.UserProfiles.FirstAsync();
        var username = testUserProfile.UserName;

        // Act
        var result = await _controller.GetProfileByName(username);

        // Assert
        var okResult = result.Result as OkObjectResult;
        Assert.IsNotNull(okResult);
        Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);

        var userProfile = okResult.Value as UserProfile;
        Assert.IsNotNull(userProfile);
        Assert.AreEqual(testUserProfile.UserName, userProfile.UserName);
    }
    
    [Test]
    public async Task GetProfileByName_NonExistingName_ShouldReturnNotFound()
    {
        // Arrange
        var nonExistingUsername = "non_existing_username";

        // Act
        var result = await _controller.GetProfileByName(nonExistingUsername);

        // Assert
        Assert.IsInstanceOf<NotFoundResult>(result.Result);
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
        Assert.IsNotNull(okResult);
        Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);
    
        var messageObject = okResult.Value as dynamic;
        Assert.IsNotNull(messageObject);
        // Assert.AreEqual("UserProfile updated successfully", messageObject.Message);

        // Check if the user profile is updated in the database
        var userProfileInDb = await DbContext.UserProfiles.FindAsync(profileId);
        Assert.IsNotNull(userProfileInDb);
        Assert.AreEqual(testUserProfile.UserName, userProfileInDb.UserName); // Username should remain unchanged
        Assert.AreEqual(updatedUserProfile.DisplayName, userProfileInDb.DisplayName);
    }

    
    [Test]
    public async Task UpdateUserProfile_InvalidModel_ShouldReturnBadRequest()
    {
        // Act
        var result = await _controller.UpdateUserProfile(Guid.NewGuid(), new UserUpdateForm());

        // Assert
        Assert.IsInstanceOf<BadRequestObjectResult>(result);
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
        Assert.IsNotNull(okResult);
        Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);

        var message = okResult.Value as string;
        Assert.IsNotNull(message);
        Assert.AreEqual("UserProfile deleted successfully", message);

        // Check if the user profile is deleted from the database
        var userProfileInDb = await DbContext.UserProfiles.FindAsync(profileId);
        Assert.IsNull(userProfileInDb);
    }

    [Test]
    public async Task DeleteUserProfile_NonExistingId_ShouldReturnNotFound()
    {
        // Act
        var result = await _controller.DeleteUserProfile(Guid.NewGuid());

        // Assert
        Assert.IsInstanceOf<NotFoundResult>(result);
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