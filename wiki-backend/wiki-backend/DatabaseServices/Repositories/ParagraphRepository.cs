using Microsoft.EntityFrameworkCore;
using wiki_backend.Models;

namespace wiki_backend.DatabaseServices.Repositories;

public class ParagraphRepository : IParagraphRepository
{
    private readonly WikiDbContext _context;

    public ParagraphRepository(WikiDbContext context)
    {
        _context = context;
    }

    public async Task<Paragraph?> GetByIdAsync(int id)
    {
        return await _context.Paragraphs.FindAsync(id);
    }

    public async Task<Paragraph?> CreateAsync(Paragraph paragraph)
    {
        var wikiPage = await _context.WikiPages
            .Include(wp => wp.Paragraphs)
            .FirstOrDefaultAsync(w => w.Id == paragraph.WikiPageId);

        if (wikiPage == null)
        {
            return null; // Or throw an exception indicating that the wiki page was not found
        }

        wikiPage.Paragraphs.Add(paragraph);
        
        await _context.Paragraphs.AddAsync(paragraph);
        await _context.SaveChangesAsync();
        
        return paragraph;
    }
    
    public async Task DeleteAsync(int id)
    {
        var paragraphToDelete = await GetByIdAsync(id);
        if (paragraphToDelete != null)
        {
            _context.Paragraphs.Remove(paragraphToDelete);
            await _context.SaveChangesAsync();
        }
    }
}