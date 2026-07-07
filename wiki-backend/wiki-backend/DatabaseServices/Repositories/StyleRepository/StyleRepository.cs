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

    public async Task<StyleModel> GetActiveStylesAsync()
    {
        return await _dbContext.Styles
            .SingleOrDefaultAsync(s => s.IsActive)
            ?? throw new InvalidOperationException("No active theme configured.");
    }

    public async Task<List<StyleModel>> GetSystemPresetsAsync()
    {
        return await _dbContext.Styles
            .Where(s => s.IsSystemPreset)
            .ToListAsync();
    }

    public async Task<List<StyleModel>> GetUserThemesAsync(string userId)
    {
        return await _dbContext.Styles
            .Where(s => s.UserId == userId)
            .ToListAsync();
    }

    public async Task<StyleModel> CreateUserThemeAsync(StyleModel theme)
    {
        theme.IsSystemPreset = false;
        theme.IsActive = false;
        _dbContext.Styles.Add(theme);
        await _dbContext.SaveChangesAsync();
        return theme;
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
            existingStyles.InterfaceEra = updatedStyles.InterfaceEra;
            existingStyles.ThemeName = updatedStyles.ThemeName;
            existingStyles.GlassBgOpacity = updatedStyles.GlassBgOpacity;
            existingStyles.GlassBlurRadius = updatedStyles.GlassBlurRadius;
            existingStyles.GlassBorderReflection = updatedStyles.GlassBorderReflection;
            existingStyles.BgMeshGradient = updatedStyles.BgMeshGradient;
            existingStyles.BorderRadius = updatedStyles.BorderRadius;
            existingStyles.BorderStyle = updatedStyles.BorderStyle;
        }
        else
        {
            _dbContext.Styles.Add(updatedStyles);
        }
        await _dbContext.SaveChangesAsync();
    }

    public async Task ActivateThemeAsync(int id)
    {
        if (_dbContext.Database.IsRelational())
        {
            var strategy = _dbContext.Database.CreateExecutionStrategy();
            await strategy.ExecuteAsync(async () =>
            {
                await using var transaction = await _dbContext.Database.BeginTransactionAsync();
                try
                {
                    await _dbContext.Styles
                        .ExecuteUpdateAsync(s => s.SetProperty(p => p.IsActive, false));

                    await _dbContext.Styles
                        .Where(s => s.Id == id)
                        .ExecuteUpdateAsync(s => s.SetProperty(p => p.IsActive, true));

                    await transaction.CommitAsync();
                }
                catch
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            });
        }
        else
        {
            var allStyles = await _dbContext.Styles.ToListAsync();
            foreach (var style in allStyles)
                style.IsActive = false;
            var target = allStyles.FirstOrDefault(s => s.Id == id);
            if (target != null)
                target.IsActive = true;
            await _dbContext.SaveChangesAsync();
        }
    }

    public async Task DeleteUserThemeAsync(int id)
    {
        var theme = await _dbContext.Styles.FindAsync(id);
        if (theme != null)
        {
            _dbContext.Styles.Remove(theme);
            await _dbContext.SaveChangesAsync();
        }
    }
}
