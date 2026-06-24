using wiki_backend.Models;

namespace wiki_backend.Services.Storage;

public interface IImageStorageService
{
    List<ImageFormModel> ReadImages(Guid wikiPageId);
    Task SaveImagesAsync(Guid wikiPageId, ICollection<ImageFormModel> images);
    void DeleteImageDirectory(Guid wikiPageId);
    void MoveImageDirectory(Guid oldId, Guid newId);
}
