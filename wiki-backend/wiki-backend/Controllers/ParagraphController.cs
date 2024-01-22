using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using wiki_backend.DatabaseServices;
using wiki_backend.Models;

namespace wiki_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParagraphController : ControllerBase
    {
        private readonly WikiDbContext _context;

        public ParagraphController(WikiDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Paragraph>> GetParagraph(int id)
        {
            var paragraph = await _context.Paragraphs.FindAsync(id);

            if (paragraph == null)
            {
                return NotFound();
            }

            return paragraph;
        }

        [HttpPost]
        public async Task<ActionResult<Paragraph>> CreateParagraph(Paragraph paragraph)
        {
            var wikiPage = await _context.WikiPages
                .Include(wp => wp.Paragraphs)
                .FirstOrDefaultAsync(w => w.Id == paragraph.WikiPageId);

            if (wikiPage == null)
            {
                return NotFound($"WikiPage with ID {paragraph.WikiPageId} not found.");
            }

            wikiPage.Paragraphs.Add(paragraph);

            _context.Paragraphs.Add(paragraph);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetParagraph), new { id = paragraph.Id }, paragraph);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateParagraph(int id, [FromBody] Paragraph paragraph)
        {
            var existingParagraph = await _context.Paragraphs.FindAsync(id);

            if (existingParagraph == null)
                return NotFound();

            // Update properties of existingParagraph with values from paragraph
            existingParagraph.Title = paragraph.Title;
            existingParagraph.Content = paragraph.Content;
            // Update other properties as needed

            // Explicitly attach the existingParagraph
            _context.Attach(existingParagraph);

            // Update the entity state to Modified
            _context.Entry(existingParagraph).State = EntityState.Modified;

            // Save changes
            await _context.SaveChangesAsync();

            return Ok(existingParagraph);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParagraph(int id)
        {
            var paragraph = await _context.Paragraphs.FindAsync(id);

            if (paragraph == null)
            {
                return NotFound();
            }

            _context.Paragraphs.Remove(paragraph);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ParagraphExists(int id)
        {
            return _context.Paragraphs.Any(e => e.Id == id);
        }
    }
}
