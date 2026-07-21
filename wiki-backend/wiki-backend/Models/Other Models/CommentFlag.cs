using System.ComponentModel.DataAnnotations.Schema;

namespace wiki_backend.Models;

public class CommentFlag
{
    public Guid Id { get; set; }
    public Guid CommentId { get; set; }
    public string CommentType { get; set; } = string.Empty;

    [ForeignKey(nameof(FlaggedByUserProfileId))]
    public UserProfile? FlaggedByUserProfile { get; set; }
    public Guid FlaggedByUserProfileId { get; set; }

    public string Reason { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public bool IsResolved { get; set; }

    [ForeignKey(nameof(ResolvedByUserProfileId))]
    public UserProfile? ResolvedByUserProfile { get; set; }
    public Guid? ResolvedByUserProfileId { get; set; }
    public DateTime? ResolvedAt { get; set; }
}
