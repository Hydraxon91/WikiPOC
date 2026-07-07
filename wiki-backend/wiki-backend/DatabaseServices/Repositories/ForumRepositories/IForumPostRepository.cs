using wiki_backend.Models.ForumModels;

namespace wiki_backend.DatabaseServices.Repositories.ForumRepositories;

public interface IForumPostRepository
{
    Task<IEnumerable<string>> GetAllForumPostTitlesAsync();
    Task<ForumPost?> GetForumPostByIdAsync(Guid id);
    Task<ForumPost?> GetForumPostBySlugAsync(string slug);
    Task AddForumPostAsync(ForumPost post);
    Task UpdateForumPostAsync(ForumPost post, ForumPost updatedPost);
    Task<List<ForumPost>> SearchByTopicAsync(Guid topicId, string query);
    Task DeleteForumPostAsync(Guid id);
}