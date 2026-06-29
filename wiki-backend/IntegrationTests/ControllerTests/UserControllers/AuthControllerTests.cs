using Microsoft.AspNetCore.Mvc;
using wiki_backend.Contracts;
using wiki_backend.Controllers;

namespace IntegrationTests.ControllerTests.UserControllers;

[NonParallelizable]
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
        await CreateTestUserAsync("test@example.com", "test_user", "@Testpassword1");
    
        _controller = CreateAuthController();
    }

    [Test]
    public async Task Register_ValidRequest_ShouldReturnCreatedAtAction()
    {
        // Arrange
        var request = new RegistrationRequest("test22@example.com", "test2_user", "@Testpassword1");

        // Act
        var result = await _controller.Register(request);
        // Assert
        var createdAtActionResult = result.Result as CreatedAtActionResult; // Access the Result property of ActionResult
        Assert.That(createdAtActionResult, Is.Not.Null, "CreatedAtActionResult should not be null");
        Assert.That(createdAtActionResult.StatusCode, Is.EqualTo(201));
        var responseData = createdAtActionResult.Value as RegistrationResponse;
        Assert.That(responseData, Is.Not.Null);
    }

    [Test]
    public async Task Register_InvalidRequest_ShouldReturnBadRequest()
    {
        // Arrange
        var invalidRequest = new RegistrationRequest("", "", "");

        // Act
        var result = await _controller.Register(invalidRequest);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Result, Is.InstanceOf<BadRequestObjectResult>());
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
        Assert.That(okResult, Is.Not.Null);
        Assert.That(okResult.StatusCode, Is.EqualTo(200));
        var responseData = okResult.Value as AuthResponse;
        Assert.That(responseData, Is.Not.Null);
    }
    
    [Test]
    public async Task Authenticate_InvalidCredentials_ShouldReturnBadRequest()
    {
        // Arrange
        var invalidRequest = new AuthRequest("test@example.com", "@Testpassword3");

        // Act
        var result = await _controller.Authenticate(invalidRequest);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Result, Is.InstanceOf<BadRequestObjectResult>());
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
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Result, Is.InstanceOf<BadRequestObjectResult>());
        var badRequestResult = (BadRequestObjectResult)result.Result;
        // Extract the error messages from the SerializableError object
        var errors = (SerializableError)badRequestResult.Value!;
        Assert.That(errors, Does.ContainKey("Duplicate email"));
        var errorMessages = (string[])errors["Duplicate email"];
        Assert.That(errorMessages, Does.Contain("Email is already taken"));
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
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Result, Is.InstanceOf<BadRequestObjectResult>());
        var badRequestResult = (BadRequestObjectResult)result.Result;
        Assert.That(badRequestResult.StatusCode, Is.EqualTo(400));
        var errors = (SerializableError)badRequestResult.Value!;
        Assert.That(errors, Does.ContainKey("DuplicateUserName"));
        var errorMessages = (string[])errors["DuplicateUserName"];
        Assert.That(errorMessages, Does.Contain($"Username '{existingUsername}' is already taken."));
    }

    [Test]
    public async Task Authenticate_IncorrectPassword_ShouldReturnBadRequest()
    {
        // Arrange
        var request = new AuthRequest("test@example.com", "incorrect_password");

        // Act
        var result = await _controller.Authenticate(request);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Result, Is.InstanceOf<BadRequestObjectResult>());
        var badRequestResult = (BadRequestObjectResult)result.Result;
        Assert.That(badRequestResult.StatusCode, Is.EqualTo(400));
    }

    [Test]
    public async Task Authenticate_NonexistentUser_ShouldReturnBadRequest()
    {
        // Arrange
        var request = new AuthRequest("nonexistent@example.com", "@Testpassword1");

        // Act
        var result = await _controller.Authenticate(request);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Result, Is.InstanceOf<BadRequestObjectResult>());
        var badRequestResult = (BadRequestObjectResult)result.Result;
        Assert.That(badRequestResult.StatusCode, Is.EqualTo(400));
    }
}