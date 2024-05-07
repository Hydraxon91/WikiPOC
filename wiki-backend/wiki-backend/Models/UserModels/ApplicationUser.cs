using Microsoft.AspNetCore.Identity;

namespace wiki_backend.Models;

public class ApplicationUser : IdentityUser
{
    public UserProfile? Profile { get; set; }
    public Guid ProfileId { get; set; }
}