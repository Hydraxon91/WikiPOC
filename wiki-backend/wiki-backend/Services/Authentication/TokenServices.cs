using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace wiki_backend.Services.Authentication;

public class TokenServices : ITokenServices
{
    
    public string CreateToken(IdentityUser user, string role)
    {
        var expirationMinutes = int.TryParse(Environment.GetEnvironmentVariable("JWT_TOKEN_TIME"), out int expirationFromEnv) ? expirationFromEnv : 30;
        var expiration = DateTime.UtcNow.AddMinutes(expirationMinutes);
        var token = CreateJwtToken(
            CreateClaims(user, role),
            CreateSigningCredentials(),
            expiration
        );
        var tokenHandler = new JwtSecurityTokenHandler();
        return tokenHandler.WriteToken(token);
    }
    
    private JwtSecurityToken CreateJwtToken(List<Claim> claims, SigningCredentials credentials, DateTime expiration) =>
        new JwtSecurityToken(
            Environment.GetEnvironmentVariable("JWT_VALID_ISSUER"),
            Environment.GetEnvironmentVariable("JWT_VALID_AUDIENCE"),
            claims,
            expires: expiration,
            signingCredentials: credentials
        );

    private List<Claim> CreateClaims(IdentityUser user, string? role)
    {
        try
        {
            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Sub, "TokenForTheApiWithAuth"),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString(CultureInfo.InvariantCulture)),
                new(ClaimTypes.NameIdentifier, user.Id),
                new(ClaimTypes.Name, user.UserName),
                new(ClaimTypes.Email, user.Email),
            };

            if (role != null)
                claims.Add(new Claim(ClaimTypes.Role, role));

            return claims;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    private SigningCredentials CreateSigningCredentials()
    {
        return new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("JWT_ISSUER_SIGNING_KEY"))
            ),
            SecurityAlgorithms.HmacSha256
        );
    }
}