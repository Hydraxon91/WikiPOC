using Microsoft.EntityFrameworkCore;
using wiki_backend.Models;
using wiki_backend.Services.Storage;

namespace wiki_backend.DatabaseServices.Repositories;

public class WikiPageRepository : IWikiPageRepository
{
    private readonly WikiDbContext _context;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IImageStorageService _imageStorage;

    public WikiPageRepository(WikiDbContext context, ICategoryRepository categoryRepository, IImageStorageService imageStorage)
    {
        _context = context;
        _categoryRepository = categoryRepository;
        _imageStorage = imageStorage;
    }

    public async Task<List<TitleAndCategory>> GetAllTitlesAndCategoriesAsync()
    {
        var titlesAndCategories = await _context.WikiPages
            .Where(page => !(page is UserSubmittedWikiPage) ||
                           _context.UserSubmittedWikiPages.Any(userPage => page.Id == userPage.Id && userPage.Approved))
            .Select(page => new TitleAndCategory
            {
                Title = page.Title ?? "Untitled",
                Category = page.Category!.CategoryName ?? "Uncategorized"
            })
            .ToListAsync();

        return titlesAndCategories;
    }

    public async Task<IEnumerable<WikiPage>> GetAllAsync()
    {
        return await _context.WikiPages
            .Include(wp => wp.Paragraphs)
            .ToListAsync();
    }

    public async Task<WPWithImagesOutputModel?> GetByIdAsync(Guid id)
    {
        var wikiPage = await _context.WikiPages
            .Include(wp => wp.Paragraphs)
            .Include(wp => wp.Comments)
            .ThenInclude(uc => uc.UserProfile)
            .Include(wp => wp.Comments)
            .ThenInclude(uc => uc.Replies)
            .SingleOrDefaultAsync(wp => wp.Id == id);

        if (wikiPage != null)
        {
            var images = _imageStorage.ReadImages(wikiPage.Id);
            return new WPWithImagesOutputModel
            {
                WikiPage = wikiPage,
                Images = images.Count > 0 ? images : null
            };
        }

        return null;
    }

    public async Task<WPWithImagesOutputModel?> GetByTitleAsync(string title)
    {
        var wikiPage = await _context.WikiPages
            .Where(page =>
                !(page is UserSubmittedWikiPage) ||
                (_context.UserSubmittedWikiPages.Any(userPage => userPage.Id == page.Id && userPage.Approved)))
            .Include(p => p.Paragraphs)
            .Include(wp => wp.Comments)
            .ThenInclude(uc => uc.UserProfile)
            .FirstOrDefaultAsync(p => p.Title == title);

        if (wikiPage != null)
        {
            var images = _imageStorage.ReadImages(wikiPage.Id);
            return new WPWithImagesOutputModel
            {
                WikiPage = wikiPage,
                Images = images.Count > 0 ? images : null
            };
        }

        return null;
    }

    public async Task AddAsync(WikiPage wikiPage, ICollection<ImageFormModel> images)
    {
        await _imageStorage.SaveImagesAsync(wikiPage.Id, images);

        foreach (var paragraph in wikiPage.Paragraphs)
        {
            paragraph.Id = Guid.NewGuid();
            paragraph.WikiPage = wikiPage;
            paragraph.WikiPageId = wikiPage.Id;
        }

        await _categoryRepository.AddArticleToCategoryAsync(wikiPage.CategoryId!.Value, wikiPage);

        await _context.SaveChangesAsync();
    }

    public async Task AddUserSubmittedPageAsync(UserSubmittedWikiPage wikiPage, ICollection<ImageFormModel> images)
    {
        await _imageStorage.SaveImagesAsync(wikiPage.Id, images);

        foreach (var paragraph in wikiPage.Paragraphs)
        {
            paragraph.Id = Guid.NewGuid();
            paragraph.WikiPage = wikiPage;
            paragraph.WikiPageId = wikiPage.Id;
        }

        _context.UserSubmittedWikiPages.Add(wikiPage);
        await _context.SaveChangesAsync();
    }

    public async Task AcceptUserSubmittedWikiPage(UserSubmittedWikiPage userSubmittedWikiPage)
    {
        _context.Entry(userSubmittedWikiPage).State = EntityState.Modified;
        userSubmittedWikiPage.Approved = true;
        // Add the article to the category
        await _categoryRepository.AddArticleToCategoryAsync(userSubmittedWikiPage.CategoryId!.Value,
            userSubmittedWikiPage);
        await _context.SaveChangesAsync();
    }


    public async Task UpdateAsync(WikiPage existingWikiPage, WikiPage updatedWikiPage,
        ICollection<ImageFormModel> images)
    {
        existingWikiPage.Title = updatedWikiPage.Title;
        existingWikiPage.RoleNote = updatedWikiPage.RoleNote;
        existingWikiPage.SiteSub = updatedWikiPage.SiteSub;
        existingWikiPage.Content = updatedWikiPage.Content;
        existingWikiPage.CategoryId = updatedWikiPage.CategoryId;
        existingWikiPage.LegacyWikiPage = updatedWikiPage.LegacyWikiPage;
        existingWikiPage.LastUpdateDate = DateTime.Now;

        // Remove paragraphs that are not present in the updatedWikiPage
        var paragraphsToRemove = existingWikiPage.Paragraphs
            .Where(existingParagraph =>
                updatedWikiPage.Paragraphs.All(updatedParagraph => updatedParagraph.Id != existingParagraph.Id))
            .ToList();

        foreach (var paragraphToRemove in paragraphsToRemove)
        {
            _context.Entry(paragraphToRemove).State = EntityState.Deleted;
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

        await _imageStorage.SaveImagesAsync(existingWikiPage.Id, images);

        await _context.SaveChangesAsync();
    }

    public async Task AcceptUserSubmittedUpdateAsync(UserSubmittedWikiPage userSubmittedWikiPage)
    {
        // Set Approved to true
        userSubmittedWikiPage.Approved = true;
        // Add the new article to the category
        await _categoryRepository.AddArticleToCategoryAsync(userSubmittedWikiPage.CategoryId!.Value,
            userSubmittedWikiPage);

        await _context.SaveChangesAsync();
    }

    public async Task UserSubmittedUpdateAsync(UserSubmittedWikiPage updatedWikiPage,
        ICollection<ImageFormModel> images)
    {
        foreach (var paragraph in updatedWikiPage.Paragraphs)
        {
            paragraph.Id = Guid.NewGuid();
            paragraph.WikiPage = updatedWikiPage;
            paragraph.WikiPageId = updatedWikiPage.Id;
        }

        await _imageStorage.SaveImagesAsync(updatedWikiPage.Id, images);

        _context.UserSubmittedWikiPages.Add(updatedWikiPage);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var wikiPage = await _context.WikiPages
            .Include(wp => wp.Paragraphs)
            .Include(wp => wp.Comments)
            .SingleOrDefaultAsync(wp => wp.Id == id);

        if (wikiPage != null)
        {
            _imageStorage.DeleteImageDirectory(wikiPage.Id);

            // Remove the old article from the category
            if (wikiPage.CategoryId.HasValue)
            {
                // Remove the old article from the category
                await _categoryRepository.RemoveArticleFromCategoryAsync(wikiPage.CategoryId.Value, wikiPage.Id);
            }
            // Remove paragraphs and the wiki page itself
            _context.Paragraphs.RemoveRange(wikiPage.Paragraphs);
            _context.WikiPages.Remove(wikiPage);
            await _context.SaveChangesAsync();
            return true;
        }
        return false;
    }

    public async Task<bool> DeleteUserSubmittedAsync(Guid id, Guid? newId)
    {
        var wikiPage = await _context.UserSubmittedWikiPages
            .Include(wp => wp.Paragraphs)
            .Include(wp => wp.Comments)
            .SingleOrDefaultAsync(wp => wp.Id == id);

        if (wikiPage != null)
        {
            _context.Paragraphs.RemoveRange(wikiPage.Paragraphs);
            _context.WikiPages.Remove(wikiPage);
            await _context.SaveChangesAsync();
            
            if (newId != null)
            {
                _imageStorage.MoveImageDirectory(id, newId.Value);
            }
            else
            {
                _imageStorage.DeleteImageDirectory(id);
            }

            return true;
        }

        return false;
    }
    
    public async Task<IEnumerable<WikiPageTitleEntry>> GetSubmittedPageTitlesAndIdAsync()
    {
        return await _context.UserSubmittedWikiPages.Where(page => page.IsNewPage && !page.Approved).Select(page => new WikiPageTitleEntry(page.Title!, page.Id)).ToListAsync();
    }
    
    public async Task<WPWithImagesOutputModel?> GetSubmittedPageByIdAsync(Guid id)
    {
        var wikiPage = await _context.UserSubmittedWikiPages
            .Where(page => page.IsNewPage)
            .Include(p => p.Paragraphs)
            .Include(wp => wp.Comments)
            .ThenInclude(uc => uc.UserProfile)
            .FirstOrDefaultAsync(p => p.Id == id);
        
        if (wikiPage!=null)
        {
            var images = _imageStorage.ReadImages(wikiPage.Id);
            return new WPWithImagesOutputModel
            {
                UserSubmittedWikiPage = wikiPage,
                Images = images.Count > 0 ? images : null
            };
        }

        return null;
    }
    
    public async Task<IEnumerable<WikiPageTitleEntry>> GetSubmittedUpdateTitlesAndIdAsync()
    {
        return await _context.UserSubmittedWikiPages.Where(page => !page.IsNewPage && !page.Approved).Select(page => new WikiPageTitleEntry(page.Title!, page.Id)).ToListAsync();
    }
    
    public async Task<WPWithImagesOutputModel?> GetSubmittedUpdateByIdAsync(Guid id)
    {
        var wikiPage = await _context.UserSubmittedWikiPages
            .Where(page => !page.IsNewPage)
            .Include(p => p.Paragraphs)
            .Include(wp => wp.Comments)
            .ThenInclude(uc => uc.UserProfile)
            .FirstOrDefaultAsync(p => p.Id == id);
        
        if (wikiPage!=null)
        {
            var images = _imageStorage.ReadImages(wikiPage.Id);
            return new WPWithImagesOutputModel
            {
                UserSubmittedWikiPage = wikiPage,
                Images = images.Count > 0 ? images : null
            };
        }

        return null;
    }
}