using Microsoft.Extensions.Options;
using wiki_backend.Models;
using wiki_backend.Services.Settings;

namespace wiki_backend.Services.Storage;

public class ImageStorageService : IImageStorageService
{
    private readonly string _picturesPath;

    public ImageStorageService(IOptions<StorageSettings> storageSettings)
    {
        _picturesPath = storageSettings.Value.PicturesPath;
    }

    public List<ImageFormModel> ReadImages(Guid wikiPageId)
    {
        var directoryPath = Path.Combine(_picturesPath, "articles", wikiPageId.ToString());
        if (!Directory.Exists(directoryPath))
            return new List<ImageFormModel>();

        return Directory.GetFiles(directoryPath).Select(file =>
        {
            var fileName = Path.GetFileName(file);
            var imageData = File.ReadAllBytes(file);
            var dataURL = $"data:image/{Path.GetExtension(fileName).TrimStart('.')};base64,{Convert.ToBase64String(imageData)}";
            return new ImageFormModel
            {
                FileName = fileName,
                DataURL = dataURL
            };
        }).ToList();
    }

    public async Task SaveImagesAsync(Guid wikiPageId, ICollection<ImageFormModel> images)
    {
        if (images.Count == 0) return;

        var directoryPath = Path.Combine(_picturesPath, "articles", wikiPageId.ToString());
        Directory.CreateDirectory(directoryPath);

        foreach (var image in images)
        {
            var filePath = Path.Combine(directoryPath, image.FileName);
            var imageData = Convert.FromBase64String(image.DataURL.Split(',')[1]);
            await using var fileStream = new FileStream(filePath, FileMode.Create);
            await fileStream.WriteAsync(imageData);
        }
    }

    public void DeleteImageDirectory(Guid wikiPageId)
    {
        var directoryPath = Path.Combine(_picturesPath, "articles", wikiPageId.ToString());
        if (Directory.Exists(directoryPath))
            Directory.Delete(directoryPath, true);
    }

    public void MoveImageDirectory(Guid oldId, Guid newId)
    {
        var oldDirectoryPath = Path.Combine(_picturesPath, "articles", oldId.ToString());
        if (!Directory.Exists(oldDirectoryPath)) return;

        var newDirectoryPath = Path.Combine(_picturesPath, "articles", newId.ToString());
        Directory.Move(oldDirectoryPath, newDirectoryPath);
    }
}
