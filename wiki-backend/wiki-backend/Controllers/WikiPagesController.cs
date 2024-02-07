using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using wiki_backend.DatabaseServices;
using wiki_backend.DatabaseServices.Repositories;
using wiki_backend.Identity;
using wiki_backend.Models;

namespace wiki_backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WikiPagesController : ControllerBase
{
    private readonly IWikiPageRepository _wikiPageRepository;
    
    public WikiPagesController(IWikiPageRepository wikiPageRepository)
    {
        _wikiPageRepository = wikiPageRepository;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<WikiPage>>> GetWikiPages()
    {
        var wikiPages = await _wikiPageRepository.GetAllAsync();
        return Ok(wikiPages);
    }
    
    [HttpGet("GetTitles")]
    public async Task<ActionResult<IEnumerable<string>>> GetWikiPageTitles()
    {
        var wikiPageTitles = await _wikiPageRepository.GetAllTitlesAsync();
        return Ok(wikiPageTitles);
    }

    [HttpGet("GetById/{id}")]
    public async Task<ActionResult<WikiPage>> GetWikiPage(int id)
    {
        var wikiPage = await _wikiPageRepository.GetByIdAsync(id);

        if (wikiPage == null)
            return NotFound();

        return Ok(wikiPage);
    }
    
    [HttpGet("GetByTitle/{title}")]
    public async Task<ActionResult<WikiPage>> GetWikiPageByTitle(string title)
    {
        var wikiPage = await _wikiPageRepository.GetByTitleAsync(title);

        if (wikiPage == null)
        {
            return NotFound(); // Return 404 if the page is not found
        }

        return Ok(wikiPage);
    }
    
    [HttpGet("{id}/paragraphs")]
    public async Task<ActionResult<IEnumerable<Paragraph>>> GetWikiPageParagraphs(int id)
    {
        var wikiPage = await _wikiPageRepository.GetByIdAsync(id);

        if (wikiPage == null)
            return NotFound();

        // Check if Paragraphs is null, and return an empty list if it is
        var paragraphs = wikiPage.Paragraphs ?? new List<Paragraph>();

        return Ok(paragraphs);
    }
    
    [Authorize(Policy = IdentityData.AdminUserPolicyName)]
    [HttpPost]
    public async Task<ActionResult<WikiPage>> CreateWikiPage([FromBody] WikiPage wikiPage)
    {
        await _wikiPageRepository.AddAsync(wikiPage);

        return CreatedAtAction(nameof(GetWikiPage), new { id = wikiPage.Id }, wikiPage);
    }
    [Authorize(Policy = IdentityData.AdminUserPolicyName)]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateWikiPage(int id, [FromBody] WikiPage updatedWikiPage)
    {
        var existingWikiPage = await _wikiPageRepository.GetByIdAsync(id);

        if (existingWikiPage == null)
            return NotFound();

        await _wikiPageRepository.UpdateAsync(existingWikiPage, updatedWikiPage);

        return NoContent();
    }

    [Authorize(Policy = IdentityData.AdminUserPolicyName)]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteWikiPage(int id)
    {
        await _wikiPageRepository.DeleteAsync(id);

        return NoContent();
    }
}