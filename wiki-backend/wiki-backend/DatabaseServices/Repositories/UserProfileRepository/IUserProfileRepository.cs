using wiki_backend.Models;

namespace wiki_backend.DatabaseServices.Repositories;

public interface IUserProfileRepository
{
    Task<UserProfile?> GetByIdAsync(Guid id);
    Task<UserProfile?> GetByUsernameAsync(string username);
    Task<UserProfile?> GetByUserIdAsync(string id);
    //Not needed for now
    // Task AddAsync(UserProfile wikiPage);
    Task UpdateAsync(Guid existingId , UserProfile updatedProfile, IFormFile? profilePictureFile);
    Task DeleteAsync(Guid id);
}