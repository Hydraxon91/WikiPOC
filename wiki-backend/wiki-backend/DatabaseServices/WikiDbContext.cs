using Microsoft.EntityFrameworkCore;
using wiki_backend.Models;
using wiki_backend.Objects;

namespace wiki_backend.DatabaseServices;

public class WikiDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<WikiPage> WikiPages { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Add any additional model configuration here
        // For example, configuring relationships, setting primary keys, etc.
    }
}