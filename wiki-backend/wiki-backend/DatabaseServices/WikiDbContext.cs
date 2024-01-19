using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using wiki_backend.Models;

namespace wiki_backend.DatabaseServices;

public class WikiDbContext : IdentityDbContext
{
    private readonly IConfiguration _configuration;

    public WikiDbContext(DbContextOptions<WikiDbContext> options, IConfiguration configuration)
        : base(options)
    {
        _configuration = configuration;
    }
    public DbSet<WikiPage> WikiPages { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Add any additional model configuration here
        // For example, configuring relationships, setting primary keys, etc.
    }
    public void ConfigureServices(IServiceCollection services)
    {
        // Add DbContext with IConfiguration dependency
        services.AddDbContext<WikiDbContext>(options =>
            options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));
        
    }
}