using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using wiki_backend.Models;
using wiki_backend.Objects;

namespace wiki_backend.DatabaseServices;

public class WikiDbContext : IdentityDbContext
{
    private readonly IConfiguration _configuration;

    public WikiDbContext(DbContextOptions<WikiDbContext> options, IConfiguration configuration)
        : base(options)
    {
        _configuration = configuration;
        if(Database.IsRelational()) Database.Migrate();
    }
    public DbSet<WikiPage> WikiPages { get; set; }
    public DbSet<Paragraph> Paragraphs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<WikiPage>()
            .HasMany(w => w.Paragraphs)
            .WithOne()
            .HasForeignKey(p => p.WikiPageId); 
        // Add any additional model configuration here
        // For example, configuring relationships, setting primary keys, etc.
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = _configuration.GetConnectionString("DefaultConnection");
        Console.WriteLine(connectionString);
        optionsBuilder.UseSqlServer(connectionString);
    }
}