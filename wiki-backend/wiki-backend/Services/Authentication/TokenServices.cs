using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using wiki_backend.Models;
using wiki_backend.Services.Settings;

namespace wiki_backend.Services.Authentication;

public class TokenServices : ITokenServices
{
    private readonly JwtSettings _jwtSettings;

    public TokenServices(IOptions<JwtSettings> jwtSettings)
    {
        JwtSecurityTokenHandler.DefaultOutboundClaimTypeMap.Clear();
        _jwtSettings = jwtSettings.Value;
    }
    
    public string CreateToken(ApplicationUser user, string role)
    {
        var expiration = DateTime.UtcNow.AddMinutes(_jwtSettings.TokenTime);
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
            _jwtSettings.ValidIssuer,
            _jwtSettings.ValidAudience,
            claims,
            expires: expiration,
            signingCredentials: credentials
        );

    private static List<Claim> CreateClaims(ApplicationUser user, string? role)
    {
        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, user.Id),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer),
            new(ClaimTypes.NameIdentifier, user.Id),
            new(ClaimTypes.Name, user.UserName!),
            new(ClaimTypes.Email, user.Email!),
        };

        if (role != null)
            claims.Add(new Claim(ClaimTypes.Role, role));

        return claims;
    }
    
    private SigningCredentials CreateSigningCredentials()
    {
        return new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_jwtSettings.IssuerSigningKey)
            ),
            SecurityAlgorithms.HmacSha256
        );
    }
}