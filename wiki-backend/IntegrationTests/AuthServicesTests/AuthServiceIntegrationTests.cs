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
            var email = "test@example.com";
            var username = "testuser";
            var password = "@Testpassword2";
            var role = "User";

            // Act
            var result = await _authService.RegisterAsync(email, username, password, role);

            // Assert
            Console.WriteLine(result);
            foreach (var error in result.ErrorMessages)
            {
                Console.WriteLine(error.Key, " ", error.Value);
            }
            Assert.IsTrue(result.Success);
        }

        [Test]
        public async Task LoginAsync_ShouldLoginUser()
        {
            // Arrange
            var email = "test2@example.com";
            var username = "testuser2";
            var password = "@Testpassword2";
            var role = "User";

            // First, register a new user
            await _authService.RegisterAsync(email, username, password, role);

            // Mock token generation
            _tokenServicesMock.Setup(x => x.CreateToken(It.IsAny<ApplicationUser>(), It.IsAny<string>())).Returns("mocked_token");

            // Act
            var result = await _authService.LoginAsync(email, password);

            // Assert
            Console.WriteLine(result);
            Assert.IsTrue(result.Success);
            Assert.AreEqual("mocked_token", result.Token); // Check if the mocked token is returned
        }
        [Test]
        public async Task RegisterAsync_ShouldFail_WhenInvalidInputData()
        {
            // Arrange
            var email = "test";
            var username = "testuser3";
            var password = "@Testpassword2";
            var role = "User";

            // Act
            var result = await _authService.RegisterAsync(null, null, null, role);

            // Assert
            Assert.IsFalse(result.Success);
            Assert.AreEqual("Bad request", result.ErrorMessages.Keys.First());
            Assert.AreEqual("Invalid input data", result.ErrorMessages.Values.First());
        }

        [Test]
        public async Task RegisterAsync_ShouldFail_WhenDuplicateEmail()
        {
            // Arrange
            var email = "test4@example.com";
            var username = "testuser4";
            var password = "@Testpassword2";
            var role = "User";

            // First, register a new user
            await _authService.RegisterAsync(email, username, password, role);

            // Act
            var result = await _authService.RegisterAsync(email, "newuser", password, role);

            foreach (var error in result.ErrorMessages)
            {
                Console.WriteLine(error.Key, " ", error.Value);
            }
            // Assert
            Assert.IsFalse(result.Success);
            Assert.AreEqual("Duplicate email", result.ErrorMessages.Keys.First());
            Assert.AreEqual("Email is already taken", result.ErrorMessages.Values.First());
        }
        
        [Test]
        public async Task RegisterAsync_ShouldFail_WhenInvalidEmailFormat()
        {
            // Arrange
            var email = "invalidemail";
            var username = "testuser";
            var password = "@Testpassword2";
            var role = "User";

            // Act
            var result = await _authService.RegisterAsync(email, username, password, role);

            // Assert
            Assert.IsFalse(result.Success);
            Assert.AreEqual("Invalid email", result.ErrorMessages.Keys.First());
            Assert.AreEqual("Email is not in a valid format", result.ErrorMessages.Values.First());
        }
        
        [Test]
        public async Task LoginAsync_ShouldFail_WhenInvalidCredentials()
        {
            // Arrange
            var email = "test5@example.com";
            var username = "testuser5";
            var password = "@Testpassword2";

            // First, register a new user
            await _authService.RegisterAsync(email, username, password, "User");

            // Act
            var result = await _authService.LoginAsync(email, "invalidpassword");

            // Assert
            Assert.IsFalse(result.Success);
            Assert.AreEqual("Bad credentials", result.ErrorMessages.Keys.First());
            Assert.AreEqual("Invalid password", result.ErrorMessages.Values.First());
        }
        

    }
}
