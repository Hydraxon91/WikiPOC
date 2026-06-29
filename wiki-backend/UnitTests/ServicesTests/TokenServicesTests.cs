using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using wiki_backend.Identity;
using wiki_backend.Models;
using wiki_backend.Services.Authentication;
using wiki_backend.Services.Settings;

namespace UnitTests.ServicesTests;

[TestFixture]
public class TokenServicesTests
{
    private TokenServices _tokenServices;
    private JwtSettings _jwtSettings;

    [SetUp]
    public void Setup()
    {
        _jwtSettings = new JwtSettings
        {
            ValidIssuer = "TestIssuer",
            ValidAudience = "TestAudience",
            IssuerSigningKey = "ThisIsA32CharLongTestSigningKey!",
            TokenTime = 60
        };

        _tokenServices = new TokenServices(Options.Create(_jwtSettings));
    }

    [Test]
    public void CreateToken_ShouldGenerateValidJwtToken()
    {
        var user = new ApplicationUser
        {
            Id = "test-user-id",
            UserName = "testuser",
            Email = "testuser@example.com",
        };

        var token = _tokenServices.CreateToken(user, "User");

        Assert.That(token, Is.Not.Null);

        var handler = new JwtSecurityTokenHandler();
        var jwtToken = handler.ReadJwtToken(token);

        Assert.That(jwtToken.Issuer, Is.EqualTo("TestIssuer"));
        Assert.That(jwtToken.Audiences.First(), Is.EqualTo("TestAudience"));
        Assert.That(jwtToken.Claims.First(c => c.Type == ClaimTypes.Name).Value, Is.EqualTo("testuser"));
        Assert.That(jwtToken.Claims.First(c => c.Type == ClaimTypes.Email).Value, Is.EqualTo("testuser@example.com"));
        Assert.That(jwtToken.Claims.First(c => c.Type == ClaimTypes.Role).Value, Is.EqualTo("User"));
        Assert.That(jwtToken.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value, Is.EqualTo("test-user-id"));
    }

    [Test]
    public void CreateToken_ShouldIncludeIatClaim()
    {
        var user = new ApplicationUser
        {
            Id = "test-user-id",
            UserName = "testuser",
            Email = "testuser@example.com"
        };

        var token = _tokenServices.CreateToken(user, "User");

        var handler = new JwtSecurityTokenHandler();
        var jwtToken = handler.ReadJwtToken(token);

        var iatClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Iat);
        Assert.That(iatClaim, Is.Not.Null);
        Assert.That(long.TryParse(iatClaim.Value, out _), Is.True, "iat must be a Unix timestamp (integer)");
    }

    [Test]
    public void CreateToken_ShouldUseConfiguredExpiration()
    {
        var user = new ApplicationUser
        {
            Id = "test-user-id",
            UserName = "testuser",
            Email = "testuser@example.com"
        };

        var token = _tokenServices.CreateToken(user, "User");

        var handler = new JwtSecurityTokenHandler();
        var jwtToken = handler.ReadJwtToken(token);

        var expectedExpiration = DateTime.UtcNow.AddMinutes(_jwtSettings.TokenTime);
        Assert.That(jwtToken.ValidTo, Is.EqualTo(expectedExpiration).Within(TimeSpan.FromSeconds(5)));
    }

    [Test]
    public void CreateToken_ShouldGenerateTokenWithoutRole()
    {
        var user = new ApplicationUser
        {
            Id = "test-user-id",
            UserName = "testuser",
            Email = "testuser@example.com"
        };

        var token = _tokenServices.CreateToken(user, null!);

        var handler = new JwtSecurityTokenHandler();
        var jwtToken = handler.ReadJwtToken(token);

        Assert.That(jwtToken.Claims.Any(c => c.Type == ClaimTypes.Role), Is.False);
    }

    [Test]
    public void CreateToken_ShouldIncludeSubClaim()
    {
        var user = new ApplicationUser
        {
            Id = "test-user-id",
            UserName = "testuser",
            Email = "testuser@example.com"
        };

        var token = _tokenServices.CreateToken(user, "User");

        var handler = new JwtSecurityTokenHandler();
        var jwtToken = handler.ReadJwtToken(token);

        Assert.That(jwtToken.Claims.First(c => c.Type == JwtRegisteredClaimNames.Sub).Value,
            Is.EqualTo(user.Id));
    }
}
