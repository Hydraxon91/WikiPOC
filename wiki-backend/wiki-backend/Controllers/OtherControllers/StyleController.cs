using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using wiki_backend.DatabaseServices.Repositories;
using wiki_backend.Identity;
using wiki_backend.Models;

namespace wiki_backend.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/[controller]")]
public class StyleController : ControllerBase
{
    private readonly IStyleRepository _styleRepository;

    public StyleController(IStyleRepository styleRepository)
    {
        _styleRepository = styleRepository;
    }

    [HttpGet]
    public async Task<ActionResult<StyleModel>> GetActiveStyles()
    {
        try
        {
            var styles = await _styleRepository.GetActiveStylesAsync();
            return Ok(styles);
        }
        catch (InvalidOperationException)
        {
            return NotFound("No active theme configured.");
        }
    }

    [HttpGet("presets")]
    public async Task<ActionResult<List<StyleModel>>> GetSystemPresets()
    {
        var presets = await _styleRepository.GetSystemPresetsAsync();
        return Ok(presets);
    }

    [HttpGet("user-themes/{userId}")]
    [Authorize]
    public async Task<ActionResult<List<StyleModel>>> GetUserThemes(string userId)
    {
        var themes = await _styleRepository.GetUserThemesAsync(userId);
        return Ok(themes);
    }

    [HttpPost("user-themes")]
    [Authorize]
    public async Task<ActionResult<StyleModel>> CreateUserTheme([FromBody] StyleModel theme)
    {
        var created = await _styleRepository.CreateUserThemeAsync(theme);
        return CreatedAtAction(nameof(GetActiveStyles), new { id = created.Id }, created);
    }

    [HttpDelete("user-themes/{id}")]
    [Authorize]
    public async Task<IActionResult> DeleteUserTheme(int id)
    {
        await _styleRepository.DeleteUserThemeAsync(id);
        return NoContent();
    }

    [HttpPut("activate/{id}")]
    [Authorize(Policy = IdentityData.AdminUserPolicyName)]
    public async Task<IActionResult> ActivateTheme(int id)
    {
        await _styleRepository.ActivateThemeAsync(id);
        return Ok(new { Message = "Theme activated" });
    }

    [Authorize(Policy = IdentityData.AdminUserPolicyName)]
    [HttpPut]
    [RequestSizeLimit(2 * 1024 * 1024)]
    public async Task<IActionResult> UpdateStyles([FromForm] StyleUpdateForm styleUpdateForm)
    {
        if (styleUpdateForm.StyleModel == null)
        {
            return BadRequest("Invalid request. StyleModel object is null.");
        }
        try
        {
            await _styleRepository.UpdateStylesAsync(styleUpdateForm.StyleModel, styleUpdateForm.LogoPictureFile);
            return Ok(new { Message = "StyleContext updated successfully" });
        }
        catch (Exception)
        {
            return StatusCode(500, "An error occurred while updating the StyleContext.");
        }
    }
}
