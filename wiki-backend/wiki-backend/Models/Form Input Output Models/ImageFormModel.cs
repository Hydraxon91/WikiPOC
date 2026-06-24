namespace wiki_backend.Models;

public class ImageFormModel
{
    public string FileName { get; set; } = null!;
    public string DataURL { get; set; } = null!;
    
    public override string ToString()
    {
        var truncatedDataURL = DataURL.Length > 20 ? DataURL[..20] : DataURL;
        return $"Filename: {FileName} DataURL: {truncatedDataURL}";
    }
}