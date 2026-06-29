using wiki_backend.Models;

namespace wiki_backend.DatabaseServices.Repositories;

public interface IWikiPageRepository
{
    Task<IEnumerable<WikiPage>> GetAllAsync();
    Task<List<TitleAndCategory>> GetAllTitlesAndCategoriesAsync();
    Task<WPWithImagesOutputModel?> GetByIdAsync(Guid id);
    Task<WPWithImagesOutputModel?> GetBySlugAsync(string slug);
    Task AddAsync(WikiPage wikiPage, ICollection<ImageFormModel> images);
    Task AddUserSubmittedPageAsync(UserSubmittedWikiPage wikiPage, ICollection<ImageFormModel> images);
    Task AcceptUserSubmittedWikiPage(UserSubmittedWikiPage userSubmittedWikiPage);
    Task UpdateAsync(WikiPage existingWikiPage, WikiPage updatedWikiPage, ICollection<ImageFormModel> images);
    Task AcceptUserSubmittedUpdateAsync(UserSubmittedWikiPage updatedWikiPage);
    Task UserSubmittedUpdateAsync(UserSubmittedWikiPage updatedWikiPage, ICollection<ImageFormModel> images);
    Task<bool> DeleteAsync(Guid id);
    Task<bool> DeleteUserSubmittedAsync(Guid id, Guid? newId);
    Task<IEnumerable<WikiPageTitleEntry>> GetSubmittedPageTitlesAndIdAsync();
    Task<WPWithImagesOutputModel?> GetSubmittedPageByIdAsync(Guid id);
    Task<IEnumerable<WikiPageTitleEntry>> GetSubmittedUpdateTitlesAndIdAsync();
    Task<WPWithImagesOutputModel?> GetSubmittedUpdateByIdAsync(Guid id);
}