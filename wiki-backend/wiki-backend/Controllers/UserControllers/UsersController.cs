using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using wiki_backend.DatabaseServices;
using wiki_backend.Identity;
using wiki_backend.Models;

namespace wiki_backend.Controllers;


[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly WikiDbContext _context;

    public UsersController(UserManager<ApplicationUser> userManager, WikiDbContext context)
    {
        _userManager = userManager;
        _context = context;
    }
    
    [Authorize(Policy = IdentityData.AdminUserPolicyName)]
    [HttpGet("GetUsers")]
    public async Task<IActionResult> GetUsers()
    {
        var users = _userManager.Users.ToList();
        return Ok(users);
    }

    [Authorize(Policy = IdentityData.AdminUserPolicyName)]
    [HttpGet("GetUserById")]
    public async Task<IActionResult> GetUserById(string id)
    {
        var user = await _userManager.FindByIdAsync(id);

        if (user == null)
            return NotFound();

        return Ok(user);
    }

    [Authorize(Policy = IdentityData.AdminUserPolicyName)]
    [HttpPost("CreateUser")]
    public async Task<IActionResult> CreateUser([FromBody] ApplicationUser model)
    {
        if (model == null)
            return BadRequest("User data is null");

        var result = await _userManager.CreateAsync(model);

        if (!result.Succeeded)
            return BadRequest(result.Errors);

        return Ok(model);
    }

    [Authorize(Policy = IdentityData.AdminUserPolicyName)]
    [HttpPut("UpdateUser")]
    public async Task<IActionResult> UpdateUser(string id, [FromBody] ApplicationUser model)
    {
        var user = await _userManager.FindByIdAsync(id);

        if (user == null)
            return NotFound();

        user.UserName = model.UserName;
        user.Email = model.Email;

        var result = await _userManager.UpdateAsync(user);

        if (!result.Succeeded)
            return BadRequest(result.Errors);

        return Ok(user);
    }

    [Authorize(Policy = IdentityData.AdminUserPolicyName)]
    [HttpDelete("DeleteUser")]
    public async Task<IActionResult> DeleteUser(string id)
    {
        var user = await _userManager.FindByIdAsync(id);

        if (user == null)
            return NotFound();
        
        var userProfile = await _context.UserProfiles.SingleOrDefaultAsync(up => up.UserId == id);
        if (userProfile != null)
            _context.UserProfiles.Remove(userProfile);
        
        var result = await _userManager.DeleteAsync(user);

        if (!result.Succeeded)
            return BadRequest(result.Errors);

        await _context.SaveChangesAsync();

        return Ok("User deleted successfully");
    }
}