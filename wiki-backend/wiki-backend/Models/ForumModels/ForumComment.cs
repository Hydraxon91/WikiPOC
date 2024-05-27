using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace wiki_backend.Models.ForumModels;

public class ForumComment
{
    public Guid Id { get; set; }
    public string? Content { get; set; }

    [ForeignKey(nameof(UserProfileId))]
    public UserProfile? UserProfile { get; set; }
    public Guid UserProfileId { get; set; }

    [ForeignKey(nameof(ForumPostId))]
    [JsonIgnore]
    public ForumPost? ForumPost { get; set; }
    public Guid ForumPostId { get; set; }

    public DateTime PostDate { get; set; }
    public bool IsReply { get; set; }

    [ForeignKey(nameof(ReplyToCommentId))]
    public ForumComment? ReplyToComment { get; set; }
    public Guid? ReplyToCommentId { get; set; }

    public bool IsEdited { get; set; } = false;
    
    public override string ToString()
    {
        return $"Id: {Id}, Content: {Content}, UserProfileId: {UserProfileId}, ForumPostId: {ForumPostId}, PostDate: {PostDate}, IsReply: {IsReply}, ReplyToCommentId: {ReplyToCommentId}, IsEdited: {IsEdited}";
    }
}