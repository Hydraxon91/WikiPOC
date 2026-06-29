namespace wiki_backend.Models;

public class Category
{
    public Guid Id { get; set; }
    public string CategoryName { get; set; } = "";
    
    public ICollection<WikiPage> WikiPages { get; set; } = new List<WikiPage>();
}