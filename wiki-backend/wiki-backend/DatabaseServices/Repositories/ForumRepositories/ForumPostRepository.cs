using Microsoft.EntityFrameworkCore;
using wiki_backend.Models.ForumModels;
using wiki_backend.Services;

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

    public async Task<ForumPost?> GetForumPostByIdAsync(Guid id)
    {
        return await _context.ForumPosts.FindAsync(id);
    }
    
    public async Task<ForumPost?> GetForumPostBySlugAsync(string slug)
    {
        var post = await _context.ForumPosts
            .Include(post => post.Comments.OrderBy(c => c.PostDate).ThenBy(c => c.Id))
                .ThenInclude(comment => comment.UserProfile)
            .Include(post => post.User)
            .FirstOrDefaultAsync(post => post.Slug == slug);

        if (post != null)
        {
            var profileIds = post.Comments
                .Where(c => c.UserProfile != null)
                .Select(c => c.UserProfile!.Id)
                .ToList();
            if (post.User != null) profileIds.Add(post.User.Id);
            await ForumStatsHelper.SetPostCountsAsync(_context, profileIds);
        }

        return post;
    }

    public async Task AddForumPostAsync(ForumPost post)
    {
        var firstComment = new ForumComment
        {
            Id = Guid.NewGuid(),
            Content = post.Content,
            UserProfileId = post.UserId,
            ForumPostId = post.Id,
            PostDate = DateTime.UtcNow
        };
        post.Comments = new List<ForumComment> { firstComment };
        post.Slug = await GenerateUniqueSlugAsync(post.PostTitle);
        await _context.ForumPosts.AddAsync(post);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateForumPostAsync(ForumPost post, ForumPost updatedPost)
    {
        var oldTitle = post.PostTitle;
        post.PostTitle = updatedPost.PostTitle;
        post.Content = updatedPost.Content;
        post.ForumTopicId = updatedPost.ForumTopicId;
        if (oldTitle != post.PostTitle)
        {
            post.Slug = await GenerateUniqueSlugAsync(post.PostTitle);
        }
        var firstComment = post.Comments.FirstOrDefault();
        if (firstComment != null)
        {
            firstComment.Content = updatedPost.Content;
        }
        else
        {
            var newComment = new ForumComment
            {
                Id = Guid.NewGuid(),
                Content = updatedPost.Content,
                UserProfileId = updatedPost.UserId,
                ForumPostId = post.Id
            };
            post.Comments = new List<ForumComment> { newComment };
            _context.ForumComments.Add(newComment);
        }
        await _context.SaveChangesAsync();
    }

    public async Task DeleteForumPostAsync(Guid id)
    {
        var forumPost = await _context.ForumPosts
            .Include(p => p.Comments)
            .FirstOrDefaultAsync(p => p.Id == id);
        if (forumPost != null)
        {
            _context.ForumPosts.Remove(forumPost);
            await _context.SaveChangesAsync();
        }
    }
    
    private async Task<string> GenerateUniqueSlugAsync(string title)
    {
        return await SlugHelper.GenerateUniqueSlugAsync(title, slug =>
            _context.ForumPosts.AnyAsync(p => p.Slug == slug));
    }
}