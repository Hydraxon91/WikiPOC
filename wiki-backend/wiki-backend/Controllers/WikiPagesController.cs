using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using wiki_backend.DatabaseServices;
using wiki_backend.Models;

namespace wiki_backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WikiPagesController : ControllerBase
{
    private readonly WikiDbContext _context;
    
    public WikiPagesController(WikiDbContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    public ActionResult<IEnumerable<WikiPage>> GetWikiPages()
    {
        var wikiPages = _context.WikiPages.ToList();
        return Ok(wikiPages);
    }

    [HttpGet("{id}")]
    public ActionResult<WikiPage> GetWikiPage(int id)
    {
        var wikiPage = _context.WikiPages.Find(id);

        if (wikiPage == null)
            return NotFound();

        return Ok(wikiPage);
    }
    
    [HttpGet("{id}/paragraphs")]
    public ActionResult<WikiPage> GetWikiPageParagraphs(int id)
    {
        var wikiPage = _context.WikiPages.Include(wp => wp.Paragraphs).FirstOrDefault(wp => wp.Id == id);

        if (wikiPage == null)
            return NotFound();

        // Check if Paragraphs is null, and return an empty list if it is
        var paragraphs = wikiPage.Paragraphs ?? new List<Paragraph>();

        return Ok(paragraphs);
    }
    
    [HttpPost]
    public ActionResult<WikiPage> CreateWikiPage([FromBody] WikiPage wikiPage)
    {
        _context.WikiPages.Add(wikiPage);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetWikiPage), new { id = wikiPage.Id }, wikiPage);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateWikiPage(int id, [FromBody] WikiPage updatedWikiPage)
    {
        var existingWikiPage = _context.WikiPages.Find(id);

        if (existingWikiPage == null)
            return NotFound();

        existingWikiPage.Title = updatedWikiPage.Title;

        _context.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteWikiPage(int id)
    {
        var wikiPageToDelete = _context.WikiPages.Find(id);

        if (wikiPageToDelete == null)
            return NotFound();

        _context.WikiPages.Remove(wikiPageToDelete);
        _context.SaveChanges();

        return NoContent();
    }
}