using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using wiki_backend.DatabaseServices.Repositories;
using wiki_backend.Identity;
using wiki_backend.Models;

namespace wiki_backend.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/[controller]")]
public class UserProfileController : ControllerBase
{
    private readonly IUserProfileRepository _profileRepository;

    public UserProfileController(IUserProfileRepository profileRepository)
    {
        _profileRepository = profileRepository;
    }
    
    [HttpGet("GetById/{id:guid}")]
    public async Task<ActionResult<UserProfile>> GetProfileById(Guid id)
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
    
    [Authorize(Policy = IdentityData.AdminUserPolicyName)]
    [HttpPut("UpdateProfile/{id:guid}")]
    [RequestSizeLimit(10 * 1024 * 1024)]
    public async Task<IActionResult> UpdateUserProfile(Guid id, [FromForm] UserUpdateForm userUpdateForm)
    {
        if (userUpdateForm.UserProfile == null)
        {
            return BadRequest("Invalid request. UserProfile object is null.");
        }
        
        try
        {
            await _profileRepository.UpdateAsync(id, userUpdateForm.UserProfile, userUpdateForm.ProfilePictureFile);
            return Ok(new { Message = "UserProfile updated successfully" });
        }
        catch (Exception)
        {
            return StatusCode(500, "An error occurred while updating the UserProfile.");
        }
    }
    
    [Authorize(Policy = IdentityData.AdminUserPolicyName)]
    [HttpDelete("DeleteUserProfile/{id:guid}")]
    public async Task<IActionResult> DeleteUserProfile(Guid id)
    {
        var userProfile = await _profileRepository.GetByIdAsync(id);
        if (userProfile == null)
        {
            return NotFound();
        }

        await _profileRepository.DeleteAsync(id);
        
        return Ok("UserProfile deleted successfully");
    }

}