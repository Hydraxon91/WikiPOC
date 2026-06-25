using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace wiki_backend.Models;

public class UserProfile
{
    public Guid Id { get; set; }
    [JsonIgnore]
    public string? UserId { get; set; } 
    public string? UserName { get; set; }
    public string? ProfilePicture { get; set; }
    public string? DisplayName { get; set; }
    public DateTime JoinDate { get; set; }
    [NotMapped]
    public int PostCount { get; set; }
    [JsonIgnore]
    public ApplicationUser? User { get; set; }
}