using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
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

        [SetUp]
        public void Setup()
        {
            // Initialize AuthService with required services
            _userManager = ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            _authService = new AuthService(_userManager, new TokenServices(), DbContext);
        }

        [Test]
        public async Task RegisterAsync_ShouldRegisterNewUser()
        {
            // Arrange
            var email = "test@example.com";
            var username = "testuser";
            var password = "testpassword";
            var role = "User"; // Provide a valid role

            // Act
            var result = await _authService.RegisterAsync(email, username, password, role);

            // Assert
            Assert.IsTrue(result.Success);
            // Add more assertions if needed
        }

        [Test]
        public async Task LoginAsync_ShouldLoginUser()
        {
            // Arrange
            var email = "test@example.com";
            var username = "testuser";
            var password = "testpassword";

            // First, register a new user
            await _authService.RegisterAsync(email, username, password, "User");

            // Act
            var result = await _authService.LoginAsync(email, password);

            // Assert
            Assert.IsTrue(result.Success);
            Assert.NotNull(result.Token);
            // Add more assertions if needed
        }
    }
}