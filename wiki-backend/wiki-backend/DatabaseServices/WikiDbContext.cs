using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using wiki_backend.Models;
using Bogus;

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
    public DbSet<StyleModel> Styles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var faker = new Faker();
        
        modelBuilder.Entity<WikiPage>().HasMany(wp => wp.Paragraphs)
            .WithOne(p => p.WikiPage)
            .HasForeignKey(p => p.WikiPageId)
            .HasPrincipalKey(p => p.Id);
        
        modelBuilder.Entity<WikiPage>().HasData(
            new WikiPage
            {
                Id = 1,
                Title = "Example Page 1",
                SiteSub = "Example SiteSub 1",
                RoleNote = "Example RoleNote 1",
                // IntroductionParagraph = "Introduction Paragraph 1"
            },
            new WikiPage
            {
                Id = 2,
                Title = "Example Page 2",
                SiteSub = "Example SiteSub 2",
                RoleNote = "Example RoleNote 2",
                // IntroductionParagraph = "Introduction Paragraph 2"
            }
        );

        modelBuilder.Entity<Paragraph>().HasData(
            new Paragraph
            {
                Id = 1,
                WikiPageId = 1,
                Title = "Example Paragraph 1",
                Content = "Example content 1",
                ParagraphImage = "https://html5-templates.com/demo/wikipedia-template/img/pencil.jpg",
                ParagraphImageText = "Example ParagraphImageText 1"
            },
            new Paragraph
            {
                Id = 2,
                WikiPageId = 2,
                Title = "Example Paragraph 2",
                Content = "Example content 2",
                ParagraphImage = "https://html5-templates.com/demo/wikipedia-template/img/pencil.jpg",
                ParagraphImageText = "<Link to=\"/page/Example%20Page%201\"> This links to Example page 1 </Link>"
            }
        );
        
        // Seed Paragraph data with Bogus
        modelBuilder.Entity<Paragraph>().HasData(
            Enumerable.Range(3, 15).Select(index => new Paragraph
            {
                Id = index,
                WikiPageId = faker.Random.Number(1, 2), // Randomly assign to WikiPage 1 or 2
                Title = $"Example Paragraph {index}",
                Content = faker.Lorem.Paragraphs(5), // Generate bogus lorem ipsum-like content
            }).ToArray()
        );
        
        modelBuilder.Entity<StyleModel>().HasData(
            new StyleModel
            {
                Id = 1,
                Logo = "/img/logo.png",
                WikiName = "Your Wiki",
                BodyColor = "#507ced",
                ArticleRightColor = "#3c5fb8",
                ArticleRightInnerColor = "#2b4ea6",
                ArticleColor = "#526cad",
                FooterListLinkTextColor = "#1d305e",
                FooterListTextColor = "#233a71"
            }
        );
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