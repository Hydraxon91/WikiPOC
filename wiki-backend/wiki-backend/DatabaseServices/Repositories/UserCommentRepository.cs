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
    
    public async Task<UserComment?> GetByIdAsync(int id)
    {
        return await _context.UserComments
            .Include(uc => uc.UserProfile)
            .SingleOrDefaultAsync(uc => uc.Id == id);
    }

    public async Task AddAsync(UserComment comment)
    {
        _context.UserComments.Add(comment);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(int commentId, string updatedContent)
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

    public async Task DeleteAsync(int id)
    {
        var existingComment = await _context.UserComments.SingleOrDefaultAsync(uc => uc.Id == id);
        if (existingComment != null)
        {
            _context.UserComments.Remove(existingComment);
            await _context.SaveChangesAsync();
        }
    }
}