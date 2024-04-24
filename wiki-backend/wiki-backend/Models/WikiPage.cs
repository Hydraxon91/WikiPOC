using System.ComponentModel.DataAnnotations.Schema;

namespace wiki_backend.Models;

public class WikiPage
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string SiteSub { get; set; }
    public string RoleNote { get; set; }
    public string? Content { get; set; }
    public DateTime? PostDate { get; set; }
    public List<DateTime> UpdateDates { get; set; } = new List<DateTime>();
    public ICollection<Paragraph> Paragraphs { get; set; } = new List<Paragraph>();
    public ICollection<UserComment> Comments { get; set; } = new List<UserComment>();
}