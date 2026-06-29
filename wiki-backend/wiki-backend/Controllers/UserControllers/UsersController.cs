using System.Security.Claims;
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
            var usersWithRoles = new List<object>();
            foreach (var user in users)
            {
                var roles = await GetUserRoles(user);
                usersWithRoles.Add(new
                {
                    user.Id,
                    user.UserName,
                    user.Email,
                    Roles = roles
                });
            }
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

    [Authorize(Policy = IdentityData.AdminUserPolicyName)]
    [HttpPatch("UpdateRole/{userId}")]
    public async Task<IActionResult> UpdateUserRole(string userId, [FromBody] UpdateRoleRequest request)
    {
        var targetUser = await _userManager.FindByIdAsync(userId);
        if (targetUser == null) return NotFound("User not found");

        var allRoles = new[] { "Owner", "Admin", "Moderator", "User" };
        if (!allRoles.Contains(request.Role))
            return BadRequest("Invalid role. Must be Owner, Admin, Moderator, or User.");

        var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrEmpty(currentUserId)) return Unauthorized();
        var currentUser = await _userManager.FindByIdAsync(currentUserId);
        if (currentUser == null) return Unauthorized();

        var currentUserRoles = await _userManager.GetRolesAsync(currentUser);

        if (currentUserRoles.Contains("Owner"))
        {
            if (request.Role != "Owner")
            {
                var ownerCount = (await _userManager.GetUsersInRoleAsync("Owner")).Count;
                if (ownerCount <= 1 && currentUser.Id == userId)
                    return BadRequest("Cannot demote the last Owner.");
            }
            await SetUserRole(targetUser, request.Role);
            return Ok(new { Message = $"User role updated to {request.Role}" });
        }

        if (currentUserRoles.Contains("Admin"))
        {
            var targetRoles = await _userManager.GetRolesAsync(targetUser);
            if (targetRoles.Contains("Owner") || targetRoles.Contains("Admin"))
                return Forbid();

            if (request.Role != "Moderator" && request.Role != "User")
                return BadRequest("Admins can only assign Moderator or User roles.");

            await SetUserRole(targetUser, request.Role);
            return Ok(new { Message = $"User role updated to {request.Role}" });
        }

        return Forbid();
    }

    private async Task SetUserRole(ApplicationUser user, string newRole)
    {
        var currentRoles = await _userManager.GetRolesAsync(user);
        await _userManager.RemoveFromRolesAsync(user, currentRoles);
        await _userManager.AddToRoleAsync(user, newRole);
    }
}

public class UpdateRoleRequest
{
    public string Role { get; set; } = "";
}
