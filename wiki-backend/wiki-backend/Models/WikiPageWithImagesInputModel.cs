using System.Text.Json.Serialization;
using Bogus.DataSets;

namespace wiki_backend.Models;

public class WikiPageWithImagesInputModel
{

    //Normal wikipage
    public string? Title { get; set; }
    public string? SiteSub { get; set; }
    public string? RoleNote { get; set; }
    public string? Content { get; set; }
    public string? Category { get; set; }
    public DateTime? PostDate { get; set; }
    public DateTime? LastUpdateDate { get; set; }
    public ICollection<Paragraph> Paragraphs { get; set; } = new List<Paragraph>();
    public bool LegacyWikiPage { get; set; } = false;
    //if usersubbmittedwikipage
    public Guid? WikiPageId { get; set; }
    [JsonIgnore]
    public WikiPage? WikiPage { get; set; }
    public string? SubmittedBy { get; set; }
    public bool? Approved { get; set; }
    public bool? IsNewPage { get; set; }
    
    
    //Image data
    public ICollection<ImageFormModel>? Images { get; set; }
    
    public override string ToString()
    {
        return $"Title: {Title}, SiteSub: {SiteSub}, RoleNote: {RoleNote}, Content: {Content}, Category: {Category}, PostDate: {PostDate}, LastUpdateDate: {LastUpdateDate}, LegacyWikiPage: {LegacyWikiPage}, WikiPageId: {WikiPageId}, SubmittedBy: {SubmittedBy}, Approved: {Approved}, IsNewPage: {IsNewPage}, Images: {Images?.Count ?? 0} Images Type: {typeof(Images)}";
    }
}