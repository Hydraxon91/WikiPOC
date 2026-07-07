using Microsoft.EntityFrameworkCore;
using wiki_backend.Models;
using wiki_backend.Models.ForumModels;
using wiki_backend.Services;

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
        var topics = await _context.ForumTopics
            .Include(topic => topic.ForumPosts)
                .ThenInclude(fp => fp.Comments)
                    .ThenInclude(comment => comment.UserProfile)
            .Include(topic => topic.ForumPosts)
                .ThenInclude(fp => fp.User)
            .OrderBy(ft => ft.Order)
            .ToListAsync();

        var profileIds = topics
            .SelectMany(t => t.ForumPosts ?? Enumerable.Empty<ForumPost>())
            .SelectMany(p => (p.Comments ?? Enumerable.Empty<ForumComment>())
                .Where(c => c.UserProfile != null)
                .Select(c => c.UserProfile!.Id)
                .Concat(p.User != null ? new[] { p.User.Id } : Enumerable.Empty<Guid>()))
            .Distinct()
            .ToList();

        await ForumStatsHelper.SetPostCountsAsync(_context, profileIds);

        return topics;
    }
    
    public async Task<ForumTopic?> GetForumTopicBySlugAsync(string slug)
    {
        var topic = await _context.ForumTopics
            .Include(topic => topic.ForumPosts)
                .ThenInclude(fp => fp.Comments)
                    .ThenInclude(comment => comment.UserProfile)
            .Include(topic => topic.ForumPosts)
                .ThenInclude(fp => fp.User)
            .FirstOrDefaultAsync(topic => topic.Slug == slug);

        if (topic != null)
        {
            var profileIds = topic.ForumPosts
                .SelectMany(p => (p.Comments ?? Enumerable.Empty<ForumComment>())
                    .Where(c => c.UserProfile != null)
                    .Select(c => c.UserProfile!.Id)
                    .Concat(p.User != null ? new[] { p.User.Id } : Enumerable.Empty<Guid>()))
                .Distinct()
                .ToList();

            await ForumStatsHelper.SetPostCountsAsync(_context, profileIds);
        }

        return topic;
    }

    public async Task AddForumTopicAsync(ForumTopic topic)
    {
        if (string.IsNullOrWhiteSpace(topic.Title))
        {
            throw new ArgumentException("Title cannot be null or empty", nameof(topic.Title));
        }

        if (string.IsNullOrWhiteSpace(topic.Description))
        {
            throw new ArgumentException("Description cannot be null or empty", nameof(topic.Description));
        }
        
        int maxOrder = await _context.ForumTopics.MaxAsync(ft => (int?)ft.Order) ?? 0;
        topic.Order = maxOrder + 1;
        topic.Slug = SlugHelper.GenerateUniqueSlug(topic.Title, slug =>
            _context.ForumTopics.Any(t => t.Slug == slug));
        await _context.ForumTopics.AddAsync(topic);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateForumTopicAsync(ForumTopic topic)
    {
        topic.Slug = SlugHelper.GenerateUniqueSlug(topic.Title, slug =>
            _context.ForumTopics.Any(t => t.Slug == slug));
        _context.ForumTopics.Update(topic);
        await _context.SaveChangesAsync();
    }

    public async Task<List<ForumTopic>> SearchAsync(string query)
    {
        return await _context.ForumTopics
            .Where(ft => ft.Title.Contains(query) || ft.Description.Contains(query))
            .ToListAsync();
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