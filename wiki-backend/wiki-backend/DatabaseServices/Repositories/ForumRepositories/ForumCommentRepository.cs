using Microsoft.EntityFrameworkCore;
using wiki_backend.Models.ForumModels;

namespace wiki_backend.DatabaseServices.Repositories.ForumRepositories;

public class ForumCommentRepository : IForumCommentRepository
{
    private readonly WikiDbContext _context;
    
    public ForumCommentRepository(WikiDbContext context)
    {
        _context = context;
    }
    
    public async Task<ForumComment?> GetByIdAsync(Guid id)
    {
        return await _context.ForumComments
            .Include(uc => uc.UserProfile)
            .SingleOrDefaultAsync(uc => uc.Id == id);
    }

    public async Task AddAsync(ForumComment comment)
    {
        if (comment.Content == null)
        {
            throw new ArgumentNullException(nameof(comment.Content), "Content must not be null.");
        }
        if (comment.PostDate.Kind != DateTimeKind.Utc)
        {
            comment.PostDate = comment.PostDate.ToUniversalTime();
        }
        _context.ForumComments.Add(comment);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Guid commentId, string updatedContent)
    {
        var existingComment = await _context.ForumComments.SingleOrDefaultAsync(uc => uc.Id == commentId);
        if (existingComment == null)
        {
            throw new InvalidOperationException($"Comment with ID {commentId} not found.");
        }

        existingComment.Content = updatedContent;
        existingComment.IsEdited = true;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var existingComment = await _context.ForumComments.SingleOrDefaultAsync(uc => uc.Id == id);
        if (existingComment != null)
        {
            _context.ForumComments.Remove(existingComment);
            await _context.SaveChangesAsync();
        }
    }
}