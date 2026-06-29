namespace wiki_backend.Models.ForumModels;

public class ForumPostForm
{
    public string PostTitle { get; set; } = null!;
    public string Content { get; set; } = null!;
    public DateTime? PostDate { get; set; } = DateTime.UtcNow;
    public string ForumTopicId { get; set; } = null!;
    public string UserId { get; set; } = null!;
    public string UserName { get; set; } = null!;
}