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
            Assert.IsNotNull(token);

            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadJwtToken(token);

            Assert.IsNotNull(jwtToken);

            var claims = jwtToken.Claims
                .GroupBy(c => c.Type)
                .ToDictionary(g => g.Key, g => g.First().Value);

            foreach (var claim in claims)
            {
                Console.WriteLine($"{claim.Key}: {claim.Value}");
            }

            Assert.AreEqual(user.UserName, claims[ClaimTypes.Name]);
            Assert.AreEqual(user.Email, claims[ClaimTypes.Email]);
            Assert.AreEqual(role, claims[ClaimTypes.Role]);
            Assert.AreEqual(user.Id, claims[ClaimTypes.NameIdentifier]);
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

            Assert.AreEqual("TestIssuer", jwtToken.Issuer);
            Assert.AreEqual("TestAudience", jwtToken.Audiences.First());

            var claims = jwtToken.Claims.ToList();
            Assert.AreEqual("TokenForTheApiWithAuth", claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Sub)?.Value);
            Assert.IsNotNull(claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Jti));
            Assert.IsNotNull(claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Iat));
            Assert.AreEqual("test-user-id", claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
            Assert.AreEqual("testuser", claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value);
            Assert.AreEqual("testuser@example.com", claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value);
            Assert.AreEqual("User", claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value);
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
            Assert.IsNotNull(jwtToken);
            Assert.AreEqual(expectedExpiration.ToString(CultureInfo.InvariantCulture), jwtToken.ValidTo.ToString(CultureInfo.InvariantCulture));
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
            var token = _tokenServices.CreateToken(user, null);

            // Assert
            Assert.IsNotNull(token);

            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadJwtToken(token);

            var claims = jwtToken.Claims
                .GroupBy(c => c.Type)
                .ToDictionary(g => g.Key, g => g.First().Value);

            Assert.IsNotNull(claims);
            Assert.AreEqual(user.UserName, claims[ClaimTypes.Name]);
            Assert.AreEqual(user.Email, claims[ClaimTypes.Email]);
            Assert.AreEqual(user.Id, claims[ClaimTypes.NameIdentifier]);
            Assert.IsFalse(claims.ContainsKey(ClaimTypes.Role));
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
