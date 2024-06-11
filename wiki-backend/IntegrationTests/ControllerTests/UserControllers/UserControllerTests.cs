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
            Assert.IsNotNull(okResult);
            Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);

            var users = okResult.Value as List<ApplicationUser>;
            Assert.IsNotNull(users);
            Assert.IsTrue(users.Count > 0);
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
            Assert.IsNotNull(createdResult);
            Assert.AreEqual((int)HttpStatusCode.OK, createdResult.StatusCode);

            var createdUser = createdResult.Value as ApplicationUser;
            Assert.IsNotNull(createdUser);
            Assert.AreEqual(newUser.UserName, createdUser.UserName);
            Assert.AreEqual(newUser.Email, createdUser.Email);

            // Check if the user is created in the database
            var userInDb = await DbContext.Users.FirstOrDefaultAsync(u => u.Id == createdUser.Id);
            Assert.IsNotNull(userInDb);
            Assert.AreEqual(newUser.UserName, userInDb.UserName);
            Assert.AreEqual(newUser.Email, userInDb.Email);
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
            Assert.IsNotNull(okResult);
            Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);

            var updatedResult = okResult.Value as ApplicationUser;
            Assert.IsNotNull(updatedResult);
            Assert.AreEqual(updatedUser.UserName, updatedResult.UserName);
            Assert.AreEqual(updatedUser.Email, updatedResult.Email);

            // Check if the user is updated in the database
            var userInDb = await DbContext.Users.FirstOrDefaultAsync(u => u.Id == userId);
            Assert.IsNotNull(userInDb);
            Assert.AreEqual(updatedUser.UserName, userInDb.UserName);
            Assert.AreEqual(updatedUser.Email, userInDb.Email);
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
            Assert.IsNotNull(okResult);
            Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);

            var message = okResult.Value as string;
            Assert.IsNotNull(message);
            Assert.AreEqual("User deleted successfully", message);

            // Check if the user is deleted from the database
            var userInDb = await DbContext.Users.FirstOrDefaultAsync(u => u.Id == userId);
            Assert.IsNull(userInDb);
        }
        
        [Test]
        public async Task CreateUser_NullModel_ShouldReturnBadRequest()
        {
            // Act
            var result = await _controller.CreateUser(null);

            // Assert
            Assert.IsInstanceOf<BadRequestObjectResult>(result);
        }
        
        [Test]
        public async Task CreateUser_InvalidModel_ShouldReturnBadRequest()
        {
            // Arrange
            var invalidUser = new ApplicationUser();

            // Act
            var result = await _controller.CreateUser(invalidUser);

            // Assert
            Assert.IsInstanceOf<BadRequestObjectResult>(result);
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
            Assert.IsNotNull(okResult);
            Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);

            var user = okResult.Value as ApplicationUser;
            Assert.IsNotNull(user);
            Assert.AreEqual(testUser.Id, user.Id);
        }
        
        [Test]
        public async Task GetUserById_NonExistingId_ShouldReturnNotFound()
        {
            // Arrange
            var nonExistingId = "non_existing_id";

            // Act
            var result = await _controller.GetUserById(nonExistingId);

            // Assert
            Assert.IsInstanceOf<NotFoundResult>(result);
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
            Assert.IsInstanceOf<NotFoundResult>(result);
        }
        
        [Test]
        public async Task DeleteUser_NonExistingId_ShouldReturnNotFound()
        {
            // Arrange
            var nonExistingId = "non_existing_id";

            // Act
            var result = await _controller.DeleteUser(nonExistingId);

            // Assert
            Assert.IsInstanceOf<NotFoundResult>(result);
        }
    }
}
