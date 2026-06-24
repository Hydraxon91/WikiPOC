using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using wiki_backend.Controllers;
using wiki_backend.Models;

namespace IntegrationTests.ControllerTests.UserControllers;

public class UserControllerTests : IntegrationTestBase
{
    [TestFixture]
    public class UsersControllerIntegrationTests : IntegrationTestBase
    {
        private UsersController _controller;

        [SetUp]
        public async Task SetUp()
        {
            ResetDatabase(); // Ensure a clean database for each test
            // Create or retrieve the "User" role
            await EnsureUserRoleExistsAsync();
            // Create a test user
            await CreateTestUserAsync("test@example.com", "test2_user", "@Testpassword1");
            // Create a test user
            _controller = CreateUserController();
        }
        
        [Test]
        public async Task GetUsers_ShouldReturnAllUsers()
        {
            // Act
            var result = await _controller.GetUsers();

            // Assert
            var okResult = result as OkObjectResult;
            Assert.That(okResult, Is.Not.Null);
            Assert.That(okResult.StatusCode, Is.EqualTo((int)HttpStatusCode.OK));

            var users = okResult.Value as List<ApplicationUser>;
            Assert.That(users, Is.Not.Null);
            Assert.That(users.Count > 0, Is.True);
        }
        
        [Test]
        public async Task CreateUser_ValidModel_ShouldCreateUser()
        {
            var userId = "userId";
            var userProfile = new UserProfile
            {
                UserName = "new_user",
                UserId = userId
            };
            await DbContext.UserProfiles.AddAsync(userProfile);

            // Arrange
            var newUser = new ApplicationUser
            {
                UserName = "new_user",
                Email = "newuser@example.com",
                ProfileId = userProfile.Id,
                Id = userId
            };

            // Act
            var result = await _controller.CreateUser(newUser);

            // Assert
            var createdResult = result as OkObjectResult;
            Assert.That(createdResult, Is.Not.Null);
            Assert.That(createdResult.StatusCode, Is.EqualTo((int)HttpStatusCode.OK));

            var createdUser = createdResult.Value as ApplicationUser;
            Assert.That(createdUser, Is.Not.Null);
            Assert.That(createdUser.UserName, Is.EqualTo(newUser.UserName));
            Assert.That(createdUser.Email, Is.EqualTo(newUser.Email));

            // Check if the user is created in the database
            var userInDb = await DbContext.Users.FirstOrDefaultAsync(u => u.Id == createdUser.Id);
            Assert.That(userInDb, Is.Not.Null);
            Assert.That(userInDb.UserName, Is.EqualTo(newUser.UserName));
            Assert.That(userInDb.Email, Is.EqualTo(newUser.Email));
        }
        
        [Test]
        public async Task UpdateUser_ExistingIdAndModel_ShouldUpdateUser()
        {
            // Arrange
            var testUser = await DbContext.Users.FirstAsync();
            var userId = testUser.Id;
            var updatedUser = new ApplicationUser
            {
                Id = userId,
                UserName = "updated_user",
                Email = "updateduser@example.com"
            };

            // Act
            var result = await _controller.UpdateUser(userId, updatedUser);

            // Assert
            var okResult = result as OkObjectResult;
            Assert.That(okResult, Is.Not.Null);
            Assert.That(okResult.StatusCode, Is.EqualTo((int)HttpStatusCode.OK));

            var updatedResult = okResult.Value as ApplicationUser;
            Assert.That(updatedResult, Is.Not.Null);
            Assert.That(updatedResult.UserName, Is.EqualTo(updatedUser.UserName));
            Assert.That(updatedResult.Email, Is.EqualTo(updatedUser.Email));

            // Check if the user is updated in the database
            var userInDb = await DbContext.Users.FirstOrDefaultAsync(u => u.Id == userId);
            Assert.That(userInDb, Is.Not.Null);
            Assert.That(userInDb.UserName, Is.EqualTo(updatedUser.UserName));
            Assert.That(userInDb.Email, Is.EqualTo(updatedUser.Email));
        }
        
        [Test]
        public async Task DeleteUser_ExistingId_ShouldDeleteUser()
        {
            // Arrange
            var testUser = await DbContext.Users.FirstAsync();
            var userId = testUser.Id;

            // Act
            var result = await _controller.DeleteUser(userId);

            // Assert
            var okResult = result as OkObjectResult;
            Assert.That(okResult, Is.Not.Null);
            Assert.That(okResult.StatusCode, Is.EqualTo((int)HttpStatusCode.OK));

            var message = okResult.Value as string;
            Assert.That(message, Is.Not.Null);
            Assert.That(message, Is.EqualTo("User deleted successfully"));

            // Check if the user is deleted from the database
            var userInDb = await DbContext.Users.FirstOrDefaultAsync(u => u.Id == userId);
            Assert.That(userInDb, Is.Null);
        }
        
        [Test]
        public async Task CreateUser_NullModel_ShouldReturnBadRequest()
        {
            // Act
            var result = await _controller.CreateUser(null!);

            // Assert
            Assert.That(result, Is.InstanceOf<BadRequestObjectResult>());
        }
        
        [Test]
        public async Task CreateUser_InvalidModel_ShouldReturnBadRequest()
        {
            // Arrange
            var invalidUser = new ApplicationUser();

            // Act
            var result = await _controller.CreateUser(invalidUser);

            // Assert
            Assert.That(result, Is.InstanceOf<BadRequestObjectResult>());
        }
        
        [Test]
        public async Task GetUserById_ExistingId_ShouldReturnUser()
        {
            // Arrange
            var testUser = await DbContext.Users.FirstAsync();
            var userId = testUser.Id;

            // Act
            var result = await _controller.GetUserById(userId);

            // Assert
            var okResult = result as OkObjectResult;
            Assert.That(okResult, Is.Not.Null);
            Assert.That(okResult.StatusCode, Is.EqualTo((int)HttpStatusCode.OK));

            var user = okResult.Value as ApplicationUser;
            Assert.That(user, Is.Not.Null);
            Assert.That(user.Id, Is.EqualTo(testUser.Id));
        }
        
        [Test]
        public async Task GetUserById_NonExistingId_ShouldReturnNotFound()
        {
            // Arrange
            var nonExistingId = "non_existing_id";

            // Act
            var result = await _controller.GetUserById(nonExistingId);

            // Assert
            Assert.That(result, Is.InstanceOf<NotFoundResult>());
        }
        
        [Test]
        public async Task UpdateUser_NonExistingId_ShouldReturnNotFound()
        {
            // Arrange
            var nonExistingId = "non_existing_id";
            var updatedUserData = new ApplicationUser { Id = nonExistingId, UserName = "UpdatedUserName", Email = "updatedemail@example.com" };

            // Act
            var result = await _controller.UpdateUser(nonExistingId, updatedUserData);

            // Assert
            Assert.That(result, Is.InstanceOf<NotFoundResult>());
        }
        
        [Test]
        public async Task DeleteUser_NonExistingId_ShouldReturnNotFound()
        {
            // Arrange
            var nonExistingId = "non_existing_id";

            // Act
            var result = await _controller.DeleteUser(nonExistingId);

            // Assert
            Assert.That(result, Is.InstanceOf<NotFoundResult>());
        }
    }
}
