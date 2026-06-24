using Microsoft.Extensions.Options;
using wiki_backend.Models;
using wiki_backend.Services.Settings;
using wiki_backend.Services.Storage;

namespace UnitTests.ServicesTests;

[TestFixture]
public class ImageStorageServiceTests
{
    private string _tempDir;
    private ImageStorageService _service;

    [SetUp]
    public void Setup()
    {
        _tempDir = Path.Combine(Path.GetTempPath(), $"ImgStorageTest_{Guid.NewGuid()}");
        Directory.CreateDirectory(_tempDir);
        var settings = Options.Create(new StorageSettings { PicturesPath = _tempDir });
        _service = new ImageStorageService(settings);
    }

    [TearDown]
    public void TearDown()
    {
        if (Directory.Exists(_tempDir))
            Directory.Delete(_tempDir, true);
    }

    [Test]
    public void ReadImages_ShouldReturnEmptyList_WhenNoDirectory()
    {
        var result = _service.ReadImages(Guid.NewGuid());
        Assert.That(result, Is.Empty);
    }

    [Test]
    public void ReadImages_ShouldReturnImages_WhenFilesExist()
    {
        var wikiPageId = Guid.NewGuid();
        var articleDir = Path.Combine(_tempDir, "articles", wikiPageId.ToString());
        Directory.CreateDirectory(articleDir);

        var testBytes = new byte[] { 0x89, 0x50, 0x4E, 0x47 };
        File.WriteAllBytes(Path.Combine(articleDir, "test.png"), testBytes);

        var result = _service.ReadImages(wikiPageId);

        Assert.That(result, Has.Count.EqualTo(1));
        Assert.That(result[0].FileName, Is.EqualTo("test.png"));
        Assert.That(result[0].DataURL, Does.StartWith("data:image/png;base64,"));
    }

    [Test]
    public async Task SaveImagesAsync_ShouldCreateFiles()
    {
        var wikiPageId = Guid.NewGuid();
        var testBytes = new byte[] { 0x89, 0x50, 0x4E, 0x47 };
        var base64 = Convert.ToBase64String(testBytes);

        var images = new List<ImageFormModel>
        {
            new() { FileName = "test.png", DataURL = $"data:image/png;base64,{base64}" }
        };

        await _service.SaveImagesAsync(wikiPageId, images);

        var filePath = Path.Combine(_tempDir, "articles", wikiPageId.ToString(), "test.png");
        Assert.That(File.Exists(filePath), Is.True);
    }

    [Test]
    public void DeleteImageDirectory_ShouldRemoveDirectory()
    {
        var wikiPageId = Guid.NewGuid();
        var articleDir = Path.Combine(_tempDir, "articles", wikiPageId.ToString());
        Directory.CreateDirectory(articleDir);
        File.WriteAllText(Path.Combine(articleDir, "test.png"), "test");

        _service.DeleteImageDirectory(wikiPageId);

        Assert.That(Directory.Exists(articleDir), Is.False);
    }

    [Test]
    public void MoveImageDirectory_ShouldRenameDirectory()
    {
        var oldId = Guid.NewGuid();
        var newId = Guid.NewGuid();
        var oldDir = Path.Combine(_tempDir, "articles", oldId.ToString());
        Directory.CreateDirectory(oldDir);
        File.WriteAllText(Path.Combine(oldDir, "test.png"), "test");

        _service.MoveImageDirectory(oldId, newId);

        Assert.That(Directory.Exists(oldDir), Is.False);
        Assert.That(Directory.Exists(Path.Combine(_tempDir, "articles", newId.ToString())), Is.True);
    }

    [Test]
    public void IsValidFileType_ShouldReturnTrue_ForAllowedExtensions()
    {
        Assert.That(ImageStorageService.IsValidFileType("image.png"), Is.True);
        Assert.That(ImageStorageService.IsValidFileType("photo.jpg"), Is.True);
        Assert.That(ImageStorageService.IsValidFileType("photo.jpeg"), Is.True);
        Assert.That(ImageStorageService.IsValidFileType("animation.gif"), Is.True);
        Assert.That(ImageStorageService.IsValidFileType("icon.webp"), Is.True);
    }

    [Test]
    public void IsValidFileType_ShouldReturnFalse_ForDisallowedExtensions()
    {
        Assert.That(ImageStorageService.IsValidFileType("file.exe"), Is.False);
        Assert.That(ImageStorageService.IsValidFileType("script.html"), Is.False);
        Assert.That(ImageStorageService.IsValidFileType("doc.pdf"), Is.False);
    }
}
