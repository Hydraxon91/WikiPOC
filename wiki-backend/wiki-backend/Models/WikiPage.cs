using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace wiki_backend.Models;

public class WikiPage
{
    public Guid Id { get; set; }
    public string? Title { get; set; }
    public string? SiteSub { get; set; }
    public string? RoleNote { get; set; }
    public string? Content { get; set; }
    // public string? Category { get; set; }
    public Guid? CategoryId { get; set; }
    [ForeignKey(nameof(CategoryId))]
    [JsonIgnore]
    public Category? Category { get; set; }

    public DateTime? PostDate { get; set; }
    public DateTime? LastUpdateDate { get; set; }
    public bool LegacyWikiPage { get; set; } = false;
    public ICollection<Paragraph> Paragraphs { get; set; } = new List<Paragraph>();
    public ICollection<UserComment> Comments { get; set; } = new List<UserComment>();
    
    public override string ToString()
    {
        return $"Id: {Id} Title: {Title}, SiteSub: {SiteSub}, RoleNote: {RoleNote}, Content: {Content}, Category: {Category}, PostDate: {PostDate}, LastUpdateDate: {LastUpdateDate}, LegacyWikiPage: {LegacyWikiPage},  ";
    }
}