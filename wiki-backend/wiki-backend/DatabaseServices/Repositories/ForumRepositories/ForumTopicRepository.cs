using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using wiki_backend.Models.ForumModels;

namespace wiki_backend.DatabaseServices.Repositories.ForumRepositories;

public class ForumTopicRepository : IForumTopicRepository
{
    private readonly WikiDbContext _context;
    
    public ForumTopicRepository(WikiDbContext context)
    {
        _context = context;
    }


    public async Task<IEnumerable<ForumTopic>> GetAllForumTopicsAsync()
    {
        return await _context.ForumTopics
            .Include(topic => topic.ForumPosts)
            .ToListAsync();
    }
    
    public async Task<ForumTopic> GetForumTopicBySlugAsync(string slug)
    {
        return await _context.ForumTopics
            .Include(topic => topic.ForumPosts)
            .FirstOrDefaultAsync(topic => topic.Slug == slug);
    }

    public async Task AddForumTopicAsync(ForumTopic topic)
    {
        topic.Slug = GenerateSlug(topic.Title);
        await _context.ForumTopics.AddAsync(topic);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateForumTopicAsync(ForumTopic topic)
    {
        topic.Slug = GenerateSlug(topic.Title);
        _context.ForumTopics.Update(topic);
        await _context.SaveChangesAsync();
    }

    private string GenerateSlug(string title)
    {
        // Convert to lower case, replace spaces with hyphens, and remove invalid characters
        var slug = Regex.Replace(title.ToLower(), @"[^a-z0-9\s-]", "").Replace(" ", "-");

        // Ensure only a single hyphen is present where there were spaces or invalid characters
        slug = Regex.Replace(slug, @"-+", "-");

        // Check for uniqueness
        var originalSlug = slug;
        var counter = 1;

        while (_context.ForumTopics.Any(t => t.Slug == slug))
        {
            slug = $"{originalSlug}-{counter}";
            counter++;
        }

        return slug;
    }
    
    public async Task DeleteForumTopicAsync(Guid id)
    {
        var topic = await _context.ForumTopics.FindAsync(id);
        if (topic != null)
        {
            _context.ForumTopics.Remove(topic);
            await _context.SaveChangesAsync();
        }
    }
}