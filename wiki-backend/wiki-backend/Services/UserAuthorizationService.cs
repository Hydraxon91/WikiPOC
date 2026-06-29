using Microsoft.AspNetCore.Identity;
using wiki_backend.Models;

namespace wiki_backend.Services;

public interface IUserAuthorizationService
{
    Task<bool> IsUserAdmin(string? userName);
}

public class UserAuthorizationService : IUserAuthorizationService
{
    private readonly UserManager<ApplicationUser> _userManager;

    public UserAuthorizationService(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<bool> IsUserAdmin(string? userName)
    {
        if (string.IsNullOrEmpty(userName))
            return false;
        var user = await _userManager.FindByNameAsync(userName);
        return user != null && await _userManager.IsInRoleAsync(user, "Admin");
    }
}
