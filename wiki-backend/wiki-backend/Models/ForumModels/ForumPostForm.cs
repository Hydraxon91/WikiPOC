namespace wiki_backend.Models.ForumModels;

public class ForumPostForm
{
    public string PostTitle { get; set; }
    public string Content { get; set; }
    public DateTime? PostDate { get; set; } = DateTime.Now;
    public string ForumTopicId { get; set; }
    public string UserId { get; set; }
    public string UserName { get; set; }
    
    public override string ToString()
    {
        return $"PostTitle: {PostTitle}, Content: {Content}, PostDate: {PostDate}, ForumTopicId: {ForumTopicId}, UserId: {UserId}, UserName: {UserName}";
    }
}