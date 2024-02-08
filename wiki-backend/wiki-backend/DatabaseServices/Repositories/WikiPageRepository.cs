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

        foreach (var updatedParagraph in updatedWikiPage.Paragraphs)
        {
            var existingParagraph = existingWikiPage.Paragraphs.FirstOrDefault(p => p.Id == updatedParagraph.Id);

            if (existingParagraph != null)
            {
                existingParagraph.Title = updatedParagraph.Title;
                existingParagraph.Content = updatedParagraph.Content;
                existingParagraph.ParagraphImage = updatedParagraph.ParagraphImage;
                existingParagraph.ParagraphImageText = updatedParagraph.ParagraphImageText;
                //existingParagraph.WikiPage = updatedWikiPage;
            }
            else
            {
                // Handle the case where a new paragraph is added in the update
                await _context.Paragraphs.AddAsync(updatedParagraph);
                existingWikiPage.Paragraphs.Add(updatedParagraph);
            }
        }

        // Remove paragraphs that are not present in the updatedWikiPage
        var paragraphsToRemove = existingWikiPage.Paragraphs
            .Where(existingParagraph => updatedWikiPage.Paragraphs.All(updatedParagraph => updatedParagraph.Id != existingParagraph.Id))
            .ToList();

        foreach (var paragraphToRemove in paragraphsToRemove)
        {
            _context.Paragraphs.Remove(paragraphToRemove);
            existingWikiPage.Paragraphs.Remove(paragraphToRemove);
        }
        await _context.SaveChangesAsync();
    }

    public async Task UserSubmittedUpdateAsync(UserSubmittedWikiPage updatedWikiPage)
    {
        foreach (var paragraph in updatedWikiPage.Paragraphs)
        {
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
    
    public async Task<IEnumerable<string>> GetSubmittedPageTitlesAsync()
    {
        return await _context.UserSubmittedWikiPages.Where(page => page.IsNewPage).Select(page => page.Title).ToListAsync();
    }
    
    public async Task<UserSubmittedWikiPage?> GetSubmittedPageByTitleAsync(string title)
    {
        return await _context.UserSubmittedWikiPages
            .Where(page => page.IsNewPage==true)
            .Include(p => p.Paragraphs) 
            .FirstOrDefaultAsync(p => p.Title == title);
    }
    
    public async Task<IEnumerable<string>> GetSubmittedUpdateTitlesAsync()
    {
        return await _context.UserSubmittedWikiPages.Where(page => page.IsNewPage==false).Select(page => page.Title).ToListAsync();
    }
    
    public async Task<UserSubmittedWikiPage?> GetSubmittedUpdateByTitleAsync(string title)
    {
        return await _context.UserSubmittedWikiPages
            .Where(page => page.IsNewPage==false)
            .Include(p => p.Paragraphs) 
            .FirstOrDefaultAsync(p => p.Title == title);
    }
}