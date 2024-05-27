namespace wiki_backend.Models;

public class ImageFormModel
{
    public string FileName { get; set; }
    public string DataURL { get; set; }
    
    public override string ToString()
    {
        var truncatedDataURL = DataURL.Length > 20 ? DataURL[..20] : DataURL;
        return $"Filename: {FileName} DataURL: {truncatedDataURL}";
    }
}