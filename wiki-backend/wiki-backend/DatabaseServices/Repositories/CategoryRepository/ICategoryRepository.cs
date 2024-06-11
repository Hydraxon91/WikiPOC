using wiki_backend.Models;

namespace wiki_backend.DatabaseServices.Repositories;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetAllCategoriesAsync();
    Task<Category> GetCategoryByNameAsync(string categoryName);
    Task<Category> GetCategoryByIdAsync(Guid categoryId);
    Task<Category> AddCategoryAsync(string categoryName);
    Task<bool> DeleteCategoryAsync(Guid categoryId);
    Task AddArticleToCategoryAsync(Guid categoryId, WikiPage wikiPage);
    Task RemoveArticleFromCategoryAsync(Guid categoryId, Guid wikiPageId);
}