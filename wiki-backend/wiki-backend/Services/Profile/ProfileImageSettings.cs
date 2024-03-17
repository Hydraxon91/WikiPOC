namespace wiki_backend.Services.Profile;

public class ProfileImageSettings
{
    public string ProfileImagesPath { get; }

    public ProfileImageSettings(string profileImagesPath)
    {
        ProfileImagesPath = profileImagesPath;
    }
}