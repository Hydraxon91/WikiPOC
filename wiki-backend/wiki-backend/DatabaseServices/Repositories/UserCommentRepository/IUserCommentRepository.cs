using wiki_backend.Models;

namespace wiki_backend.DatabaseServices.Repositories;

public interface IUserCommentRepository
{
    Task<UserComment?> GetByIdAsync(Guid id);
    Task AddAsync(UserComment comment);
    Task UpdateAsync(Guid commentId, string updatedContent);
    Task DeleteAsync(Guid id);
}