using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using wiki_backend.Services.Settings;

namespace wiki_backend.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/[controller]")]
public class ImageController : ControllerBase
{
    private readonly string _picturesPath;

    public ImageController(IOptions<StorageSettings> storageSettings)
    {
        _picturesPath = storageSettings.Value.PicturesPath;
    }

    [HttpGet("profile/{imageName}")]
    public IActionResult GetImage(string imageName)
    {
        var safeName = Path.GetFileName(imageName);
        var imagePath = Path.Combine(_picturesPath, "profile_pictures/", safeName);
        var fullPath = Path.GetFullPath(imagePath);
        var baseDir = Path.GetFullPath(Path.Combine(_picturesPath, "profile_pictures/"));
        if (!fullPath.StartsWith(baseDir, StringComparison.Ordinal))
        {
            return BadRequest("Invalid image path.");
        }

        if (!System.IO.File.Exists(fullPath))
        {
            return NotFound("Image not found.");
        }

        var imageBytes = System.IO.File.ReadAllBytes(fullPath);
        return File(imageBytes, "image/png");
    }

    [HttpGet("logo/{imageName}")]
    public IActionResult GetLogo(string imageName)
    {
        var safeName = Path.GetFileName(imageName);
        var imagePath = Path.Combine(_picturesPath, "logo/", safeName);
        var fullPath = Path.GetFullPath(imagePath);
        var baseDir = Path.GetFullPath(Path.Combine(_picturesPath, "logo/"));
        if (!fullPath.StartsWith(baseDir, StringComparison.Ordinal))
        {
            return BadRequest("Invalid image path.");
        }

        if (!System.IO.File.Exists(fullPath))
        {
            return NotFound("Image not found.");
        }

        var imageBytes = System.IO.File.ReadAllBytes(fullPath);
        return File(imageBytes, "image/png");
    }
}