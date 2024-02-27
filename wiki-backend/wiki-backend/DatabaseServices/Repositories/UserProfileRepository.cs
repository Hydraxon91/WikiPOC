﻿using Microsoft.EntityFrameworkCore;
using wiki_backend.Models;

namespace wiki_backend.DatabaseServices.Repositories;

public class UserProfileRepository : IUserProfileRepository
{
    private readonly WikiDbContext _context;

    private UserProfileRepository(WikiDbContext context)
    {
        _context = context;
    }
    
    public async Task<UserProfile?> GetByIdAsync(int id)
    {
        return await _context.UserProfiles
            .Include(up => up.User)
            .SingleOrDefaultAsync(up => up.Id == id);
    }

    public async Task<UserProfile?> GetByUsernameAsync(string username)
    {
        return await _context.UserProfiles
            .Include(up => up.User)
            .SingleOrDefaultAsync(up => up.UserName == username);
    }

    //Not needed for now
    // public Task AddAsync(UserProfile wikiPage)
    // {
    //     throw new NotImplementedException();
    // }

    public async Task UpdateAsync(int existingId, UserProfile updatedProfile)
    {
        var existingProfile = await _context.UserProfiles.SingleOrDefaultAsync(up => up.Id == existingId);
        
        if (existingProfile == null)
        {
            throw new InvalidOperationException($"UserProfile with ID {existingId} not found.");
        }
        
        existingProfile.DisplayName = updatedProfile.DisplayName;
        existingProfile.ProfilePicture = updatedProfile.ProfilePicture;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var existingProfile = await _context.UserProfiles.SingleOrDefaultAsync(up => up.Id == id);

        if (existingProfile != null)
        {
            _context.UserProfiles.Remove(existingProfile);
            await _context.SaveChangesAsync();
        }
    }
}