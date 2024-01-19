namespace wiki_backend.Objects;

public class Paragraph
{
    public int Id { get; set; }
    public int WikiPageId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public string? ParagraphImage { get; set; }
    public string? ParagraphImageText { get; set; }
}