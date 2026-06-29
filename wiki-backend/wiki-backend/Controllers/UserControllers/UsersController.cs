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
        if (model == null) return BadRequest("Invalid user data.");
        model.SecurityStamp = Guid.NewGuid().ToString();
        var result = await _userManager.CreateAsync(model);

        if (result.Succeeded)
        {
            return CreatedAtAction(nameof(GetUsers), new { id = model.Id }, model);
        }

        return BadRequest(result.Errors);
    }

    [Authorize(Policy = IdentityData.AdminUserPolicyName)]
    [HttpPut("UpdateUser")]
    public async Task<IActionResult> UpdateUser(string id, [FromBody] ApplicationUser model)
    {
        if (model == null || string.IsNullOrEmpty(id)) return BadRequest("Invalid user data.");

        var existingUser = await _userManager.FindByIdAsync(id);
        if (existingUser == null) return NotFound();

        existingUser.UserName = model.UserName;
        existingUser.Email = model.Email;

        var result = await _userManager.UpdateAsync(existingUser);
        if (result.Succeeded) return Ok(existingUser);

        return BadRequest(result.Errors);
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
        if (result.Succeeded) return NoContent();

        return BadRequest(result.Errors);
    }
}
