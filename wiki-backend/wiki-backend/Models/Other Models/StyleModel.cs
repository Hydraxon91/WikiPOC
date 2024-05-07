namespace wiki_backend.Models;

public class StyleModel
{
    public int Id { get; set; }
    public string? Logo { get; set; }
    public string? WikiName { get; set; }
    public string? BodyColor { get; set; }
    public string? ArticleRightColor { get; set; }
    public string? ArticleRightInnerColor { get; set; }
    public string? ArticleColor { get; set; }
    public string? FooterListLinkTextColor { get; set; }
    public string? FooterListTextColor { get; set; }
    public string? FontFamily { get; set; }
    
    public override string ToString()
    {
        return $"Id: {Id}, Logo: {Logo}, WikiName: {WikiName}, BodyColor: {BodyColor}, ArticleRightColor: {ArticleRightColor}, " +
               $"ArticleRightInnerColor: {ArticleRightInnerColor}, ArticleColor: {ArticleColor}, FooterListLinkTextColor: {FooterListLinkTextColor}, " +
               $"FooterListTextColor: {FooterListTextColor}, FontFamily: {FontFamily}";
    }
    
}