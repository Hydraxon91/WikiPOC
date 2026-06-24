using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using wiki_backend.Services.Settings;

namespace wiki_backend.Controllers;

[ApiController]
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
        if (!System.IO.File.Exists(imagePath))
        {
            return NotFound(imagePath);
        }

        var imageBytes = System.IO.File.ReadAllBytes(imagePath);
        return File(imageBytes, "image/png"); 
    }
    [HttpGet("logo/{imageName}")]
    public IActionResult GetLogo(string imageName)
    {
        var safeName = Path.GetFileName(imageName);
        var imagePath = Path.Combine(_picturesPath, "logo/", safeName);
        if (!System.IO.File.Exists(imagePath))
        {
            return NotFound(imagePath);
        }

        var imageBytes = System.IO.File.ReadAllBytes(imagePath);
        return File(imageBytes, "image/png"); 
    }
}