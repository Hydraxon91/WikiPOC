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
        return await _context.Categories.ToListAsync();
    }

    public async Task<Category> GetCategoryByNameAsync(string categoryName)
    {
        return await _context.Categories.FirstOrDefaultAsync(c => c.CategoryName == categoryName);
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
}