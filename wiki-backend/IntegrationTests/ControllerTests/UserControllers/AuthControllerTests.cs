using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using wiki_backend.Contracts;
using wiki_backend.Controllers;
using wiki_backend.Models;
using wiki_backend.Services.Authentication;

namespace IntegrationTests.ControllerTests.UserControllers;

[TestFixture]
public class AuthControllerTests : IntegrationTestBase
{ 
    private AuthController _controller;

    [SetUp]
    public async Task SetUp()
    {
        ResetDatabase(); // Ensure a clean database for each test
    
        // Create or retrieve the "User" role
        await EnsureUserRoleExistsAsync();

        // Create a test user
        await CreateTestUserAsync();
    
        _controller = CreateAuthController();
    }

    [Test]
        public async Task Register_ValidRequest_ShouldReturnCreatedAtAction()
        {
            // Arrange
            var request = new RegistrationRequest("test2@example.com", "test2_user", "@Testpassword1");

            // Act
            var result = await _controller.Register(request);
            // Assert
            var createdAtActionResult = result.Result as CreatedAtActionResult; // Access the Result property of ActionResult
            Assert.IsNotNull(createdAtActionResult, "CreatedAtActionResult should not be null");
            Assert.AreEqual(201, createdAtActionResult.StatusCode);
            var responseData = createdAtActionResult.Value as RegistrationResponse;
            Assert.IsNotNull(responseData);
        }

        [Test]
        public async Task Register_InvalidRequest_ShouldReturnBadRequest()
        {
            // Arrange
            var invalidRequest = new RegistrationRequest("", "", "");

            // Act
            var result = await _controller.Register(invalidRequest);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<BadRequestObjectResult>(result.Result);
        }
        
        [Test]
        public async Task Authenticate_ValidCredentials_ShouldReturnOk()
        {
            // Arrange
            var request = new AuthRequest("test@example.com", "@Testpassword1");

            // Act
            var result = await _controller.Authenticate(request);
            // Assert
            var okResult = result.Result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
            var responseData = okResult.Value as AuthResponse;
            Assert.IsNotNull(responseData);
        }
        
        [Test]
        public async Task Authenticate_InvalidCredentials_ShouldReturnBadRequest()
        {
            // Arrange
            var invalidRequest = new AuthRequest("test@example.com", "@Testpassword3");

            // Act
            var result = await _controller.Authenticate(invalidRequest);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<BadRequestObjectResult>(result.Result);
        }
        [Test]
        public async Task Register_ExistingEmail_ShouldReturnBadRequest()
        {
            // Arrange
            var existingUserEmail = "test@example.com";
            var request = new RegistrationRequest(existingUserEmail, "new_user", "@Testpassword1");

            // Act
            var result = await _controller.Register(request);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<BadRequestObjectResult>(result.Result);
            var badRequestResult = (BadRequestObjectResult)result.Result;
            // Extract the error messages from the SerializableError object
            var errors = (SerializableError)badRequestResult.Value;
            Assert.IsTrue(errors.ContainsKey("Duplicate email"));
            var errorMessages = (string[])errors["Duplicate email"];
            Assert.IsTrue(errorMessages.Contains("Email is already taken"));
        }

        [Test]
        public async Task Register_ExistingUsername_ShouldReturnBadRequest()
        {
            // Arrange
            var existingUsername = "test_user";
            var request = new RegistrationRequest("new@example.com", existingUsername, "@Testpassword1");

            // Act
            var result = await _controller.Register(request);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<BadRequestObjectResult>(result.Result);
            var badRequestResult = (BadRequestObjectResult)result.Result;
            Assert.AreEqual(400, badRequestResult.StatusCode);
            var errors = (SerializableError)badRequestResult.Value;
            Assert.IsTrue(errors.ContainsKey("DuplicateUserName"));
            var errorMessages = (string[])errors["DuplicateUserName"];
            Assert.IsTrue(errorMessages.Contains($"Username '{existingUsername}' is already taken."));
        }

        [Test]
        public async Task Authenticate_IncorrectPassword_ShouldReturnBadRequest()
        {
            // Arrange
            var request = new AuthRequest("test@example.com", "incorrect_password");

            // Act
            var result = await _controller.Authenticate(request);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<BadRequestObjectResult>(result.Result);
            var badRequestResult = (BadRequestObjectResult)result.Result;
            Assert.AreEqual(400, badRequestResult.StatusCode);
        }

        [Test]
        public async Task Authenticate_NonexistentUser_ShouldReturnBadRequest()
        {
            // Arrange
            var request = new AuthRequest("nonexistent@example.com", "@Testpassword1");

            // Act
            var result = await _controller.Authenticate(request);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<BadRequestObjectResult>(result.Result);
            var badRequestResult = (BadRequestObjectResult)result.Result;
            Assert.AreEqual(400, badRequestResult.StatusCode);
        }
}