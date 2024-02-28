using wiki_backend.Models;

namespace wiki_backend.DatabaseServices.Repositories;

public interface IUserCommentRepository
{
    Task<UserComment?> GetByIdAsync(int id);
    Task AddAsync(UserComment comment);
    Task UpdateAsync(int commentId, string updatedContent);
    Task DeleteAsync(int id);
}