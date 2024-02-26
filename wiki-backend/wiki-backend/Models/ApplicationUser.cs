using Microsoft.AspNetCore.Identity;

namespace wiki_backend.Models;

public class ApplicationUser : IdentityUser
{
    public UserProfile? UserProfile { get; set; }
    public int ProfileId { get; set; }
}