using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace wiki_backend.Models.ForumModels
{
    public class ForumPost
    {
        public Guid Id { get; set; }

        [Required]
        public string PostTitle { get; set; } = null!;

        [Required]
        public string Content { get; set; } = null!;

        public ICollection<ForumComment> Comments { get; set; } = new List<ForumComment>();

        public DateTime? PostDate { get; set; }

        public bool IsActive { get; set; } = true;

        // Reference to the topic/category
        [JsonIgnore]
        public ForumTopic ForumTopic { get; set; } = null!;
        public Guid ForumTopicId { get; set; }

        // Reference to user who posted it
        public UserProfile User { get; set; } = null!;
        public Guid UserId { get; set; }
        public string UserName { get; set; } = null!;

        [Required]
        public string Slug { get; set; } = null!;
    }
}