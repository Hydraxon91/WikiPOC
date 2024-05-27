using wiki_backend.Models;

namespace wiki_backend.DatabaseServices.Repositories;

public interface IStyleRepository
{
    Task<StyleModel> GetStylesAsync();
    Task UpdateStylesAsync(StyleModel updatedStyles, IFormFile? logoPictureFile);
}