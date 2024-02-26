using Microsoft.AspNetCore.Identity;
using wiki_backend.Models;

namespace wiki_backend.Services.Authentication;

public interface ITokenServices
{
    public string CreateToken(ApplicationUser user, string role); 
}