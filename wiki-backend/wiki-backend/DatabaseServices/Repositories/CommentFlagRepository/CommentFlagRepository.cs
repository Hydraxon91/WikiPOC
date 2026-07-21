using Microsoft.EntityFrameworkCore;
using wiki_backend.Models;

namespace wiki_backend.DatabaseServices.Repositories;

public class CommentFlagRepository : ICommentFlagRepository
{
    private readonly WikiDbContext _context;

    public CommentFlagRepository(WikiDbContext context)
    {
        _context = context;
    }

    public async Task AddFlagAsync(CommentFlag flag)
    {
        if (flag.CreatedAt.Kind != DateTimeKind.Utc)
        {
            flag.CreatedAt = flag.CreatedAt.ToUniversalTime();
        }
        _context.CommentFlags.Add(flag);
        await _context.SaveChangesAsync();
    }

    public async Task<List<FlaggedCommentItem>> GetUnresolvedFlagsAsync()
    {
        var flags = await _context.CommentFlags
            .Where(f => !f.IsResolved)
            .Include(f => f.FlaggedByUserProfile)
            .OrderByDescending(f => f.CreatedAt)
            .ToListAsync();

        var items = new List<FlaggedCommentItem>();
        foreach (var flag in flags)
        {
            string? content = null;
            string? authorName = null;
            Guid? authorProfileId = null;

            if (flag.CommentType == "Forum")
            {
                var comment = await _context.ForumComments
                    .Include(c => c.UserProfile)
                    .FirstOrDefaultAsync(c => c.Id == flag.CommentId);
                if (comment != null)
                {
                    content = comment.Content;
                    authorName = comment.UserProfile?.UserName;
                    authorProfileId = comment.UserProfile?.Id;
                }
            }
            else if (flag.CommentType == "Wiki")
            {
                var comment = await _context.UserComments
                    .Include(c => c.UserProfile)
                    .FirstOrDefaultAsync(c => c.Id == flag.CommentId);
                if (comment != null)
                {
                    content = comment.Content;
                    authorName = comment.UserProfile?.UserName;
                    authorProfileId = comment.UserProfile?.Id;
                }
            }

            items.Add(new FlaggedCommentItem
            {
                Flag = flag,
                CommentContent = content,
                CommentAuthorName = authorName,
                CommentAuthorProfileId = authorProfileId
            });
        }

        return items;
    }

    public async Task<int> GetUnresolvedCountAsync()
    {
        return await _context.CommentFlags.CountAsync(f => !f.IsResolved);
    }

    public async Task<CommentFlag?> GetFlagByIdAsync(Guid flagId)
    {
        return await _context.CommentFlags
            .Include(f => f.FlaggedByUserProfile)
            .FirstOrDefaultAsync(f => f.Id == flagId);
    }

    public async Task ResolveFlagAsync(Guid flagId, Guid resolvedByUserProfileId)
    {
        var flag = await _context.CommentFlags.FindAsync(flagId);
        if (flag != null)
        {
            flag.IsResolved = true;
            flag.ResolvedByUserProfileId = resolvedByUserProfileId;
            flag.ResolvedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
        }
    }

    public async Task ResolveAllFlagsForCommentAsync(Guid commentId)
    {
        var flags = await _context.CommentFlags
            .Where(f => f.CommentId == commentId && !f.IsResolved)
            .ToListAsync();
        foreach (var flag in flags)
        {
            flag.IsResolved = true;
            flag.ResolvedAt = DateTime.UtcNow;
        }
        await _context.SaveChangesAsync();
    }

    public async Task DeleteFlagAsync(Guid flagId)
    {
        var flag = await _context.CommentFlags.FindAsync(flagId);
        if (flag != null)
        {
            _context.CommentFlags.Remove(flag);
            await _context.SaveChangesAsync();
        }
    }

    public async Task DeleteFlagsForCommentAsync(Guid commentId)
    {
        var flags = await _context.CommentFlags
            .Where(f => f.CommentId == commentId)
            .ToListAsync();
        _context.CommentFlags.RemoveRange(flags);
        await _context.SaveChangesAsync();
    }
}
