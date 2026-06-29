using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Moq;
using wiki_backend.DatabaseServices;
using wiki_backend.Models;
using wiki_backend.Services.Authentication;
using wiki_backend.Services.Settings;

namespace UnitTests.ServicesTests;

[TestFixture]
public class AuthServiceTests
{
    private Mock<UserManager<ApplicationUser>> _userManagerMock;
    private Mock<ITokenServices> _tokenServiceMock;
    private WikiDbContext _dbContext;
    private AuthService _authService;

    [SetUp]
    public void Setup()
    {
        var store = new Mock<IUserStore<ApplicationUser>>();
        _userManagerMock = new Mock<UserManager<ApplicationUser>>(store.Object, null!, null!, null!, null!, null!, null!, null!, null!);
        _tokenServiceMock = new Mock<ITokenServices>();

        var options = new DbContextOptionsBuilder<WikiDbContext>()
            .UseInMemoryDatabase($"AuthTest_{TestContext.CurrentContext.Test.Name}")
            .Options;
        _dbContext = new WikiDbContext(options);
        _dbContext.Database.EnsureCreated();

        _authService = new AuthService(_userManagerMock.Object, _tokenServiceMock.Object, _dbContext);
    }

    [TearDown]
    public void TearDown()
    {
        _dbContext.Database.EnsureDeleted();
        _dbContext.Dispose();
    }

    [Test]
    public async Task RegisterAsync_ShouldReturnSuccess_WhenValidInput()
    {
        _userManagerMock.Setup(x => x.FindByEmailAsync(It.IsAny<string>()))
            .ReturnsAsync((ApplicationUser)null!);
        _userManagerMock.Setup(x => x.CreateAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>()))
            .ReturnsAsync(IdentityResult.Success);
        _userManagerMock.Setup(x => x.AddToRoleAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>()))
            .ReturnsAsync(IdentityResult.Success);
        _userManagerMock.Setup(x => x.AddClaimAsync(It.IsAny<ApplicationUser>(), It.IsAny<Claim>()))
            .ReturnsAsync(IdentityResult.Success);

        var result = await _authService.RegisterAsync("test@example.com", "testuser", "Password123", "User");

        Assert.That(result.Success, Is.True);
    }

    [Test]
    public async Task RegisterAsync_ShouldFail_WhenEmailAlreadyExists()
    {
        _userManagerMock.Setup(x => x.FindByEmailAsync(It.IsAny<string>()))
            .ReturnsAsync(new ApplicationUser());

        var result = await _authService.RegisterAsync("test@example.com", "testuser", "Password123", "User");

        Assert.That(result.Success, Is.False);
    }

    [Test]
    public async Task RegisterAsync_ShouldFail_WhenInvalidEmail()
    {
        var result = await _authService.RegisterAsync("invalid-email", "testuser", "Password123", "User");

        Assert.That(result.Success, Is.False);
    }

    [Test]
    public async Task LoginAsync_ShouldReturnToken_WhenValidCredentials()
    {
        var user = new ApplicationUser
        {
            UserName = "testuser",
            Email = "test@example.com",
            Id = Guid.NewGuid().ToString()
        };

        _userManagerMock.Setup(x => x.FindByEmailAsync(It.IsAny<string>()))
            .ReturnsAsync(user);
        _userManagerMock.Setup(x => x.CheckPasswordAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>()))
            .ReturnsAsync(true);
        _userManagerMock.Setup(x => x.GetRolesAsync(It.IsAny<ApplicationUser>()))
            .ReturnsAsync(new List<string> { "User" });
        _tokenServiceMock.Setup(x => x.CreateToken(It.IsAny<ApplicationUser>(), It.IsAny<string>()))
            .Returns("test-token");

        var result = await _authService.LoginAsync("test@example.com", "Password123");

        Assert.That(result.Success, Is.True);
        Assert.That(result.Token, Is.EqualTo("test-token"));
    }

    [Test]
    public async Task LoginAsync_ShouldFail_WhenInvalidCredentials()
    {
        _userManagerMock.Setup(x => x.FindByEmailAsync(It.IsAny<string>()))
            .ReturnsAsync((ApplicationUser)null!);

        var result = await _authService.LoginAsync("test@example.com", "WrongPassword");

        Assert.That(result.Success, Is.False);
    }

    [Test]
    public async Task LoginAsync_ShouldFail_WhenPasswordWrong()
    {
        var user = new ApplicationUser
        {
            UserName = "testuser",
            Email = "test@example.com",
            Id = Guid.NewGuid().ToString()
        };

        _userManagerMock.Setup(x => x.FindByEmailAsync(It.IsAny<string>()))
            .ReturnsAsync(user);
        _userManagerMock.Setup(x => x.CheckPasswordAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>()))
            .ReturnsAsync(false);

        var result = await _authService.LoginAsync("test@example.com", "WrongPassword");

        Assert.That(result.Success, Is.False);
    }
}
