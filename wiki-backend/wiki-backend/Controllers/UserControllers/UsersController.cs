using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using wiki_backend.Identity;
using wiki_backend.Models;

namespace wiki_backend.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;

    public UsersController(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    [Authorize(Policy = IdentityData.AdminUserPolicyName)]
    [HttpGet("GetUsers")]
    public async Task<IActionResult> GetUsers()
    {
        var users = await _userManager.Users.ToListAsync();
        var rolesTasks = users.Select(u => GetUserRoles(u)).ToArray();
        var allRoles = await Task.WhenAll(rolesTasks);
        var usersWithRoles = users.Select((user, i) => new
        {
            user.Id,
            user.UserName,
            user.Email,
            Roles = allRoles[i]
        }).ToList();
        return Ok(usersWithRoles);
    }

    private async Task<List<string>> GetUserRoles(ApplicationUser user)
    {
        return (await _userManager.GetRolesAsync(user)).ToList();
    }
}
