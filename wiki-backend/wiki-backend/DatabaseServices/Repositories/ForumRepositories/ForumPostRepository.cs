using Microsoft.EntityFrameworkCore;
using wiki_backend.Models.ForumModels;

namespace wiki_backend.DatabaseServices.Repositories.ForumRepositories;

public class ForumPostRepository : IForumPostRepository
{
    private readonly WikiDbContext _context;
    
    public ForumPostRepository(WikiDbContext context)
    {
        _context = context;
    }


    public async Task<IEnumerable<string>> GetAllForumPostTitlesAsync()
    {
        return await _context.ForumPosts
            .Select(post => post.PostTitle)
            .ToListAsync();
    }

    public async Task<ForumPost> GetForumPostByIdAsync(Guid id)
    {
        return await _context.ForumPosts.FindAsync(id);
    }

    public async Task AddForumPostAsync(ForumPost post)
    {
        await _context.ForumPosts.AddAsync(post);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateForumPostAsync(ForumPost post)
    {
        _context.ForumPosts.Update(post);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteForumPostAsync(Guid id)
    {
        var post = await _context.ForumPosts.FindAsync(id);
        if (post != null)
        {
            _context.ForumPosts.Remove(post);
            await _context.SaveChangesAsync();
        }
    }
}