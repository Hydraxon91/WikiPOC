using Microsoft.AspNetCore.Mvc;

namespace wiki_backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ImageController : ControllerBase
{
    private readonly string _imageDirectory;

    public ImageController(string imageDirectory)
    {
        _imageDirectory = imageDirectory;
    }

    [HttpGet("{imageName}")]
    public IActionResult GetImage(string imageName)
    {
        var imagePath = Path.Combine(_imageDirectory, imageName);
        if (!System.IO.File.Exists(imagePath))
        {
            return NotFound();
        }

        var imageBytes = System.IO.File.ReadAllBytes(imagePath);
        return File(imageBytes, "image/png"); // Adjust content type as needed
    }
}