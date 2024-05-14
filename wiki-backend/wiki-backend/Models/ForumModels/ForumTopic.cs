using System.ComponentModel.DataAnnotations;

namespace wiki_backend.Models.ForumModels;

public class ForumTopic
{
    public Guid Id { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public string Slug { get; set; }
    
    public ICollection<ForumPost> ForumPosts { get; set; } = new List<ForumPost>();
}