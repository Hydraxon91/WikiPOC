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

    public async Task AddForumTopicAsync(ForumTopic topic)
    {
        await _context.ForumTopics.AddAsync(topic);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateForumTopicAsync(ForumTopic topic)
    {
        _context.ForumTopics.Update(topic);
        await _context.SaveChangesAsync();
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