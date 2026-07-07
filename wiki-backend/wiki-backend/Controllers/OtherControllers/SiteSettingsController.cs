using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using wiki_backend.DatabaseServices.Repositories;
using wiki_backend.Identity;
using wiki_backend.Models;

namespace wiki_backend.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/[controller]")]
public class SiteSettingsController : ControllerBase
{
    private readonly ISiteSettingsRepository _repository;

    public SiteSettingsController(ISiteSettingsRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<ActionResult<SiteSettings>> Get()
    {
        var settings = await _repository.GetAsync();
        return Ok(settings);
    }

    [Authorize(Policy = IdentityData.AdminUserPolicyName)]
    [HttpPut]
    [RequestSizeLimit(2 * 1024 * 1024)]
    public async Task<IActionResult> Update([FromForm] string? wikiName, IFormFile? logoFile)
    {
        await _repository.UpdateAsync(wikiName, logoFile);
        return Ok(new { Message = "Site settings updated" });
    }
}
