using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using wiki_backend.Models;
using Bogus;

namespace wiki_backend.DatabaseServices;

public class WikiDbContext : IdentityDbContext<ApplicationUser>
{
    private readonly IConfiguration _configuration;

    public WikiDbContext(DbContextOptions<WikiDbContext> options, IConfiguration configuration)
        : base(options)
    {
        _configuration = configuration;
        if(Database.IsRelational()) Database.Migrate();
    }
    
    // Parameterless constructor for Moq (only for testing purposes)
    public WikiDbContext() : base()
    {
        // Parameterless constructor
    }
    public DbSet<WikiPage> WikiPages { get; set; }
    public DbSet<UserSubmittedWikiPage> UserSubmittedWikiPages { get; set; }
    public DbSet<Paragraph> Paragraphs { get; set; }
    public DbSet<StyleModel> Styles { get; set; }
    public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<UserComment> UserComments { get; set; }
    public DbSet<ApplicationUser> ApplicationUsers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var faker = new Faker();
        
        modelBuilder.Entity<WikiPage>().HasMany(wp => wp.Paragraphs)
            .WithOne(p => p.WikiPage)
            .HasForeignKey(p => p.WikiPageId)
            .HasPrincipalKey(p => p.Id);
        
        modelBuilder.Entity<UserSubmittedWikiPage>()
            .HasBaseType<WikiPage>()
            .HasOne(uswp => uswp.WikiPage)
            .WithMany()
            .HasForeignKey(uswp => uswp.WikiPageId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ApplicationUser>()
            .HasOne(au => au.Profile)
            .WithOne(up => up.User)
            .HasForeignKey<ApplicationUser>(au => au.ProfileId);
        
        modelBuilder.Entity<UserComment>()
            .HasOne(uc => uc.UserProfile)
            .WithMany()
            .HasForeignKey(uc => uc.UserProfileId);
        
        var paragraphs1 = new List<Paragraph>()
        {
            new Paragraph
            {
                Id = 1, // Set a negative value for Id
                WikiPageId = 1,
                Title = $"Example Page 1 - Paragraph 1",
                Content = faker.Lorem.Paragraphs(faker.Random.Number(1, 10)), // Generate bogus lorem ipsum-like content
                ParagraphImage = "https://html5-templates.com/demo/wikipedia-template/img/pencil.jpg",
                ParagraphImageText = "Example ParagraphImageText 1"
            }
        };
        paragraphs1.AddRange(Enumerable.Range(2, 5).Select(index => new Paragraph
        {
            Id = index, // Set negative values for Id
            WikiPageId = 1,
            Title = $"Example Page 1 - Paragraph {index}",
            Content = faker.Lorem.Paragraphs(faker.Random.Number(1, 10)), // Generate bogus lorem ipsum-like content
        }));

        var paragraphs2 = new List<Paragraph>()
        {
            new Paragraph
            {
                Id = 7, // Set a negative value for Id
                WikiPageId = 2,
                Title = $"Example Page 2 - Paragraph 1",
                Content = faker.Lorem.Paragraphs(faker.Random.Number(1, 10)), // Generate bogus lorem ipsum-like content
                ParagraphImage = "https://html5-templates.com/demo/wikipedia-template/img/pencil.jpg",
                ParagraphImageText = "Example ParagraphImageText 2"
            }
        };
        paragraphs2.AddRange(Enumerable.Range(2, 5).Select(index => new Paragraph
        {
            Id = index + 6, // Set negative values for Id
            WikiPageId = 2,
            Title = $"Example Page 2 - Paragraph {index}",
            Content = faker.Lorem.Paragraphs(faker.Random.Number(1, 10)), // Generate bogus lorem ipsum-like content
        }));

        modelBuilder.Entity<WikiPage>().HasData(
            new WikiPage
            {
                Id = 1,
                Title = "Example Page 1",
                SiteSub = "Example SiteSub 1",
                RoleNote = "Example RoleNote 1",
                // Paragraphs = paragraphs1
            },
            new WikiPage
            {
                Id = 2,
                Title = "Example Page 2",
                SiteSub = "Example SiteSub 2",
                RoleNote = "Example RoleNote 2",
                // Paragraphs = paragraphs2
            }
        );

        // modelBuilder.Entity<Paragraph>().HasData(
        //     paragraphs1.Concat(paragraphs2).ToList()
        // );

        modelBuilder.Entity<UserSubmittedWikiPage>().HasData(
            new UserSubmittedWikiPage
            {
                Id = 3,
                Title = "User Submitted Page",
                SiteSub = "User Submitted SiteSub",
                RoleNote = "User Submitted RoleNote", 
                SubmittedBy = "tester",
                IsNewPage = true
            },
            new UserSubmittedWikiPage
            {
                Id = 4,
                WikiPageId = 1,
                Title = "Example Page 1",
                SiteSub = "Example SiteSub 1 Update",
                RoleNote = "Example RoleNote 1 Update", 
                SubmittedBy = "tester",
                IsNewPage = false,
            }
        );

        var paragraphs3 = new List<Paragraph>()
        {
            new Paragraph
            {
                Id = 13,
                WikiPageId = 3,
                Title = "User Submitted Paragraph 1",
                Content = "User Submitted Content 1",
                ParagraphImage = "https://i.kym-cdn.com/entries/icons/original/000/029/079/hellothere.jpg",
                ParagraphImageText = "Hello there"
            },
            new Paragraph
            {
                Id = 14,
                WikiPageId = 3,
                Title = "User Submitted Paragraph 2",
                Content = "User Submitted Content 2",
                ParagraphImage = "https://i.ytimg.com/vi/jAB3mMdS0xE/maxresdefault.jpg",
                ParagraphImageText = "General Kenobi"
            },
            new Paragraph
            {
                Id = 15,
                WikiPageId = 4,
                Title = "New Paragraph 1",
                Content = "Helldivers never die!",
                ParagraphImage = "https://i.ytimg.com/vi/nhhICroqfpU/hq720_live.jpg",
                ParagraphImageText = "Helldivers never die!"
            },
            new Paragraph
            {
                Id = 16,
                WikiPageId = 4,
                Title = "Liber-Tea",
                Content = "Liber-Tea is a funny line haha",
                ParagraphImage = "https://i.kym-cdn.com/photos/images/original/002/760/001/66d",
                ParagraphImageText = "Time for a nice cup of Liber-Tea"
            }
        };
        
        modelBuilder.Entity<Paragraph>().HasData(
            paragraphs1.Concat(paragraphs2).Concat(paragraphs3).ToList()
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

    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     var connectionString = Environment.GetEnvironmentVariable("ASPNETCORE_CONNECTIONSTRING");
    //     // Console.WriteLine(connectionString);
    //     optionsBuilder.UseSqlServer(connectionString);
    //     optionsBuilder.EnableSensitiveDataLogging();
    //     optionsBuilder.EnableDetailedErrors();
    // }
    
}