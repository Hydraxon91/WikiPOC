using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using wiki_backend.Models;
using wiki_backend.Services.Settings;
using wiki_backend.Services.Storage;

namespace wiki_backend.DatabaseServices.Repositories;

public class UserProfileRepository : IUserProfileRepository
{
    private readonly WikiDbContext _context;
    private readonly string _picturesPath;

    public UserProfileRepository(WikiDbContext context, IOptions<StorageSettings> storageSettings)
    {
        _context = context;
        _picturesPath = storageSettings.Value.PicturesPath;
    }
    
    private async Task SetPostCount(UserProfile profile)
    {
        var forumPostCount = await _context.ForumPosts.CountAsync(fp => fp.UserId == profile.Id);
        var forumCommentCount = await _context.ForumComments.CountAsync(fc => fc.UserProfileId == profile.Id);
        profile.PostCount = forumPostCount + forumCommentCount;
    }

    public async Task<UserProfile?> GetByIdAsync(Guid id)
    {
        var profile = await _context.UserProfiles
            .Include(up => up.User)
            .SingleOrDefaultAsync(up => up.Id == id);
        if (profile != null) await SetPostCount(profile);
        return profile;
    }

    public async Task<UserProfile?> GetByUsernameAsync(string username)
    {
        var profile = await _context.UserProfiles
            .Include(up => up.User)
            .FirstOrDefaultAsync(up => up.UserName != null && up.UserName.ToLower() == username.ToLower());
        if (profile != null) await SetPostCount(profile);
        return profile;
    }

    public async Task<UserProfile?> GetByUserIdAsync(string id)
    {
        var profile = await _context.UserProfiles
            .Include(up => up.User)
            .SingleOrDefaultAsync(up => up.UserId == id);
        if (profile != null) await SetPostCount(profile);
        return profile;
    }

    public async Task UpdateAsync(Guid existingId, UserProfile updatedProfile, IFormFile? profilePictureFile)
    {
        var existingProfile = await _context.UserProfiles.SingleOrDefaultAsync(up => up.Id == existingId);
        
        if (existingProfile == null)
        {
            throw new InvalidOperationException($"UserProfile with ID {existingId} not found.");
        }
        
        existingProfile.DisplayName = updatedProfile.DisplayName;
        
        if (profilePictureFile != null)
        {
            if (!ImageStorageService.IsValidFileType(profilePictureFile.FileName))
                throw new InvalidOperationException("Invalid profile picture file type. Allowed: png, jpg, jpeg, gif, webp.");

            var dirPath = Path.Combine(_picturesPath, "profile_pictures");
            Directory.CreateDirectory(dirPath);
            var fileName = $"{existingProfile.UserName}_pfp{Path.GetExtension(profilePictureFile.FileName)}";
            var filePath = Path.Combine(dirPath, fileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await profilePictureFile.CopyToAsync(fileStream);
            }
            existingProfile.ProfilePicture = fileName;
        }
        
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var existingProfile = await _context.UserProfiles.SingleOrDefaultAsync(up => up.Id == id);

        if (existingProfile != null)
        {
            _context.UserProfiles.Remove(existingProfile);
            await _context.SaveChangesAsync();
        }
    }

    public async Task RemoveAsync(Guid id)
    {
        var existingProfile = await _context.UserProfiles.FindAsync(id);
        if (existingProfile != null)
        {
            _context.UserProfiles.Remove(existingProfile);
            await _context.SaveChangesAsync();
        }
    }
}