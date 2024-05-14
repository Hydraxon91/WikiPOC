using System.Text.RegularExpressions;
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
    
    public async Task<ForumPost> GetForumPostBySlugAsync(string slug)
    {
        return await _context.ForumPosts
            .Include(post => post.Comments)
            .FirstOrDefaultAsync(post => post.Slug == slug);
    }

    public async Task AddForumPostAsync(ForumPost post)
    {
        post.Slug = await GenerateUniqueSlugAsync(post.PostTitle);
        await _context.ForumPosts.AddAsync(post);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateForumPostAsync(ForumPost post)
    {
        post.Slug = await GenerateUniqueSlugAsync(post.PostTitle);
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
    
    private async Task<string> GenerateUniqueSlugAsync(string title)
    {
        var slug = GenerateSlug(title);
        var originalSlug = slug;
        var counter = 1;

        while (await _context.ForumPosts.AnyAsync(p => p.Slug == slug))
        {
            slug = $"{originalSlug}-{counter}";
            counter++;
        }

        return slug;
    }

    private string GenerateSlug(string title)
    {
        var slug = Regex.Replace(title.ToLower(), @"[^a-z0-9\s-]", "").Replace(" ", "-");
        slug = Regex.Replace(slug, @"-+", "-");
        return slug;
    }
}