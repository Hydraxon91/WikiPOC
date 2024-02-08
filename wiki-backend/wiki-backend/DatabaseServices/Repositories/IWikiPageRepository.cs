using wiki_backend.Models;

namespace wiki_backend.DatabaseServices.Repositories;

public interface IWikiPageRepository
{
    Task<IEnumerable<WikiPage>> GetAllAsync();
    Task<IEnumerable<string>> GetAllTitlesAsync();
    Task<WikiPage?> GetByIdAsync(int id);
    Task<WikiPage?> GetByTitleAsync(string title);
    Task AddAsync(WikiPage wikiPage);
    Task AddUserSubmittedPageAsync(UserSubmittedWikiPage wikiPage);
    Task UpdateAsync(WikiPage existingWikiPage, WikiPage updatedWikiPage);
    Task UserSubmittedUpdateAsync(UserSubmittedWikiPage updatedWikiPage);
    Task DeleteAsync(int id);
    Task DeleteUserSubmittedAsync(int id);
}