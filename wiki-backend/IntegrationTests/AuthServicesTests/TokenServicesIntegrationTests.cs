using System;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using NUnit.Framework;
using wiki_backend.Identity;
using wiki_backend.Models;
using wiki_backend.Services.Authentication;

namespace IntegrationTests.Services
{
    [TestFixture]
    public class TokenServicesIntegrationTests : IntegrationTestBase
    {
        private TokenServices _tokenServices;

        [SetUp]
        public void Setup()
        {
            // Mock environment variables
            Environment.SetEnvironmentVariable("JWT_TOKEN_TIME", JwtTokenTime);
            Environment.SetEnvironmentVariable("JWT_VALID_ISSUER", JwtValidIssuer);
            Environment.SetEnvironmentVariable("JWT_VALID_AUDIENCE", JwtValidAudience);
            Environment.SetEnvironmentVariable("JWT_ISSUER_SIGNING_KEY", JwtIssuerSigningKey);

            _tokenServices = new TokenServices();
        }

        [Test]
        public void CreateToken_ShouldGenerateValidJwtToken()
        {
            // Arrange
            var user = new ApplicationUser
            {
                Id = "test-user-id",
                UserName = "testuser",
                Email = "testuser@example.com",
            };
            var role = "User";

            // Act
            var token = _tokenServices.CreateToken(user, role);

            // Assert
            Assert.That(token, Is.Not.Null);

            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadJwtToken(token);

            Assert.That(jwtToken, Is.Not.Null);

            var claims = jwtToken.Claims
                .GroupBy(c => c.Type)
                .ToDictionary(g => g.Key, g => g.First().Value);

            Assert.That(claims[ClaimTypes.Name], Is.EqualTo(user.UserName));
            Assert.That(claims[ClaimTypes.Email], Is.EqualTo(user.Email));
            Assert.That(claims[ClaimTypes.Role], Is.EqualTo(role));
            Assert.That(claims[ClaimTypes.NameIdentifier], Is.EqualTo(user.Id));
        }


        [Test]
        public void CreateToken_ShouldIncludeCorrectClaims()
        {
            // Arrange
            var user = new ApplicationUser
            {
                Id = "test-user-id",
                UserName = "testuser",
                Email = "testuser@example.com"
            };
            var role = "User";

            // Act
            var token = _tokenServices.CreateToken(user, role);

            // Assert
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadJwtToken(token);

            Assert.That(jwtToken.Issuer, Is.EqualTo("TestIssuer"));
            Assert.That(jwtToken.Audiences.First(), Is.EqualTo("TestAudience"));

            var claims = jwtToken.Claims.ToList();
            Assert.That(claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Sub)?.Value, Is.EqualTo("TokenForTheApiWithAuth"));
            Assert.That(claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Jti), Is.Not.Null);
            Assert.That(claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Iat), Is.Not.Null);
            Assert.That(claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value, Is.EqualTo("test-user-id"));
            Assert.That(claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value, Is.EqualTo("testuser"));
            Assert.That(claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value, Is.EqualTo("testuser@example.com"));
            Assert.That(claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value, Is.EqualTo("User"));
        }
        
        [Test]
        public void CreateToken_ShouldHaveCorrectExpiration()
        {
            // Arrange
            var user = new ApplicationUser
            {
                Id = "test-user-id",
                UserName = GetRandomizedString("testuser"),
                Email = $"{GetRandomizedString("testuser")}@example.com"
            };
            var role = "User";
            var expirationMinutes = int.TryParse(Environment.GetEnvironmentVariable("JWT_TOKEN_TIME"), out int expirationFromEnv) ? expirationFromEnv : 30;
            var expectedExpiration = DateTime.UtcNow.AddMinutes(expirationMinutes);

            // Act
            var token = _tokenServices.CreateToken(user, role);
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadJwtToken(token);

            // Assert
            Assert.That(jwtToken, Is.Not.Null);
            Assert.That(jwtToken.ValidTo.ToString(CultureInfo.InvariantCulture), Is.EqualTo(expectedExpiration.ToString(CultureInfo.InvariantCulture)));
        }
        
        [Test]
        public void CreateToken_ShouldGenerateTokenWithoutRole()
        {
            // Arrange
            var user = new ApplicationUser
            {
                Id = "test-user-id",
                UserName = GetRandomizedString("testuser"),
                Email = $"{GetRandomizedString("testuser")}@example.com"
            };

            // Act
            var token = _tokenServices.CreateToken(user, null!);

            // Assert
            Assert.That(token, Is.Not.Null);

            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadJwtToken(token);

            var claims = jwtToken.Claims
                .GroupBy(c => c.Type)
                .ToDictionary(g => g.Key, g => g.First().Value);

            Assert.That(claims, Is.Not.Null);
            Assert.That(claims[ClaimTypes.Name], Is.EqualTo(user.UserName));
            Assert.That(claims[ClaimTypes.Email], Is.EqualTo(user.Email));
            Assert.That(claims[ClaimTypes.NameIdentifier], Is.EqualTo(user.Id));
            Assert.That(claims, Does.Not.ContainKey(ClaimTypes.Role));
        }
        
        [Test]
        public void CreateToken_ShouldFailValidationWithInvalidSigningKey()
        {
            // Arrange
            var user = new ApplicationUser
            {
                Id = "test-user-id",
                UserName = GetRandomizedString("testuser"),
                Email = $"{GetRandomizedString("testuser")}@example.com"
            };
            var role = "User";
            var token = _tokenServices.CreateToken(user, role);

            var tokenHandler = new JwtSecurityTokenHandler();

            // Generate a random invalid signing key
            var invalidSigningKey = Encoding.UTF8.GetBytes(GetRandomizedString("InvalidSigningKey"));
            var invalidSymmetricKey = new SymmetricSecurityKey(invalidSigningKey);

            var invalidValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = Environment.GetEnvironmentVariable("JWT_VALID_ISSUER"),
                ValidateAudience = true,
                ValidAudience = Environment.GetEnvironmentVariable("JWT_VALID_AUDIENCE"),
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = invalidSymmetricKey, // Use the generated invalid key
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };

            // Act & Assert
            Assert.Throws<SecurityTokenSignatureKeyNotFoundException>(() =>
            {
                tokenHandler.ValidateToken(token, invalidValidationParameters, out _);
            });
        }
        
        [Test]
        public void CreateToken_ShouldThrowExceptionWithMissingEnvVariables()
        {
            // Arrange
            var user = new ApplicationUser
            {
                Id = "test-user-id",
                UserName = GetRandomizedString("testuser"),
                Email = $"{GetRandomizedString("testuser")}@example.com"
            };
            var role = "User";

            Environment.SetEnvironmentVariable("JWT_ISSUER_SIGNING_KEY", null);

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => _tokenServices.CreateToken(user, role));
        }
    }
}
