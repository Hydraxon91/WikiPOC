using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using wiki_backend.Models;

namespace wiki_backend.Models;

public class Paragraph
{
    public Guid Id { get; set; }
    [Required(ErrorMessage = "WikiPageId is required.")]
    public Guid WikiPageId { get; set; }
    [ForeignKey(nameof(WikiPageId))]
    [JsonIgnore]
    public WikiPage? WikiPage { get; set; }
    
    public string? Title { get; set; }
    public string? Content { get; set; }
    public string? ParagraphImage { get; set; }
    public string? ParagraphImageText { get; set; }
}