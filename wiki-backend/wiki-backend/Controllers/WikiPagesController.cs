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
    [HttpPost("admin")]
    public async Task<ActionResult<WikiPage>> CreateWikiPageForAdmin([FromBody] WikiPage wikiPage)
    {
        await _wikiPageRepository.AddAsync(wikiPage);

        return CreatedAtAction(nameof(GetWikiPage), new { id = wikiPage.Id }, wikiPage);
    }
    
    [Authorize(Policy = IdentityData.UserPolicyName)]
    [HttpPost("user")]
    public async Task<ActionResult<WikiPage>> CreateWikiPageForUser([FromBody] UserSubmittedWikiPage wikiPage)
    {
        await _wikiPageRepository.AddUserSubmittedPageAsync(wikiPage);

        return CreatedAtAction(nameof(GetWikiPage), new { id = wikiPage.Id }, wikiPage);
    }
    
    [Authorize(Policy = IdentityData.AdminUserPolicyName)]
    [HttpPost("adminaccept")]
    public async Task<ActionResult<WikiPage>> AcceptCreatedPageForUser([FromBody] UserSubmittedWikiPage userSubmittedWikiPage)
    {
        WikiPage wikiPage = userSubmittedWikiPage;
        
        await _wikiPageRepository.AddAsync(wikiPage);

        await _wikiPageRepository.DeleteUserSubmittedAsync(userSubmittedWikiPage.Id);

        return CreatedAtAction(nameof(GetWikiPage), new { id = wikiPage.Id }, wikiPage);
    }
    
    
    [Authorize(Policy = IdentityData.AdminUserPolicyName)]
    [HttpPut("admin/{id}")]
    public async Task<IActionResult> UpdateWikiPageForAdmin(int id, [FromBody] WikiPage updatedWikiPage)
    {
        var existingWikiPage = await _wikiPageRepository.GetByIdAsync(id);

        if (existingWikiPage == null)
            return NotFound();

        await _wikiPageRepository.UpdateAsync(existingWikiPage, updatedWikiPage);

        return Ok(new { Message = "WikiPage updated successfully" });
    }
    
    [Authorize(Policy = IdentityData.UserPolicyName)]
    [HttpPut("user/{id}")]
    public async Task<IActionResult> UpdateWikiPageForUser([FromBody] UserSubmittedWikiPage updatedWikiPage)
    {
        // var idToGet = updatedWikiPage.WikiPageId;
        // var oldWikiPage = await _wikiPageRepository.GetByIdAsync((int)idToGet);
        if (updatedWikiPage.WikiPage == null)
        {
            return BadRequest("Wikipage is missing from the updatedWikipage");
        }
        await _wikiPageRepository.AddUserSubmittedPageAsync(updatedWikiPage);

        return CreatedAtAction(nameof(GetWikiPage), new { id = updatedWikiPage.Id }, updatedWikiPage);
    }
    [Authorize(Policy = IdentityData.AdminUserPolicyName)]
    [HttpPut("adminaccept/{id}")]
    public async Task<IActionResult> AcceptUpdateWikiPageForUser(int id, [FromBody] UserSubmittedWikiPage userSubmittedWikiPage)
    {
        WikiPage updatedWikiPage = userSubmittedWikiPage;
        var existingWikiPage = await _wikiPageRepository.GetByIdAsync(id);

        if (existingWikiPage == null)
            return NotFound();

        await _wikiPageRepository.UpdateAsync(existingWikiPage, updatedWikiPage);
        await _wikiPageRepository.DeleteUserSubmittedAsync(userSubmittedWikiPage.Id);

        return Ok(new { Message = "WikiPage updated successfully" });
    }
    
    [Authorize(Policy = IdentityData.AdminUserPolicyName)]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteWikiPageForAdmin(int id)
    {
        await _wikiPageRepository.DeleteAsync(id);

        return Ok(new { Message = "WikiPage deleted successfully" });
    }
    
    [Authorize(Policy = IdentityData.AdminUserPolicyName)]
    [HttpDelete("user/{id}")]
    public async Task<IActionResult> DeleteUserSubmittedWikiPage(int id)
    {
        await _wikiPageRepository.DeleteUserSubmittedAsync(id);

        return Ok(new { Message = "WikiPage deleted successfully" });
    }
}