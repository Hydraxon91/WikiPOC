﻿namespace wiki_backend.Models;

public class UserUpdateForm
{
    public UserProfile? UserProfile { get; set; } 
    public IFormFile? ProfilePictureFile { get; set; } 
    
    public override string ToString()
    {
        return $"{UserProfile.DisplayName}";
    }
}