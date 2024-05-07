namespace wiki_backend.Models;

public class Category
{
    public Guid Id { get; set; }
    public string CategoryName { get; set; } = "";
    
    public ICollection<WikiPage> WikiPages { get; set; } = new List<WikiPage>();

    public override string ToString()
    {
        return $"Id: {Id}, CategoryName: {CategoryName}, Wikipages length: {WikiPages.Count}";
    }
}