using wiki_backend.Models.ForumModels;

namespace wiki_backend.DatabaseServices.Repositories.ForumRepositories;

public interface IForumRepository
{
    Task<ForumPost> GetForumPostByIdAsync(Guid id);
    Task<IEnumerable<ForumPost>> GetAllForumPostsAsync();
    Task AddForumPostAsync(ForumPost post);
    Task UpdateForumPostAsync(ForumPost post);
    Task DeleteForumPostAsync(Guid id);
}