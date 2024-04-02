using Microsoft.EntityFrameworkCore;
using wiki_backend.Models;

namespace wiki_backend.DatabaseServices.Repositories;

public class StyleRepository : IStyleRepository
{
    private readonly WikiDbContext _dbContext;

    public StyleRepository(WikiDbContext dbContext) 
    {
        _dbContext = dbContext;
    }

    public async Task<StyleModel> GetStylesAsync()
    {
        return await _dbContext.Styles.SingleOrDefaultAsync();
    }

    public async Task UpdateStylesAsync(StyleModel updatedStyles, IFormFile? logoPictureFile)
    {
        var existingStyles = await _dbContext.Styles.SingleOrDefaultAsync();
        if (logoPictureFile != null)
        {
            var fileName = $"logo{Path.GetExtension(logoPictureFile.FileName)}";
            var filePath = Path.Combine(Environment.GetEnvironmentVariable("PROFILE_PICTURES_PATH_CONTAINER"), fileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await logoPictureFile.CopyToAsync(fileStream);
            }
            updatedStyles.Logo = fileName;
        }
        
        if (existingStyles != null)
        {
            // _dbContext.Entry(existingStyles).CurrentValues.SetValues(updatedStyles);
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