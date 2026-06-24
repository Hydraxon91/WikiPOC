using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using wiki_backend.Controllers;
using wiki_backend.Services.Settings;

namespace UnitTests.ServicesTests;

[TestFixture]
public class ImageControllerTests
{
    private string _tempDir;
    private ImageController _controller;

    [SetUp]
    public void Setup()
    {
        _tempDir = Path.Combine(Path.GetTempPath(), $"ImgControllerTest_{Guid.NewGuid()}");

        var profilePicsDir = Path.Combine(_tempDir, "profile_pictures");
        var logoDir = Path.Combine(_tempDir, "logo");
        Directory.CreateDirectory(profilePicsDir);
        Directory.CreateDirectory(logoDir);

        var testBytes = new byte[] { 0x89, 0x50, 0x4E, 0x47 };
        File.WriteAllBytes(Path.Combine(profilePicsDir, "test.png"), testBytes);
        File.WriteAllBytes(Path.Combine(logoDir, "logo.png"), testBytes);

        var settings = Options.Create(new StorageSettings { PicturesPath = _tempDir });
        _controller = new ImageController(settings);
    }

    [TearDown]
    public void TearDown()
    {
        if (Directory.Exists(_tempDir))
            Directory.Delete(_tempDir, true);
    }

    [Test]
    public void GetImage_ShouldReturnFile_WhenImageExists()
    {
        var result = _controller.GetImage("test.png");

        Assert.That(result, Is.InstanceOf<FileContentResult>());
        var fileResult = result as FileContentResult;
        Assert.That(fileResult!.ContentType, Is.EqualTo("image/png"));
        Assert.That(fileResult.FileContents, Is.Not.Empty);
    }

    [Test]
    public void GetImage_ShouldReturnNotFound_WhenImageDoesNotExist()
    {
        var result = _controller.GetImage("nonexistent.png");

        Assert.That(result, Is.InstanceOf<NotFoundObjectResult>());
    }

    [Test]
    public void GetImage_ShouldSanitizePathTraversal()
    {
        var result = _controller.GetImage("../../etc/passwd");

        Assert.That(result, Is.InstanceOf<NotFoundObjectResult>());
    }

    [Test]
    public void GetLogo_ShouldReturnFile_WhenLogoExists()
    {
        var result = _controller.GetLogo("logo.png");

        Assert.That(result, Is.InstanceOf<FileContentResult>());
        var fileResult = result as FileContentResult;
        Assert.That(fileResult!.ContentType, Is.EqualTo("image/png"));
    }

    [Test]
    public void GetLogo_ShouldReturnNotFound_WhenLogoDoesNotExist()
    {
        var result = _controller.GetLogo("nonexistent.png");

        Assert.That(result, Is.InstanceOf<NotFoundObjectResult>());
    }

    [Test]
    public void GetLogo_ShouldSanitizePathTraversal()
    {
        var result = _controller.GetLogo("../../../etc/hosts");

        Assert.That(result, Is.InstanceOf<NotFoundObjectResult>());
    }
}
