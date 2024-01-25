using Microsoft.AspNetCore.Mvc;
using wiki_backend.DatabaseServices.Repositories;
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

    [HttpPut]
    public async Task<IActionResult> UpdateStyles(StyleModel updatedStyles)
    {
        await _styleRepository.UpdateStylesAsync(updatedStyles);
        return NoContent();
    }
}