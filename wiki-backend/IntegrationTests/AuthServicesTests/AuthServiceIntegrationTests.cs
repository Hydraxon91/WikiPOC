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

            // Register required services and dependencies
            var services = new ServiceCollection();
            services.AddLogging();
            services.AddDbContext<WikiDbContext>(options =>
                options.UseSqlServer("Server=localhost,1433;Database=IntTestDb;User=sa;Password=YourPassword123!;Encrypt=false;"));
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<WikiDbContext>()
                .AddDefaultTokenProviders();

            _tokenServicesMock = new Mock<ITokenServices>();

            var serviceProvider = services.BuildServiceProvider();

            _userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            _authService = new AuthService(_userManager, _tokenServicesMock.Object, DbContext);
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
            // Add more assertions if needed
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
            // Add more assertions if needed
        }
    }
}
