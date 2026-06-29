using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;
using wiki_backend.DatabaseServices;
using wiki_backend.Identity;
using wiki_backend.Models;
using wiki_backend.Services.Authentication;

namespace IntegrationTests.Services
{
    [TestFixture]
    public class AuthServiceIntegrationTests : IntegrationTestBase
    {
        private AuthService _authService;
        private UserManager<ApplicationUser> _userManager;
        private Mock<ITokenServices> _tokenServicesMock;

        [SetUp]
        public void Setup()
        {
            // Initialize AuthService with required services
            _userManager = ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            _tokenServicesMock = new Mock<ITokenServices>();
            _authService = new AuthService(_userManager, _tokenServicesMock.Object, DbContext);
            // ResetDatabase();
        }
        
        
        
        [Test]
        public async Task RegisterAsync_ShouldRegisterNewUser()
        {
            // Arrange
            var email = $"{GetRandomizedString("test")}@example.com";
            var username = GetRandomizedString("testuser");
            var password = "@Testpassword2";
            var role = "User";

            // Act
            var result = await _authService.RegisterAsync(email, username, password, role);

            // Assert
            Assert.That(result.Success, Is.True);
        }
        
        [Test]
        public async Task RegisterAsync_PasswordRequiresNonAlphanumeric_UpperCase_Numeric_ShouldFail()
        {
            // Arrange
            var email = $"{GetRandomizedString("test")}@example.com";
            var username = GetRandomizedString("testuser");
            var password = "wrongpassword"; // Password missing non-alphanumeric, digits, and uppercase
            var role = "User";

            // Act
            var result = await _authService.RegisterAsync(email, username, password, role);

            // Assert
            Assert.That(result.Success, Is.False);
            Assert.That(result.ErrorMessages, Does.ContainKey("PasswordRequiresNonAlphanumeric"), "Expected error message for missing non-alphanumeric characters.");
            Assert.That(result.ErrorMessages, Does.ContainKey("PasswordRequiresDigit"), "Expected error message for missing digits.");
            Assert.That(result.ErrorMessages, Does.ContainKey("PasswordRequiresUpper"), "Expected error message for missing uppercase letters.");
        }
        
        [Test]
        public async Task RegisterAsync_ShouldFail_WhenInvalidInputData()
        {
            // Arrange
            var role = "User";

            // Act
            var result = await _authService.RegisterAsync(null!, null!, null!, role);

            // Assert
            Assert.That(result.Success, Is.False);
            Assert.That(result.ErrorMessages.Keys.First(), Is.EqualTo("Bad request"));
            Assert.That(result.ErrorMessages.Values.First(), Is.EqualTo("Invalid input data"));
        }
        
        [Test]
        public async Task RegisterAsync_ShouldFail_WhenDuplicateUser()
        {
            // Arrange
            var email = $"{GetRandomizedString("test55")}@example.com";
            var username = "testuser";
            var password = "@Testpassword2";
            var role = "User";

            // First, register a new user
            await _authService.RegisterAsync(email, username, password, role);

            // Act
            var result = await _authService.RegisterAsync($"{GetRandomizedString("test56")}@example.com", username, password, role);

            // Assert
            Assert.That(result.Success, Is.False);
            Assert.That(result.ErrorMessages.Keys.First(), Is.EqualTo("DuplicateUserName"));
            Assert.That(result.ErrorMessages.Values.First(), Is.EqualTo("Username 'testuser' is already taken."));
        }

        [Test]
        public async Task RegisterAsync_ShouldFail_WhenDuplicateEmail()
        {
            // Arrange
            var email = $"{GetRandomizedString("test")}@example.com";
            var username = GetRandomizedString("testuser");
            var password = "@Testpassword2";
            var role = "User";

            // First, register a new user
            await _authService.RegisterAsync(email, username, password, role);

            // Act
            var result = await _authService.RegisterAsync(email, GetRandomizedString("newuser"), password, role);

            // Assert
            Assert.That(result.Success, Is.False);
            Assert.That(result.ErrorMessages.Keys.First(), Is.EqualTo("Duplicate email"));
            Assert.That(result.ErrorMessages.Values.First(), Is.EqualTo("Email is already taken"));
        }
        
        [Test]
        public async Task RegisterAsync_ShouldFail_WhenInvalidEmailFormat()
        {
            // Arrange
            var email = "invalidemail";
            var username = GetRandomizedString("testuser");
            var password = "@Testpassword2";
            var role = "User";

            // Act
            var result = await _authService.RegisterAsync(email, username, password, role);

            // Assert
            Assert.That(result.Success, Is.False);
            Assert.That(result.ErrorMessages.Keys.First(), Is.EqualTo("Invalid email"));
            Assert.That(result.ErrorMessages.Values.First(), Is.EqualTo("Email is not in a valid format"));
        }
        
        [Test]
        public async Task LoginAsync_ShouldLoginUser()
        {
            // Arrange
            var email = $"{GetRandomizedString("test")}@example.com";
            var username = GetRandomizedString("testuser");
            var password = "@Testpassword2";
            var role = "User";

            // First, register a new user
            await _authService.RegisterAsync(email, username, password, role);

            // Mock token generation
            _tokenServicesMock.Setup(x => x.CreateToken(It.IsAny<ApplicationUser>(), It.IsAny<string>())).Returns("mocked_token");

            // Act
            var result = await _authService.LoginAsync(email, password);

            // Assert
            Assert.That(result.Success, Is.True);
            Assert.That(result.Token, Is.EqualTo("mocked_token")); // Check if the mocked token is returned
        }
        
        [Test]
        public async Task LoginAsync_ShouldFail_WhenInvalidCredentials()
        {
            // Arrange
            var email = $"{GetRandomizedString("test5")}@example.com";
            var username = GetRandomizedString("testuser5");
            var password = "@Testpassword2";

            // First, register a new user
            await _authService.RegisterAsync(email, username, password, "User");

            // Act
            var result = await _authService.LoginAsync(email, "invalidpassword");

            // Assert
            Assert.That(result.Success, Is.False);
            Assert.That(result.ErrorMessages.Keys.First(), Is.EqualTo("Bad credentials"));
            Assert.That(result.ErrorMessages.Values.First(), Is.EqualTo("Invalid credentials"));
        }
        
        [Test]
        public async Task LoginAsync_ShouldFail_WhenNonExistentUser_Email()
        {
            // Arrange
            var email = $"{GetRandomizedString("test5")}@example.com";
            var password = "@Testpassword2";

            // Act
            var result = await _authService.LoginAsync(email, password);

            // Assert
            Assert.That(result.Success, Is.False);
            Assert.That(result.ErrorMessages.Keys.First(), Is.EqualTo("Bad credentials"));
            Assert.That(result.ErrorMessages.Values.First(), Is.EqualTo("Invalid credentials"));
        }
        
        [Test]
        public async Task LoginAsync_ShouldFail_WhenNonExistentUser_Username()
        {
            // Arrange
            var username = GetRandomizedString("testuser69");
            var password = "@Testpassword2";

            // Act
            var result = await _authService.LoginAsync(username, password);
            // Assert
            Assert.That(result.Success, Is.False);
            Assert.That(result.ErrorMessages.Keys.First(), Is.EqualTo("Bad credentials"));
            Assert.That(result.ErrorMessages.Values.First(), Is.EqualTo("Invalid credentials"));
        }
    }
}
