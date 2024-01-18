using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

namespace wiki_backend.Controllers;


[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly UserManager<IdentityUser> _userManager;

    public UsersController(UserManager<IdentityUser> userManager)
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
    public async Task<IActionResult> CreateUser([FromBody] IdentityUser model)
    {
        if (model == null)
            return BadRequest("User data is null");

        var result = await _userManager.CreateAsync(model);

        if (!result.Succeeded)
            return BadRequest(result.Errors);

        return Ok(model);
    }

    [HttpPut("UpdateUser")]
    public async Task<IActionResult> UpdateUser(string id, [FromBody] IdentityUser model)
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