namespace wiki_backend.Models;

public class UserComment
{
    public int Id { get; set; }
    public string? Content { get; set; }
    public UserProfile? UserProfile { get; set; }
    public int UserProfileId { get; set; }
    public WikiPage? WikiPage { get; set; }
    public int WikiPageId { get; set; }
    public DateTime PostDate { get; set; }
    public bool IsReply { get; set; }
    public UserComment? ReplyToComment { get; set; }
    public bool IsEdited { get; set; } = false;
}