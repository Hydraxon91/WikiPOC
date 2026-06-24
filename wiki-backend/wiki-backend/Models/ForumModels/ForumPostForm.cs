namespace wiki_backend.Models.ForumModels;

public class ForumPostForm
{
    public string PostTitle { get; set; } = null!;
    public string Content { get; set; } = null!;
    public DateTime? PostDate { get; set; } = DateTime.Now;
    public string ForumTopicId { get; set; } = null!;
    public string UserId { get; set; } = null!;
    public string UserName { get; set; } = null!;
    
    public override string ToString()
    {
        return $"PostTitle: {PostTitle}, Content: {Content}, PostDate: {PostDate}, ForumTopicId: {ForumTopicId}, UserId: {UserId}, UserName: {UserName}";
    }
}