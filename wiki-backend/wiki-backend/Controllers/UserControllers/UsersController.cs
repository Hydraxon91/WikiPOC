using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using wiki_backend.DatabaseServices.Repositories;
using wiki_backend.Identity;
using wiki_backend.Models;

namespace wiki_backend.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IUserProfileRepository _profileRepository;

    public UsersController(UserManager<ApplicationUser> userManager, IUserProfileRepository profileRepository)
    {
        _userManager = userManager;
        _profileRepository = profileRepository;
    }

    private async Task<List<string>> GetUserRoles(ApplicationUser user)
    {
        return (await _userManager.GetRolesAsync(user)).ToList();
    }

    [Authorize(Policy = IdentityData.AdminUserPolicyName)]
    [HttpGet("DebugPrincipal")]
    public IActionResult DebugPrincipal()
    {
        var claims = User.Claims.Select(c => new { c.Type, c.Value }).ToList();
        return Ok(new { claims, isAuth = User.Identity?.IsAuthenticated });
    }

    [Authorize(Policy = IdentityData.AdminUserPolicyName)]
    [HttpGet("GetUsers")]
    public async Task<IActionResult> GetUsers()
    {
        var users = await _userManager.Users.ToListAsync();
        var usersWithRoles = users.Select(user => new
        {
            user.Id,
            user.UserName,
            user.Email,
            Roles = GetUserRoles(user).Result
        }).ToList();
        return Ok(usersWithRoles);
    }

    [Authorize(Policy = IdentityData.AdminUserPolicyName)]
    [HttpGet("GetUserById")]
    public async Task<IActionResult> GetUserById(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user == null) return NotFound();
        var roles = await GetUserRoles(user);
        return Ok(new { user.Id, user.UserName, user.Email, Roles = roles });
    }

    [Authorize(Policy = IdentityData.AdminUserPolicyName)]
    [HttpPost("CreateUser")]
    public async Task<IActionResult> CreateUser([FromBody] ApplicationUser model)
    {
        if (model == null) return BadRequest("User data is null");
        var result = await _userManager.CreateAsync(model);
        if (!result.Succeeded) return BadRequest(result.Errors);
        return Ok(model);
    }

    [Authorize(Policy = IdentityData.AdminUserPolicyName)]
    [HttpPut("UpdateUser")]
    public async Task<IActionResult> UpdateUser(string id, [FromBody] ApplicationUser model)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user == null) return NotFound();
        user.UserName = model.UserName;
        user.Email = model.Email;
        var result = await _userManager.UpdateAsync(user);
        if (!result.Succeeded) return BadRequest(result.Errors);
        return Ok(user);
    }

    [Authorize(Policy = IdentityData.AdminUserPolicyName)]
    [HttpDelete("DeleteUser")]
    public async Task<IActionResult> DeleteUser(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user == null) return NotFound();
        var userProfile = await _profileRepository.GetByUserIdAsync(id);
        if (userProfile != null)
            await _profileRepository.RemoveAsync(userProfile.Id);
        var result = await _userManager.DeleteAsync(user);
        if (!result.Succeeded) return BadRequest(result.Errors);
        return Ok("User deleted successfully");
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

        // Owner can change any role
        if (currentUserRoles.Contains("Owner"))
        {
            // Prevent the last Owner from being demoted
            if (request.Role != "Owner")
            {
                var ownerCount = (await _userManager.GetUsersInRoleAsync("Owner")).Count;
                if (ownerCount <= 1 && currentUser.Id == userId)
                    return BadRequest("Cannot demote the last Owner.");
            }
            await SetUserRole(targetUser, request.Role);
            return Ok(new { Message = $"User role updated to {request.Role}" });
        }

        // Admin can only set Moderator or User, and cannot change other Admins or Owners
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
