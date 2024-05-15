using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using wiki_backend.Models;
using Bogus;
using wiki_backend.Models.ForumModels;

namespace wiki_backend.DatabaseServices;

public class WikiDbContext : IdentityDbContext<ApplicationUser>
{
    private readonly IConfiguration _configuration;

    public WikiDbContext(DbContextOptions<WikiDbContext> options, IConfiguration configuration)
        : base(options)
    {
        _configuration = configuration;
        if (Database.IsRelational()) Database.Migrate();
    }

    // Parameterless constructor for Moq (only for testing purposes)
    // public WikiDbContext() : base()
    // {
    //     // Parameterless constructor
    // }

    public DbSet<WikiPage> WikiPages { get; set; }
    public DbSet<UserSubmittedWikiPage> UserSubmittedWikiPages { get; set; }
    public DbSet<Paragraph> Paragraphs { get; set; }
    public DbSet<StyleModel> Styles { get; set; }
    public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<UserComment> UserComments { get; set; }
    public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<ForumPost> ForumPosts { get; set; }
    public DbSet<ForumTopic> ForumTopics { get; set; }
    public DbSet<ForumComment> ForumComments { get; set; }

protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var faker = new Faker();
        
        modelBuilder.Entity<WikiPage>()
            .Property(wp => wp.Id)
            .ValueGeneratedOnAdd()
            .HasDefaultValueSql("NEWID()");
        
        modelBuilder.Entity<WikiPage>()
            .HasMany(wp => wp.Paragraphs)
            .WithOne(p => p.WikiPage)
            .HasForeignKey(p => p.WikiPageId)
            .HasPrincipalKey(wp => wp.Id);

        modelBuilder.Entity<WikiPage>()
            .HasMany(wp => wp.Comments)
            .WithOne(c => c.WikiPage)
            .HasForeignKey(c => c.WikiPageId);
        
        modelBuilder.Entity<WikiPage>()
            .HasOne(wp => wp.Category) // Navigation property
            .WithMany(c => c.WikiPages) // Collection navigation property in Category
            .HasForeignKey(wp => wp.CategoryId) // Foreign key
            .OnDelete(DeleteBehavior.Restrict); // Set delete behavior as you need
        
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
            .HasOne(uc => uc.WikiPage)
            .WithMany(wp => wp.Comments)
            .HasForeignKey(uc => uc.WikiPageId);
        
        modelBuilder.Entity<UserComment>()
            .HasOne(uc => uc.UserProfile)
            .WithMany() // No need to have a navigation property in UserProfile
            .HasForeignKey(uc => uc.UserProfileId);
        
        modelBuilder.Entity<ForumTopic>()
            .Property(ft => ft.Order);
        
        modelBuilder.Entity<ForumPost>()
            .HasOne(fp => fp.ForumTopic)
            .WithMany(ft => ft.ForumPosts) // Assuming you have a ForumPosts navigation property in ForumTopic
            .HasForeignKey(fp => fp.ForumTopicId)  
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<ForumPost>()
            .HasOne(fp => fp.User)
            .WithMany()
            .HasForeignKey(fp => fp.UserId)  
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<ForumPost>()
            .HasMany(fp => fp.Comments)
            .WithOne(c => c.ForumPost)
            .HasForeignKey(c => c.ForumPostId)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<ForumComment>()
            .HasOne(fc => fc.ForumPost)
            .WithMany(fp => fp.Comments)
            .HasForeignKey(fc => fc.ForumPostId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ForumComment>()
            .HasOne(fc => fc.UserProfile)
            .WithMany()
            .HasForeignKey(fc => fc.UserProfileId);

        modelBuilder.Entity<ForumComment>()
            .HasOne(fc => fc.ReplyToComment)
            .WithMany()
            .HasForeignKey(fc => fc.ReplyToCommentId)
            .OnDelete(DeleteBehavior.Restrict);
        
        //Generating Article IDs
        var wikiPage1Id = Guid.NewGuid();
        var wikiPage2Id = Guid.NewGuid();
        var wikiPage3Id = Guid.NewGuid();
        var wikiPage4Id = Guid.NewGuid();
        
        //Generating Category Ids
        var category1Id = Guid.NewGuid();
        var category2Id = Guid.NewGuid();
        var category3Id = Guid.NewGuid();
        var category4Id = Guid.NewGuid();
        
        var paragraphs1 = new List<Paragraph>()
        {
            new Paragraph
            {
                Id = Guid.NewGuid(), 
                WikiPageId = wikiPage1Id,
                Title = $"Example Page 1 - Paragraph 1",
                Content = faker.Lorem.Paragraphs(faker.Random.Number(1, 10)), // Generate bogus lorem ipsum-like content
                ParagraphImage = "https://html5-templates.com/demo/wikipedia-template/img/pencil.jpg",
                ParagraphImageText = "Example ParagraphImageText 1"
            }
        };
        paragraphs1.AddRange(Enumerable.Range(2, 5).Select(index => new Paragraph
        {
            Id = Guid.NewGuid(), 
            WikiPageId = wikiPage1Id,
            Title = $"Example Page 1 - Paragraph {index}",
            Content = faker.Lorem.Paragraphs(faker.Random.Number(1, 10)), // Generate bogus lorem ipsum-like content
        }));

        var paragraphs2 = new List<Paragraph>()
        {
            new Paragraph
            {
                Id = Guid.NewGuid(), 
                WikiPageId = wikiPage2Id,
                Title = $"Example Page 2 - Paragraph 1",
                Content = faker.Lorem.Paragraphs(faker.Random.Number(1, 10)), // Generate bogus lorem ipsum-like content
                ParagraphImage = "https://html5-templates.com/demo/wikipedia-template/img/pencil.jpg",
                ParagraphImageText = "Example ParagraphImageText 2"
            }
        };
        paragraphs2.AddRange(Enumerable.Range(2, 5).Select(index => new Paragraph
        {
            Id = Guid.NewGuid(), 
            WikiPageId = wikiPage2Id,
            Title = $"Example Page 2 - Paragraph {index}",
            Content = faker.Lorem.Paragraphs(faker.Random.Number(1, 10)),
        }));

        var wp1 = new WikiPage
        {
            Id = wikiPage1Id,
            Title = "Example Page 1",
            SiteSub = "Example SiteSub 1",
            RoleNote = "Example RoleNote 1",
            LegacyWikiPage = true,
            PostDate = DateTime.Now,
            CategoryId = category1Id,
            // Paragraphs = paragraphs1
        };

        var wp2 = new WikiPage
        {
            Id = wikiPage2Id,
            Title = "Example Page 2",
            SiteSub = "Example SiteSub 2",
            RoleNote = "Example RoleNote 2",
            LegacyWikiPage = true,
            PostDate = DateTime.Now,
            CategoryId = category2Id,
            // Paragraphs = paragraphs2
        };
        
        modelBuilder.Entity<WikiPage>().HasData(
            wp1,
            wp2
        );

        var uswp1 = new UserSubmittedWikiPage
        {
            Id = wikiPage3Id,
            Title = "User Submitted Page",
            SiteSub = "User Submitted SiteSub",
            RoleNote = "User Submitted RoleNote",
            SubmittedBy = "tester",
            LegacyWikiPage = true,
            IsNewPage = true,
            PostDate = DateTime.Now,
            CategoryId = category3Id,
        };
        var uswp2 = new UserSubmittedWikiPage
        {
            Id = wikiPage4Id,
            WikiPageId = wikiPage1Id,
            Title = "Example Page 1",
            SiteSub = "Example SiteSub 1 Update",
            RoleNote = "Example RoleNote 1 Update",
            SubmittedBy = "tester",
            LegacyWikiPage = true,
            IsNewPage = false,
            PostDate = DateTime.Now,
            CategoryId = category4Id,
        };
        modelBuilder.Entity<UserSubmittedWikiPage>().HasData(
            uswp1,
            uswp2
        );

        var paragraphs3 = new List<Paragraph>()
        {
            new Paragraph
            {
                Id = Guid.NewGuid(),
                WikiPageId = wikiPage3Id,
                Title = "User Submitted Paragraph 1",
                Content = "User Submitted Content 1",
                ParagraphImage = "https://i.kym-cdn.com/entries/icons/original/000/029/079/hellothere.jpg",
                ParagraphImageText = "Hello there"
            },
            new Paragraph
            {
                Id = Guid.NewGuid(),
                WikiPageId = wikiPage3Id,
                Title = "User Submitted Paragraph 2",
                Content = "User Submitted Content 2",
                ParagraphImage = "https://i.ytimg.com/vi/jAB3mMdS0xE/maxresdefault.jpg",
                ParagraphImageText = "General Kenobi"
            },
            new Paragraph
            {
                Id = Guid.NewGuid(),
                WikiPageId = wikiPage4Id,
                Title = "New Paragraph 1",
                Content = "Helldivers never die!",
                ParagraphImage = "https://i.ytimg.com/vi/nhhICroqfpU/hq720_live.jpg",
                ParagraphImageText = "Helldivers never die!"
            },
            new Paragraph
            {
                Id = Guid.NewGuid(),
                WikiPageId = wikiPage4Id,
                Title = "Liber-Tea",
                Content = "Liber-Tea is a funny line haha",
                ParagraphImage = "https://i.kym-cdn.com/photos/images/original/002/760/001/66d",
                ParagraphImageText = "Time for a nice cup of Liber-Tea"
            }
        };
        
        modelBuilder.Entity<Paragraph>().HasData(
            paragraphs1.Concat(paragraphs2).Concat(paragraphs3).ToList()
        );

        modelBuilder.Entity<Category>().HasData(
            new List<Category>()
            {
                new Category
                {
                    Id = category1Id,
                    CategoryName = "Characters",
                },
                new Category
                {
                    Id = category2Id,
                    CategoryName = "Stories",
                },
                new Category
                {
                    Id = category3Id,
                    CategoryName = "Locations",
                },
                new Category
                {
                    Id = category4Id,
                    CategoryName = "Events",
                },
                new Category
                {
                    Id = Guid.NewGuid(),
                    CategoryName = "Organizations"
                },
                new Category
                {
                    Id = Guid.NewGuid(),
                    CategoryName = "Concepts"
                },
                new Category
                {
                    Id = Guid.NewGuid(),
                    CategoryName = "Technologies"
                },
                new Category
                {
                    Id = Guid.NewGuid(),
                    CategoryName = "Arts and Entertainment"
                },
                new Category
                {
                    Id = Guid.NewGuid(),
                    CategoryName = "Sports and Recreation"
                },
                new Category
                {
                    Id = Guid.NewGuid(),
                    CategoryName = "Science and Technology"
                },
                new Category
                {
                    Id = Guid.NewGuid(),
                    CategoryName = "History and Culture"
                },
                new Category
                {
                    Id = Guid.NewGuid(),
                    CategoryName = "Food and Drink"
                }
            }
        );

        
        modelBuilder.Entity<StyleModel>().HasData(
            new StyleModel
            {
                Id = 1,
                Logo = "logo/logo_pfp.png",
                WikiName = "Your Wiki",
                BodyColor = "#507ced",
                ArticleRightColor = "#3c5fb8",
                ArticleRightInnerColor = "#2b4ea6",
                ArticleColor = "#526cad",
                FooterListLinkTextColor = "#1d305e",
                FooterListTextColor = "#233a71",
                FontFamily = "Arial, sans-serif",
            }
        );
        
    }
    
}