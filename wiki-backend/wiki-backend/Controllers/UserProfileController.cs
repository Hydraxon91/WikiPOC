using Microsoft.AspNetCore.Mvc;
using wiki_backend.DatabaseServices.Repositories;
using wiki_backend.Models;

namespace wiki_backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserProfileController : ControllerBase
{
    private readonly IUserProfileRepository _profileRepository;

    public UserProfileController(IUserProfileRepository profileRepository)
    {
        _profileRepository = profileRepository;
    }
    
    [HttpGet("GetById/{id:int}")]
    public async Task<ActionResult<UserProfile>> GetProfileById(int id)
    {
        var profile = await _profileRepository.GetByIdAsync(id);

        if (profile == null)
            return NotFound();

        return Ok(profile);
    }
    
    [HttpGet("GetByUsername/{username}")]
    public async Task<ActionResult<UserProfile>> GetProfileByName(string username)
    {
        var profile = await _profileRepository.GetByUsernameAsync(username);

        if (profile == null)
            return NotFound();

        return Ok(profile);
    }
    
    [HttpGet("GetByUserId/{userid}")]
    public async Task<ActionResult<UserProfile>> GetProfileByUserId(string userid)
    {
        var profile = await _profileRepository.GetByUserIdAsync(userid);

        if (profile == null)
            return NotFound();

        return Ok(profile);
    }
    
    [HttpPut("UpdateProfile/{id:int}")]
    public async Task<IActionResult> UpdateWikiPageForAdmin(int id, [FromBody] UserProfile updatedProfile)
    {
        await _profileRepository.UpdateAsync(id, updatedProfile);

        return Ok(new { Message = "WikiPage updated successfully" });
    }
    
    [HttpDelete("DeleteUserProfile")]
    public async Task<IActionResult> DeleteUserProfile(int id)
    {
        await _profileRepository.DeleteAsync(id);
        
        return Ok("UserProfile deleted successfully");
    }
}