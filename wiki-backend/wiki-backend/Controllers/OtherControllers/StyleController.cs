using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using wiki_backend.DatabaseServices.Repositories;
using wiki_backend.Identity;
using wiki_backend.Models;

namespace wiki_backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StyleController : ControllerBase
{
    private readonly IStyleRepository _styleRepository;

    public StyleController(IStyleRepository styleRepository)
    {
        _styleRepository = styleRepository;
    }

    [HttpGet]
    public async Task<ActionResult<StyleModel>> GetStyles()
    {
        var styles = await _styleRepository.GetStylesAsync();
        return Ok(styles);
    }

    [Authorize(Policy = IdentityData.AdminUserPolicyName)]
    [HttpPut]
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
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occurred while updating the StyleContext: {ex.Message}");
        }
    }
}