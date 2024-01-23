using wiki_backend.Models;

namespace wiki_backend.DatabaseServices.Repositories;

public interface IWikiPageRepository
{
    Task<IEnumerable<WikiPage>> GetAllAsync();
    Task<WikiPage?> GetByIdAsync(int id);
    Task AddAsync(WikiPage wikiPage);
    Task UpdateAsync(WikiPage existingWikiPage, WikiPage updatedWikiPage);
    Task DeleteAsync(int id);
}