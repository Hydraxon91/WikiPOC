using Azure;
using Microsoft.EntityFrameworkCore;
using wiki_backend.Models;

namespace wiki_backend.DatabaseServices.Repositories;

public class WikiPageRepository : IWikiPageRepository
{
    private readonly WikiDbContext _context;

    public WikiPageRepository(WikiDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<string>> GetAllTitlesAsync()
    {
        var titles = await _context.WikiPages.Where(page => !(page is UserSubmittedWikiPage)).Select(page => page.Title).ToListAsync();
        return titles;
    }
    public async Task<IEnumerable<WikiPage>> GetAllAsync()
    {
        return await _context.WikiPages.Include(wp => wp.Paragraphs).ToListAsync();
    }

    public async Task<WikiPage?> GetByIdAsync(int id)
    {
        return await _context.WikiPages
            .Include(wp => wp.Paragraphs)
            .SingleOrDefaultAsync(wp => wp.Id == id);
    }

    public async Task<WikiPage?> GetByTitleAsync(string title)
    {
        return await _context.WikiPages
            .Where(page => !(page is UserSubmittedWikiPage))
            .Include(p => p.Paragraphs) 
            .FirstOrDefaultAsync(p => p.Title == title);
    }

    public async Task AddAsync(WikiPage wikiPage)
    {
        foreach (var paragraph in wikiPage.Paragraphs)
        {
            paragraph.Id = 0;
            paragraph.WikiPage = wikiPage;
            paragraph.WikiPageId = wikiPage.Id;
        }
        _context.WikiPages.Add(wikiPage);
        await _context.SaveChangesAsync();
    }

    public async Task AddUserSubmittedPageAsync(UserSubmittedWikiPage wikiPage)
    {
        foreach (var paragraph in wikiPage.Paragraphs)
        {
            paragraph.WikiPage = wikiPage;
            paragraph.WikiPageId = wikiPage.Id;
        }
        _context.UserSubmittedWikiPages.Add(wikiPage);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(WikiPage existingWikiPage, WikiPage updatedWikiPage)
    {
        existingWikiPage.Title = updatedWikiPage.Title;
        existingWikiPage.RoleNote = updatedWikiPage.RoleNote;
        existingWikiPage.SiteSub = updatedWikiPage.SiteSub;
        
        // Remove paragraphs that are not present in the updatedWikiPage
        var paragraphsToRemove = existingWikiPage.Paragraphs
            .Where(existingParagraph => updatedWikiPage.Paragraphs.All(updatedParagraph => updatedParagraph.Id != existingParagraph.Id))
            .ToList();
        
        foreach (var paragraphToRemove in paragraphsToRemove)
        {
            _context.Paragraphs.Remove(paragraphToRemove);
            existingWikiPage.Paragraphs.Remove(paragraphToRemove);
        }

        // Create a dictionary for efficient lookup
        var existingParagraphsDict = existingWikiPage.Paragraphs.ToDictionary(p => p.Id);

        foreach (var updatedParagraph in updatedWikiPage.Paragraphs)
        {
            // Check if the updated paragraph exists
            if (existingParagraphsDict.TryGetValue(updatedParagraph.Id, out var existingParagraph))
            {
                // Update existing paragraph
                existingParagraph.Title = updatedParagraph.Title;
                existingParagraph.Content = updatedParagraph.Content;
                existingParagraph.ParagraphImage = updatedParagraph.ParagraphImage;
                existingParagraph.ParagraphImageText = updatedParagraph.ParagraphImageText;
            }
            else
            {
                // Create a new instance of Paragraph
                var newParagraph = new Paragraph
                {
                    Title = updatedParagraph.Title,
                    Content = updatedParagraph.Content,
                    ParagraphImage = updatedParagraph.ParagraphImage,
                    ParagraphImageText = updatedParagraph.ParagraphImageText,
                    WikiPageId = existingWikiPage.Id
                };

                // Add the new instance to both collections
                _context.Paragraphs.Add(newParagraph);
                existingWikiPage.Paragraphs.Add(newParagraph);
            }
        }

        await _context.SaveChangesAsync();
    }

    public async Task AcceptUserSubmittedUpdateAsync(WikiPage existingWikiPage, WikiPage updatedWikiPage)
    {
        existingWikiPage.Title = updatedWikiPage.Title;
        existingWikiPage.RoleNote = updatedWikiPage.RoleNote;
        existingWikiPage.SiteSub = updatedWikiPage.SiteSub;
        
        // Remove paragraphs that are not present in the updatedWikiPage
        var paragraphsToRemove = existingWikiPage.Paragraphs
            .Where(existingParagraph => updatedWikiPage.Paragraphs.All(updatedParagraph => updatedParagraph.Id != existingParagraph.Id))
            .ToList();

        foreach (var paragraphToRemove in paragraphsToRemove)
        {
            _context.Paragraphs.Remove(paragraphToRemove);
            existingWikiPage.Paragraphs.Remove(paragraphToRemove);
        }
        
        // Create a dictionary for efficient lookup
    var existingParagraphsDict = existingWikiPage.Paragraphs.ToDictionary(p => p.Id);

    foreach (var updatedParagraph in updatedWikiPage.Paragraphs)
    {
        // Check if the updated paragraph exists
        if (existingParagraphsDict.TryGetValue(updatedParagraph.Id, out var existingParagraph))
        {
            // Update existing paragraph
            existingParagraph.Title = updatedParagraph.Title;
            existingParagraph.Content = updatedParagraph.Content;
            existingParagraph.ParagraphImage = updatedParagraph.ParagraphImage;
            existingParagraph.ParagraphImageText = updatedParagraph.ParagraphImageText;
        }
        else
        {
            // Create a new instance of Paragraph
            var newParagraph = new Paragraph
            {
                Title = updatedParagraph.Title,
                Content = updatedParagraph.Content,
                ParagraphImage = updatedParagraph.ParagraphImage,
                ParagraphImageText = updatedParagraph.ParagraphImageText,
                WikiPageId = existingWikiPage.Id
            };

            // Add the new instance to both collections
            _context.Paragraphs.Add(newParagraph);
            existingWikiPage.Paragraphs.Add(newParagraph);
        }
    }

    await _context.SaveChangesAsync();
    }
    public async Task UserSubmittedUpdateAsync(UserSubmittedWikiPage updatedWikiPage)
    {
        foreach (var paragraph in updatedWikiPage.Paragraphs)
        {
            paragraph.Id = 0;
            paragraph.WikiPage = updatedWikiPage;
            paragraph.WikiPageId = updatedWikiPage.Id;
        }
        _context.UserSubmittedWikiPages.Add(updatedWikiPage);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var wikiPage = await _context.WikiPages.Include(wp => wp.Paragraphs).SingleOrDefaultAsync(wp => wp.Id == id);

        if (wikiPage != null)
        {
            _context.Paragraphs.RemoveRange(wikiPage.Paragraphs);
            _context.WikiPages.Remove(wikiPage);
            await _context.SaveChangesAsync();
        }
    }

    public async Task DeleteUserSubmittedAsync(int id)
    {
        var wikiPage = await _context.UserSubmittedWikiPages.Include(wp => wp.Paragraphs).SingleOrDefaultAsync(wp => wp.Id == id);

        if (wikiPage != null)
        {
            _context.Paragraphs.RemoveRange(wikiPage.Paragraphs);
            _context.WikiPages.Remove(wikiPage);
            await _context.SaveChangesAsync();
        }
    }
    
    public async Task<IEnumerable<Tuple<string, int>>> GetSubmittedPageTitlesAndIdAsync()
    {
        return await _context.UserSubmittedWikiPages.Where(page => page.IsNewPage).Select(page => new Tuple<string, int>(page.Title, page.Id)).ToListAsync();
    }
    
    public async Task<UserSubmittedWikiPage?> GetSubmittedPageByIdAsync(int id)
    {
        return await _context.UserSubmittedWikiPages
            .Where(page => page.IsNewPage==true)
            .Include(p => p.Paragraphs) 
            .FirstOrDefaultAsync(p => p.Id == id);
    }
    
    public async Task<IEnumerable<Tuple<string, int>>> GetSubmittedUpdateTitlesAndIdAsync()
    {
        return await _context.UserSubmittedWikiPages.Where(page => page.IsNewPage==false).Select(page => new Tuple<string, int>(page.Title, page.Id)).ToListAsync();
    }
    
    public async Task<UserSubmittedWikiPage?> GetSubmittedUpdateByIdAsync(int id)
    {
        return await _context.UserSubmittedWikiPages
            .Where(page => page.IsNewPage==false)
            .Include(p => p.Paragraphs) 
            .FirstOrDefaultAsync(p => p.Id == id);
    }
}