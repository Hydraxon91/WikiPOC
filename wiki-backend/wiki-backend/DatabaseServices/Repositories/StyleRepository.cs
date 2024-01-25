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

    public async Task UpdateStylesAsync(StyleModel updatedStyles)
    {
        var existingStyles = await _dbContext.Styles.SingleOrDefaultAsync();

        if (existingStyles != null)
        {
            _dbContext.Entry(existingStyles).CurrentValues.SetValues(updatedStyles);
        }
        else
        {
            _dbContext.Styles.Add(updatedStyles);
        }

        await _dbContext.SaveChangesAsync();
    }
}