using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using wiki_backend.Models;
using wiki_backend.Models.ForumModels;

namespace wiki_backend.DatabaseServices;

public class WikiDbContext : IdentityDbContext<ApplicationUser>
{
    private readonly IConfiguration _configuration;


    public WikiDbContext(DbContextOptions<WikiDbContext> options, IConfiguration configuration)
        : base(options)
    {
        _configuration = configuration;
    }

    public WikiDbContext(DbContextOptions<WikiDbContext> options)
        : base(options)
    {
        _configuration = null!;
    }
    

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
            .HasOne(wp => wp.Category)
            .WithMany(c => c.WikiPages)
            .HasForeignKey(wp => wp.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

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
            .WithMany()
            .HasForeignKey(uc => uc.UserProfileId);

        modelBuilder.Entity<UserComment>()
            .HasOne(uc => uc.ReplyToComment)
            .WithMany(uc => uc.Replies)
            .HasForeignKey(uc => uc.ReplyToCommentId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ForumTopic>()
            .Property(ft => ft.Order);

        modelBuilder.Entity<ForumPost>()
            .HasOne(fp => fp.ForumTopic)
            .WithMany(ft => ft.ForumPosts)
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
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ForumComment>()
            .HasOne(fc => fc.ForumPost)
            .WithMany(fp => fp.Comments)
            .HasForeignKey(fc => fc.ForumPostId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ForumComment>()
            .HasOne(fc => fc.UserProfile)
            .WithMany()
            .HasForeignKey(fc => fc.UserProfileId);

        modelBuilder.Entity<ForumComment>()
            .HasOne(fc => fc.ReplyToComment)
            .WithMany()
            .HasForeignKey(fc => fc.ReplyToCommentId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}