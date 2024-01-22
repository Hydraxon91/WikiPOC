using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using wiki_backend.Models;

namespace wiki_backend.Models;

public class Paragraph
{
    public int Id { get; set; }
    public int WikiPageId { get; set; }
    [ForeignKey(nameof(WikiPageId))]
    public string Title { get; set; }
    public string Content { get; set; }
    public string ParagraphImage { get; set; }
    public string ParagraphImageText { get; set; }
}