using System.ComponentModel.DataAnnotations;

namespace wiki_backend.Models.ForumModels;

public class ForumPost
{
    public Guid Id { get; set; }
    [Required]
    public string PostTitle { get; set; }
    [Required]
    public string Content { get; set; }
    public ICollection<UserComment> Comments { get; set; } = new List<UserComment>();
    public DateTime? PostDate { get; set; }

    // Reference to the topic/category
    public ForumTopic ForumTopic  { get; set; }
    public Guid ForumTopicId { get; set; }
    
    // Reference to user who posted it
    public UserProfile User { get; set; }
    public Guid UserId { get; set; }
}