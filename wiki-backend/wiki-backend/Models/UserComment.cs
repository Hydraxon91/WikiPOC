using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace wiki_backend.Models;

public class UserComment
{
    public Guid Id { get; set; }
    public string? Content { get; set; }
    [ForeignKey(nameof(UserProfileId))]
    // [JsonIgnore]
    public UserProfile? UserProfile { get; set; }
    public Guid UserProfileId { get; set; }
    [ForeignKey(nameof(WikiPageId))]
    [JsonIgnore]
    public WikiPage? WikiPage { get; set; }
    public Guid WikiPageId { get; set; }
    public DateTime PostDate { get; set; }
    public bool IsReply { get; set; }
    [ForeignKey(nameof(ReplayToCommentId))]
    public UserComment? ReplyToComment { get; set; }
    public int? ReplayToCommentId { get; set; }
    public bool IsEdited { get; set; } = false;
}