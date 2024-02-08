using System.ComponentModel.DataAnnotations.Schema;

namespace wiki_backend.Models;

public class UserSubmittedWikiPage : WikiPage
{
    [ForeignKey("WikiPage")]
    public int? WikiPageId { get; set; }
    
    public WikiPage? WikiPage { get; set; }
    
    [Column(TypeName = "nvarchar(100)")]
    public string SubmittedBy { get; set; }

    public bool Approved { get; set; } = false;
    
    // public UserSubmittedWikiPage()
    // {
    //     WikiPage ??= new WikiPage();
    // }
}