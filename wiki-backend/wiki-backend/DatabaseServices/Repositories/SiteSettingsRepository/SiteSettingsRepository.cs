using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using wiki_backend.Models;
using wiki_backend.Services.Settings;
using wiki_backend.Services.Storage;

namespace wiki_backend.DatabaseServices.Repositories;

public class SiteSettingsRepository : ISiteSettingsRepository
{
    private readonly WikiDbContext _dbContext;
    private readonly string _picturesPath;

    public SiteSettingsRepository(WikiDbContext dbContext, IOptions<StorageSettings> storageSettings)
    {
        _dbContext = dbContext;
        _picturesPath = storageSettings.Value.PicturesPath;
    }

    public async Task<SiteSettings> GetAsync()
    {
        return (await _dbContext.SiteSettings.FirstOrDefaultAsync())!;
    }

    public async Task UpdateAsync(string? wikiName, IFormFile? logoFile)
    {
        var settings = await _dbContext.SiteSettings.FirstOrDefaultAsync();
        if (settings == null)
        {
            settings = new SiteSettings();
            _dbContext.SiteSettings.Add(settings);
        }

        if (wikiName != null)
            settings.WikiName = wikiName;

        if (logoFile != null)
        {
            if (!ImageStorageService.IsValidFileType(logoFile.FileName))
                throw new InvalidOperationException("Invalid logo file type. Allowed: png, jpg, jpeg, gif, webp.");

            var fileName = $"logo/logo{Path.GetExtension(logoFile.FileName)}";
            var filePath = Path.Combine(_picturesPath, fileName);
            var dir = Path.GetDirectoryName(filePath);
            if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
                Directory.CreateDirectory(dir);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await logoFile.CopyToAsync(fileStream);
            }
            settings.Logo = fileName;
        }

        await _dbContext.SaveChangesAsync();
    }
}
