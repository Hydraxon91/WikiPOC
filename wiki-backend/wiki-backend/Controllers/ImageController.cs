﻿using Microsoft.AspNetCore.Mvc;
using wiki_backend.Services.Profile;

namespace wiki_backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ImageController : ControllerBase
{
    private readonly ProfileImageSettings _profileImageSettings;

    public ImageController(ProfileImageSettings profileImageSettings)
    {
        _profileImageSettings = profileImageSettings;
    }

    [HttpGet("{imageName}")]
    public IActionResult GetImage(string imageName)
    {
        var imagePath = Path.Combine(_profileImageSettings.ProfileImagesPath, imageName);
        if (!System.IO.File.Exists(imagePath))
        {
            return NotFound(imagePath);
        }

        var imageBytes = System.IO.File.ReadAllBytes(imagePath);
        return File(imageBytes, "image/png"); 
    }
}