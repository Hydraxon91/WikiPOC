using Microsoft.AspNetCore.Identity;

namespace wiki_backend.Services.Authentication;

public interface ITokenServices
{
    public string CreateToken(IdentityUser user, string role); 
}