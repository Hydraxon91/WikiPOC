using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using wiki_backend.DatabaseServices;
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
    
    [HttpGet("GetUsers")]
    public async Task<IActionResult> GetUsers()
    {
        var users = _userManager.Users.ToList();
        return Ok(users);
    }

    [HttpGet("GetUserById")]
    public async Task<IActionResult> GetUserById(string id)
    {
        var user = await _userManager.FindByIdAsync(id);

        if (user == null)
            return NotFound();

        return Ok(user);
    }

    [Authorize(Roles = "Admin")]
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

    [Authorize(Roles = "Admin")]
    [HttpPut("UpdateUser")]
    public async Task<IActionResult> UpdateUser(string id, [FromBody] ApplicationUser model)
    {
        var user = await _userManager.FindByIdAsync(id);

        if (user == null)
            return NotFound();

        // Update user properties here
        user.UserName = model.UserName;
        user.Email = model.Email;

        var result = await _userManager.UpdateAsync(user);

        if (!result.Succeeded)
            return BadRequest(result.Errors);

        return Ok(user);
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("DeleteUser")]
    public async Task<IActionResult> DeleteUser(string id)
    {
        var user = await _userManager.FindByIdAsync(id);

        if (user == null)
            return NotFound();
        
        //Getting the associated UserProfile & deleting if it's not null
        var userProfile = await _context.UserProfiles.SingleOrDefaultAsync(up => up.UserId == id);
        if (userProfile != null)
            _context.UserProfiles.Remove(userProfile);
        
        var result = await _userManager.DeleteAsync(user);

        if (!result.Succeeded)
            return BadRequest(result.Errors);
        //Saving the deletion of UserProfile
        await _context.SaveChangesAsync();

        return Ok("User deleted successfully");
    }
}