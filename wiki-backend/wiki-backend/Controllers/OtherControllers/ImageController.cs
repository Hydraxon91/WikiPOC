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
        if (string.IsNullOrEmpty(safeName))
            return BadRequest("Invalid image name.");

        var baseDir = Path.GetFullPath(Path.Combine(_picturesPath, "profile_pictures/"));
        var matchingFile = Directory.GetFiles(baseDir, safeName).FirstOrDefault();
        if (matchingFile == null)
            return NotFound("Image not found.");

        var imageBytes = System.IO.File.ReadAllBytes(matchingFile);
        return File(imageBytes, "image/png");
    }

    [HttpGet("logo/{imageName}")]
    public IActionResult GetLogo(string imageName)
    {
        var safeName = Path.GetFileName(imageName);
        if (string.IsNullOrEmpty(safeName))
            return BadRequest("Invalid image name.");

        var baseDir = Path.GetFullPath(Path.Combine(_picturesPath, "logo/"));
        var matchingFile = Directory.GetFiles(baseDir, safeName).FirstOrDefault();
        if (matchingFile == null)
            return NotFound("Image not found.");

        var imageBytes = System.IO.File.ReadAllBytes(matchingFile);
        return File(imageBytes, "image/png");
    }
}