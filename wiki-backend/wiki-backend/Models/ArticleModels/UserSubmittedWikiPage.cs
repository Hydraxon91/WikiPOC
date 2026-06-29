using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace wiki_backend.Models;

public class UserSubmittedWikiPage : WikiPage
{
    [ForeignKey("WikiPage")]
    public Guid? WikiPageId { get; set; }
    [JsonIgnore]
    public WikiPage? WikiPage { get; set; }
    
    public string SubmittedBy { get; set; } = null!;

    public bool Approved { get; set; } = false;
    
    public bool IsNewPage { get; set; }
}