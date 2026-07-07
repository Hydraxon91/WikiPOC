using wiki_backend.Models;

namespace wiki_backend.DatabaseServices.Repositories;

public interface IStyleRepository
{
    Task<StyleModel> GetActiveStylesAsync();
    Task<List<StyleModel>> GetSystemPresetsAsync();
    Task<List<StyleModel>> GetUserThemesAsync(string userId);
    Task<StyleModel> CreateUserThemeAsync(StyleModel theme);
    Task UpdateStylesAsync(StyleModel updatedStyles, IFormFile? logoPictureFile);
    Task ActivateThemeAsync(int id);
}
