﻿using Microsoft.EntityFrameworkCore;
using wiki_backend.Models;

namespace wiki_backend.DatabaseServices.Repositories;

public class WikiPageRepository : IWikiPageRepository
{
    private readonly WikiDbContext _context;

    public WikiPageRepository(WikiDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<WikiPage>> GetAllAsync()
    {
        return await _context.WikiPages.Include(wp => wp.Paragraphs).ToListAsync();
    }

    public async Task<WikiPage?> GetByIdAsync(int id)
    {
        return await _context.WikiPages.Include(wp => wp.Paragraphs).SingleOrDefaultAsync(wp => wp.Id == id);
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
}