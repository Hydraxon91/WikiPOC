using System.ComponentModel.DataAnnotations.Schema;

namespace wiki_backend.Models;

public class WikiPage
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string SiteSub { get; set; }
    public string RoleNote { get; set; }
    // public string IntroductionParagraph { get; set; }
    public ICollection<Paragraph> Paragraphs { get; set; } = new List<Paragraph>();
}