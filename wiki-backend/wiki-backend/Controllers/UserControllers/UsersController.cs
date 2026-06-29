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
    private readonly ILogger<UsersController> _logger;

    public UsersController(UserManager<ApplicationUser> userManager, ILogger<UsersController> logger)
    {
        _userManager = userManager;
        _logger = logger;
    }

    [Authorize(Policy = IdentityData.AdminUserPolicyName)]
    [HttpGet("GetUsers")]
    public async Task<IActionResult> GetUsers()
    {
        try
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
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching users");
            return StatusCode(500, new { Message = "An error occurred while fetching users." });
        }
    }

    private async Task<List<string>> GetUserRoles(ApplicationUser user)
    {
        return (await _userManager.GetRolesAsync(user)).ToList();
    }
}
