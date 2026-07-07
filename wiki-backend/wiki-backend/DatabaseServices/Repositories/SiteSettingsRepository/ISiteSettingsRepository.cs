using wiki_backend.Models;

namespace wiki_backend.DatabaseServices.Repositories;

public interface ISiteSettingsRepository
{
    Task<SiteSettings> GetAsync();
    Task UpdateAsync(string? wikiName, IFormFile? logoFile);
}
