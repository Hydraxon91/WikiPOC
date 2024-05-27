using wiki_backend.Models.ForumModels;

namespace wiki_backend.DatabaseServices.Repositories.ForumRepositories;

public interface IForumCommentRepository
{
    Task<ForumComment?> GetByIdAsync(Guid id);
    Task AddAsync(ForumComment comment);
    Task UpdateAsync(Guid commentId, string updatedContent);
    Task DeleteAsync(Guid id);
}