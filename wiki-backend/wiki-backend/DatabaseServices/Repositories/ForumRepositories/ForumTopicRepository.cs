using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using wiki_backend.Models;
using wiki_backend.Models.ForumModels;

namespace wiki_backend.DatabaseServices.Repositories.ForumRepositories;

public class ForumTopicRepository : IForumTopicRepository
{
    private readonly WikiDbContext _context;
    
    public ForumTopicRepository(WikiDbContext context)
    {
        _context = context;
    }


    private async Task SetPostCountOnProfile(UserProfile profile)
    {
        if (profile == null) return;
        var forumPostCount = await _context.ForumPosts.CountAsync(fp => fp.UserId == profile.Id);
        var forumCommentCount = await _context.ForumComments.CountAsync(fc => fc.UserProfileId == profile.Id);
        profile.PostCount = forumPostCount + forumCommentCount;
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

        foreach (var topic in topics)
        {
            foreach (var post in topic.ForumPosts ?? new List<ForumPost>())
            {
                foreach (var comment in post.Comments ?? new List<ForumComment>())
                {
                    if (comment.UserProfile != null) await SetPostCountOnProfile(comment.UserProfile);
                }
                if (post.User != null) await SetPostCountOnProfile(post.User);
            }
        }

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
            foreach (var post in topic.ForumPosts ?? new List<ForumPost>())
            {
                foreach (var comment in post.Comments ?? new List<ForumComment>())
                {
                    if (comment.UserProfile != null) await SetPostCountOnProfile(comment.UserProfile);
                }
                if (post.User != null) await SetPostCountOnProfile(post.User);
            }
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
            // Update originalSlug for the next iteration
            originalSlug = slug;
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