using System.ComponentModel.DataAnnotations.Schema;

namespace wiki_backend.Models;

public class WikiPage
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string SiteSub { get; set; }
    public string RoleNote { get; set; }
    public virtual List<Paragraph> Paragraphs { get; set; }
}