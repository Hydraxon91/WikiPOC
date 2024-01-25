﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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
        if(Database.IsRelational()) Database.Migrate();
    }
    public DbSet<WikiPage> WikiPages { get; set; }
    public DbSet<Paragraph> Paragraphs { get; set; }
    public DbSet<StyleModel> Styles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

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
            },
            new WikiPage
            {
                Id = 2,
                Title = "Example Page 2",
                SiteSub = "Example SiteSub 2",
                RoleNote = "Example RoleNote 2",
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
                WikiPageId = 1,
                Title = "Example Paragraph 2",
                Content = "Example content 2"
            },
            new Paragraph
            {
                Id = 3,
                WikiPageId = 2,
                Title = "Example Paragraph 3",
                Content = "Example content 3",
                ParagraphImage = "https://html5-templates.com/demo/wikipedia-template/img/pencil.jpg",
                ParagraphImageText = "Example ParagraphImageText3"
            },
            new Paragraph
            {
                Id = 4,
                WikiPageId = 2,
                Title = "Example Paragraph 4",
                Content = "Example content 4"
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