using Microsoft.EntityFrameworkCore;
using wiki_backend.Models;

namespace wiki_backend.DatabaseServices.Repositories;

public class UserCommentRepository : IUserCommentRepository
{
    private readonly WikiDbContext _context;

    public UserCommentRepository(WikiDbContext context)
    {
        _context = context;
    }
    
    public async Task<UserComment?> GetByIdAsync(Guid id)
    {
        return await _context.UserComments
            .Include(uc => uc.UserProfile)
            .SingleOrDefaultAsync(uc => uc.Id == id);
    }

    public async Task AddAsync(UserComment comment)
    {
        if (comment.ReplyToCommentId.HasValue)
        {
            var parentComment = await _context.UserComments
                .Include(c => c.Replies) // Ensure replies collection is included
                .FirstOrDefaultAsync(c => c.Id == comment.ReplyToCommentId);

            if (parentComment != null)
            {
                parentComment.Replies ??= new List<UserComment>();
                parentComment.Replies.Add(comment);
            }
        }
        else
        {
            _context.UserComments.Add(comment);
        }
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Guid commentId, string updatedContent)
    {
        var existingComment = await _context.UserComments.SingleOrDefaultAsync(uc => uc.Id == commentId);
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
        var existingComment = await _context.UserComments.SingleOrDefaultAsync(uc => uc.Id == id);
        if (existingComment != null)
        {
            _context.UserComments.Remove(existingComment);
            await _context.SaveChangesAsync();
        }
    }
}