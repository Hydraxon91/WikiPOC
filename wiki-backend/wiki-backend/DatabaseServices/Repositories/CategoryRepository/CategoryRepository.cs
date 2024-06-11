using Microsoft.EntityFrameworkCore;
using wiki_backend.Models;

namespace wiki_backend.DatabaseServices.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly WikiDbContext _context;

    public CategoryRepository(WikiDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
    {
        return await _context.Categories
            .Include(category => category.WikiPages)
            .ToListAsync();
    }

    public async Task<Category> GetCategoryByNameAsync(string categoryName)
    {
        return await _context.Categories.Include(category => category.WikiPages).FirstOrDefaultAsync(c => c.CategoryName == categoryName);
    }

    public async Task<Category> GetCategoryByIdAsync(Guid categoryId)
    {
        return await _context.Categories.Include(category => category.WikiPages).FirstOrDefaultAsync(c => c.Id == categoryId);
    }

    public async Task<Category> AddCategoryAsync(string categoryName)
    {
        var existingCategory = await _context.Categories.FirstOrDefaultAsync(c => c.CategoryName == categoryName);
        if (existingCategory != null)
        {
            throw new ArgumentException("Category already exists");
        }

        var category = new Category 
        { 
            Id = Guid.NewGuid(), // Generate a new GUID for the category
            CategoryName = categoryName 
        };

        _context.Categories.Add(category);
        await _context.SaveChangesAsync();
        return category;
    }


    public async Task<bool> DeleteCategoryAsync(Guid categoryId)
    {
        var categoryToDelete = await _context.Categories.FindAsync(categoryId);
        if (categoryToDelete == null)
        {
            return false; // Category not found
        }

        _context.Categories.Remove(categoryToDelete);
        await _context.SaveChangesAsync();
        return true; // Category deleted successfully
    }
    
    public async Task AddArticleToCategoryAsync(Guid categoryId, WikiPage wikiPage)
    {
        var category = await _context.Categories
            .Include(c => c.WikiPages)
            .FirstOrDefaultAsync(c => c.Id == categoryId);

        if (category != null)
        {
            // Ensure the WikiPages collection is initialized
            category.WikiPages ??= new List<WikiPage>();
            // Add the wikiPage to the category's WikiPages collection
            category.WikiPages.Add(wikiPage);
            // Update the category in the context
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
        }
    }

    public async Task RemoveArticleFromCategoryAsync(Guid categoryId, Guid wikiPageId)
    {
        var category = await _context.Categories
            .Include(c => c.WikiPages)
            .FirstOrDefaultAsync(c => c.Id == categoryId);

        if (category != null)
        {
            // Find the wikiPage in the category's WikiPages collection
            var wikiPageToRemove = category.WikiPages.FirstOrDefault(wp => wp.Id == wikiPageId);
            if (wikiPageToRemove != null)
            {
                // Remove the wikiPage from the category's WikiPages collection
                category.WikiPages.Remove(wikiPageToRemove);
                // Update the category in the context
                _context.Categories.Update(category);
                await _context.SaveChangesAsync();
            }
        }
    }
}