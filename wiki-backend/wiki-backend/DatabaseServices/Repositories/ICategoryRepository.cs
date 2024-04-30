using wiki_backend.Models;

namespace wiki_backend.DatabaseServices.Repositories;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetAllCategoriesAsync();
    Task<Category> GetCategoryByNameAsync(string categoryName);
    Task<Category> AddCategoryAsync(Category category);
    Task<bool> DeleteCategoryAsync(Guid categoryId);
}