using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using wiki_backend.Models;
using wiki_backend.Services.Settings;
using wiki_backend.Services.Storage;

namespace wiki_backend.DatabaseServices.Repositories;

public class StyleRepository : IStyleRepository
{
    private readonly WikiDbContext _dbContext;
    private readonly string _picturesPath;

    public StyleRepository(WikiDbContext dbContext, IOptions<StorageSettings> storageSettings) 
    {
        _dbContext = dbContext;
        _picturesPath = storageSettings.Value.PicturesPath;
    }

    public async Task<StyleModel> GetStylesAsync()
    {
        return (await _dbContext.Styles.SingleOrDefaultAsync())!;
    }

    public async Task UpdateStylesAsync(StyleModel updatedStyles, IFormFile? logoPictureFile)
    {
        var existingStyles = await _dbContext.Styles.SingleOrDefaultAsync();
        if (logoPictureFile != null)
        {
            if (!ImageStorageService.IsValidFileType(logoPictureFile.FileName))
                throw new InvalidOperationException("Invalid logo file type. Allowed: png, jpg, jpeg, gif, webp.");

            var fileName = $"logo/logo{Path.GetExtension(logoPictureFile.FileName)}";
            var filePath = Path.Combine(_picturesPath, fileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await logoPictureFile.CopyToAsync(fileStream);
            }
            updatedStyles.Logo = fileName;
        }
        
        if (existingStyles != null)
        {
            existingStyles.ArticleColor = updatedStyles.ArticleColor;
            existingStyles.BodyColor = updatedStyles.BodyColor;
            existingStyles.ArticleRightColor = updatedStyles.ArticleRightColor;
            existingStyles.ArticleRightInnerColor = updatedStyles.ArticleRightInnerColor;
            existingStyles.WikiName = updatedStyles.WikiName;
            existingStyles.FooterListLinkTextColor = updatedStyles.FooterListLinkTextColor;
            existingStyles.FooterListTextColor = updatedStyles.FooterListTextColor;
            existingStyles.FontFamily = updatedStyles.FontFamily;
            existingStyles.Logo = updatedStyles.Logo ?? existingStyles.Logo;
        }
        else
        {
            _dbContext.Styles.Add(updatedStyles);
        }
        await _dbContext.SaveChangesAsync();
    }
}