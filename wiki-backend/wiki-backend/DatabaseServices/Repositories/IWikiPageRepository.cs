﻿using wiki_backend.Models;

namespace wiki_backend.DatabaseServices.Repositories;

public interface IWikiPageRepository
{
    Task<IEnumerable<WikiPage>> GetAllAsync();
    Task<IEnumerable<string>> GetAllTitlesAsync();
    Task<WPWithImagesOutputModel?> GetByIdAsync(Guid id);
    Task<WPWithImagesOutputModel?> GetByTitleAsync(string title);
    Task AddAsync(WikiPage wikiPage, ICollection<ImageFormModel> images);
    Task AddUserSubmittedPageAsync(UserSubmittedWikiPage wikiPage, ICollection<ImageFormModel> images);
    Task UpdateAsync(WikiPage existingWikiPage, WikiPage updatedWikiPage);
    Task AcceptUserSubmittedUpdateAsync(WikiPage existingWikiPage, WikiPage updatedWikiPage);
    Task UserSubmittedUpdateAsync(UserSubmittedWikiPage updatedWikiPage);
    Task DeleteAsync(Guid id);
    Task DeleteUserSubmittedAsync(Guid id);
    Task<IEnumerable<Tuple<string, Guid>>> GetSubmittedPageTitlesAndIdAsync();
    Task<WPWithImagesOutputModel?> GetSubmittedPageByIdAsync(Guid id);
    Task<IEnumerable<Tuple<string, Guid>>> GetSubmittedUpdateTitlesAndIdAsync();
    Task<WPWithImagesOutputModel?> GetSubmittedUpdateByIdAsync(Guid id);
}