namespace wiki_backend.Models;

public class StyleModel
{
    public int Id { get; set; }
    public bool IsActive { get; set; }
    public bool IsSystemPreset { get; set; }
    public string? UserId { get; set; }
    public string InterfaceEra { get; set; } = "wikipedia";
    public string? ThemeName { get; set; }
    public string? Logo { get; set; }
    public string? WikiName { get; set; }
    public string? BodyColor { get; set; }
    public string? ArticleRightColor { get; set; }
    public string? ArticleRightInnerColor { get; set; }
    public string? ArticleColor { get; set; }
    public string? FooterListLinkTextColor { get; set; }
    public string? FooterListTextColor { get; set; }
    public string? FontFamily { get; set; }
    public double? GlassBgOpacity { get; set; }
    public double? GlassBlurRadius { get; set; }
    public double? GlassBorderReflection { get; set; }
    public string? BgMeshGradient { get; set; }
    public string? BorderRadius { get; set; }
    public string? BorderStyle { get; set; }
}