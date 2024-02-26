using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using wiki_backend.Models;

namespace wiki_backend.Controllers;


[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;

    public UsersController(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }
    
    [HttpGet("GetUsers")]
    public IActionResult GetUsers()
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

    [HttpDelete("DeleteUser")]
    public async Task<IActionResult> DeleteUser(string id)
    {
        var user = await _userManager.FindByIdAsync(id);

        if (user == null)
            return NotFound();

        var result = await _userManager.DeleteAsync(user);

        if (!result.Succeeded)
            return BadRequest(result.Errors);

        return Ok("User deleted successfully");
    }
}