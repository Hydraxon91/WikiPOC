using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using wiki_backend.DatabaseServices;
using wiki_backend.Models;
using wiki_backend.Models.ForumModels;

namespace wiki_backend.Services.Database;

public class DbInitializer : IHostedService
{
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly IConfiguration _configuration;

    public DbInitializer(IServiceScopeFactory scopeFactory, IConfiguration configuration)
    {
        _scopeFactory = scopeFactory;
        _configuration = configuration;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        if (_configuration["ASPNETCORE_ENVIRONMENT"] == "Testing")
            return;

        using (var scope = _scopeFactory.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<WikiDbContext>();
            await dbContext.Database.MigrateAsync(cancellationToken);
            await BackfillSlugsAsync(dbContext);
        }

        await AddRolesAsync();
        await AddAdminAsync();
        await AddModeratorAsync();
        await AddUserAsync();
        await SeedCategoriesAsync();
        await SeedWikiPagesAsync();
        await SeedStylesAsync();
        await SeedForumTopicsAsync();
        await SeedCommentsAsync();
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;

    private static async Task BackfillSlugsAsync(WikiDbContext dbContext)
    {
        var pagesWithoutSlug = await dbContext.WikiPages
            .Where(wp => wp.Slug == null)
            .ToListAsync();

        if (pagesWithoutSlug.Count == 0)
            return;

        var existingSlugs = await dbContext.WikiPages
            .Where(wp => wp.Slug != null)
            .Select(wp => wp.Slug!)
            .ToHashSetAsync();

        foreach (var page in pagesWithoutSlug)
        {
            var baseSlug = SlugHelper.Slugify(page.Title);
            var slug = baseSlug;
            var suffix = 2;
            while (existingSlugs.Contains(slug))
            {
                slug = $"{baseSlug}-{suffix}";
                suffix++;
            }
            page.Slug = slug;
            existingSlugs.Add(slug);
        }

        await dbContext.SaveChangesAsync();
    }

    private async Task AddRolesAsync()
    {
        using var scope = _scopeFactory.CreateScope();
        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        if (!await roleManager.RoleExistsAsync("Admin"))
        {
            await roleManager.CreateAsync(new IdentityRole("Admin"));
        }

        if (!await roleManager.RoleExistsAsync("User"))
        {
            await roleManager.CreateAsync(new IdentityRole("User"));
        }

        if (!await roleManager.RoleExistsAsync("Moderator"))
        {
            await roleManager.CreateAsync(new IdentityRole("Moderator"));
        }

        if (!await roleManager.RoleExistsAsync("Owner"))
        {
            await roleManager.CreateAsync(new IdentityRole("Owner"));
        }
    }

    private static async Task<ApplicationUser?> CreateUserWithProfileAsync(
        UserManager<ApplicationUser> userManager,
        WikiDbContext dbContext,
        string userName,
        string email,
        string password,
        string displayName,
        string profilePicture,
        string roleName)
    {
        var profile = new UserProfile
        {
            UserName = userName,
            DisplayName = displayName,
            ProfilePicture = profilePicture,
            JoinDate = DateTime.UtcNow
        };
        await dbContext.UserProfiles.AddAsync(profile);
        await dbContext.SaveChangesAsync();

        var user = new ApplicationUser
        {
            UserName = userName,
            Email = email,
            ProfileId = profile.Id
        };

        var created = await userManager.CreateAsync(user, password);
        if (!created.Succeeded) return null;

        await userManager.AddToRoleAsync(user, roleName);
        profile.UserId = user.Id;
        dbContext.UserProfiles.Update(profile);
        await dbContext.SaveChangesAsync();
        return user;
    }

    private async Task AddAdminAsync()
    {
        using var scope = _scopeFactory.CreateScope();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        var dbContext = scope.ServiceProvider.GetRequiredService<WikiDbContext>();
        var adminInDb = await userManager.FindByEmailAsync("admin@admin.com");
        if (adminInDb != null) return;

        await CreateUserWithProfileAsync(
            userManager, dbContext,
            _configuration["ADMINUSER_USERNAME"]!,
            _configuration["ADMINUSER_EMAIL"]!,
            _configuration["ADMINUSER_PASSWORD"]!,
            "Hydraxon",
            "admin_base.gif",
            "Owner");
    }

    private async Task AddModeratorAsync()
    {
        var modUsername = _configuration["MODERATOR_USERNAME"];
        if (string.IsNullOrEmpty(modUsername)) return;
        var modEmail = _configuration["MODERATOR_EMAIL"];
        if (string.IsNullOrEmpty(modEmail)) return;
        var modPassword = _configuration["MODERATOR_PASSWORD"];
        if (string.IsNullOrEmpty(modPassword)) return;

        using var scope = _scopeFactory.CreateScope();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        var dbContext = scope.ServiceProvider.GetRequiredService<WikiDbContext>();
        var modInDb = await userManager.FindByEmailAsync(modEmail);
        if (modInDb != null) return;

        await CreateUserWithProfileAsync(
            userManager, dbContext,
            modUsername, modEmail, modPassword,
            "Moderator",
            "default_pfp.png",
            "Moderator");
    }

    private async Task AddUserAsync()
    {
        using var scope = _scopeFactory.CreateScope();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        var dbContext = scope.ServiceProvider.GetRequiredService<WikiDbContext>();
        var userInDb = await userManager.FindByEmailAsync(_configuration["TESTUSER_EMAIL"]!);
        if (userInDb != null) return;

        await CreateUserWithProfileAsync(
            userManager, dbContext,
            _configuration["TESTUSER_USERNAME"]!,
            _configuration["TESTUSER_EMAIL"]!,
            _configuration["TESTUSER_PASSWORD"]!,
            "Peter Griffin",
            "tester_base.gif",
            "User");
    }

    private async Task SeedCategoriesAsync()
    {
        using var scope = _scopeFactory.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<WikiDbContext>();

        if (!await dbContext.Categories.AnyAsync())
        {
            var categories = new List<Category>
            {
                new() { CategoryName = "Characters" },
                new() { CategoryName = "Stories" },
                new() { CategoryName = "Locations" },
                new() { CategoryName = "Events" },
                new() { CategoryName = "Organizations" },
                new() { CategoryName = "Concepts" },
                new() { CategoryName = "Technologies" },
                new() { CategoryName = "Arts and Entertainment" },
                new() { CategoryName = "Sports and Recreation" },
                new() { CategoryName = "Science and Technology" },
                new() { CategoryName = "History and Culture" },
                new() { CategoryName = "Food and Drink" }
            };
            dbContext.Categories.AddRange(categories);
            await dbContext.SaveChangesAsync();
        }
    }

    private async Task SeedWikiPagesAsync()
    {
        using var scope = _scopeFactory.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<WikiDbContext>();

        if (!await dbContext.WikiPages.AnyAsync())
        {
            var characters = await dbContext.Categories.FirstAsync(c => c.CategoryName == "Characters");
            var stories = await dbContext.Categories.FirstAsync(c => c.CategoryName == "Stories");
            var locations = await dbContext.Categories.FirstAsync(c => c.CategoryName == "Locations");
            var events = await dbContext.Categories.FirstAsync(c => c.CategoryName == "Events");

            var wikiPage1 = new WikiPage
            {
                Title = "Example Page 1",
                SiteSub = "Example SiteSub 1",
                RoleNote = "Example RoleNote 1",
                PostDate = DateTime.UtcNow,
                CategoryId = characters.Id,
                Content = @"<h2>Example Page 1 - Paragraph 1</h2>
<p>This is the first paragraph of Example Page 1.</p>
<div class=""thumbnail left"">
  <div class=""thumbnail-inner"">
    <img class=""paragraph-image"" alt=""logo"" src=""https://html5-templates.com/demo/wikipedia-template/img/pencil.jpg"">
  </div>
  <div class=""wikipage-content-container"">
    <div>Example ParagraphImageText 1</div>
  </div>
</div>
<h2>Example Page 1 - Paragraph 2</h2>
<p>This is the second paragraph.</p>
<h2>Example Page 1 - Paragraph 3</h2>
<p>This is the third paragraph.</p>"
            };

            var wikiPage2 = new WikiPage
            {
                Title = "Example Page 2",
                SiteSub = "Example SiteSub 2",
                RoleNote = "Example RoleNote 2",
                PostDate = DateTime.UtcNow,
                CategoryId = stories.Id,
                Content = @"<h2>Example Page 2 - Paragraph 1</h2>
<p>This is the first paragraph of Example Page 2.</p>
<div class=""thumbnail right"">
  <div class=""thumbnail-inner"">
    <img class=""paragraph-image"" alt=""logo"" src=""https://html5-templates.com/demo/wikipedia-template/img/pencil.jpg"">
  </div>
  <div class=""wikipage-content-container"">
    <div>Example ParagraphImageText 2</div>
  </div>
</div>
<h2>Example Page 2 - Paragraph 2</h2>
<p>This is the second paragraph.</p>"
            };

            dbContext.WikiPages.AddRange(wikiPage1, wikiPage2);
            await dbContext.SaveChangesAsync();

            var userSubmittedPage = new UserSubmittedWikiPage
            {
                Title = "User Submitted Page",
                SiteSub = "User Submitted SiteSub",
                RoleNote = "User Submitted RoleNote",
                SubmittedBy = "tester",
                IsNewPage = true,
                PostDate = DateTime.UtcNow,
                CategoryId = locations.Id,
                Content = @"<h2>User Submitted Paragraph 1</h2>
<p>User Submitted Content 1</p>
<div class=""thumbnail left"">
  <div class=""thumbnail-inner"">
    <img class=""paragraph-image"" alt=""logo"" src=""https://i.kym-cdn.com/entries/icons/original/000/029/079/hellothere.jpg"">
  </div>
  <div class=""wikipage-content-container"">
    <div>Hello there</div>
  </div>
</div>
<h2>User Submitted Paragraph 2</h2>
<p>User Submitted Content 2</p>
<div class=""thumbnail right"">
  <div class=""thumbnail-inner"">
    <img class=""paragraph-image"" alt=""logo"" src=""https://i.ytimg.com/vi/jAB3mMdS0xE/maxresdefault.jpg"">
  </div>
  <div class=""wikipage-content-container"">
    <div>General Kenobi</div>
  </div>
</div>"
            };

            var userSubmittedUpdate = new UserSubmittedWikiPage
            {
                WikiPageId = wikiPage1.Id,
                Title = "Example Page 1",
                SiteSub = "Example SiteSub 1 Update",
                RoleNote = "Example RoleNote 1 Update",
                SubmittedBy = "tester",
                IsNewPage = false,
                PostDate = DateTime.UtcNow,
                CategoryId = events.Id,
                Content = @"<h2>New Paragraph 1</h2>
<p>Helldivers never die!</p>
<div class=""thumbnail left"">
  <div class=""thumbnail-inner"">
    <img class=""paragraph-image"" alt=""logo"" src=""https://i.ytimg.com/vi/nhhICroqfpU/hq720_live.jpg"">
  </div>
  <div class=""wikipage-content-container"">
    <div>Helldivers never die!</div>
  </div>
</div>
<h2>Liber-Tea</h2>
<p>Liber-Tea is a funny line haha</p>
<div class=""thumbnail right"">
  <div class=""thumbnail-inner"">
    <img class=""paragraph-image"" alt=""logo"" src=""https://i.kym-cdn.com/photos/images/original/002/760/001/66d"">
  </div>
  <div class=""wikipage-content-container"">
    <div>Time for a nice cup of Liber-Tea</div>
  </div>
</div>"
            };

            dbContext.UserSubmittedWikiPages.AddRange(userSubmittedPage, userSubmittedUpdate);
            await dbContext.SaveChangesAsync();
        }
    }

    private async Task SeedStylesAsync()
    {
        using var scope = _scopeFactory.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<WikiDbContext>();

        if (!await dbContext.Styles.AnyAsync(s => s.IsSystemPreset))
        {
            // Remove any legacy rows from before the multi-theme migration
            var legacyRows = await dbContext.Styles
                .Where(s => !s.IsSystemPreset)
                .ToListAsync();
            if (legacyRows.Count > 0)
                dbContext.Styles.RemoveRange(legacyRows);

            dbContext.Styles.AddRange(new List<StyleModel>
            {
                new()
                {
                    IsActive = true,
                    IsSystemPreset = true,
                    InterfaceEra = "wikipedia",
                    ThemeName = "Wikipedia Classic",
                    Logo = "logo/logo_pfp.png",
                    WikiName = "Your Wiki",
                    BodyColor = "#f8f9fa",
                    ArticleColor = "#ffffff",
                    ArticleRightColor = "#f8f9fa",
                    ArticleRightInnerColor = "#eaecf0",
                    FooterListTextColor = "#202122",
                    FooterListLinkTextColor = "#0645ad",
                    FontFamily = "'Linux Libertine', Georgia, serif",
                    GlassBgOpacity = 1.0,
                    GlassBlurRadius = 0,
                    GlassBorderReflection = 0,
                    BgMeshGradient = "none",
                    BorderRadius = "0px",
                    BorderStyle = "1px solid #a2a9b1",
                },
                new()
                {
                    IsActive = false,
                    IsSystemPreset = true,
                    InterfaceEra = "glass",
                    ThemeName = "Liquid Glass",
                    BodyColor = "#507ced",
                    ArticleColor = "#526cad",
                    ArticleRightColor = "#3c5fb8",
                    ArticleRightInnerColor = "#2b4ea6",
                    FooterListTextColor = "#233a71",
                    FooterListLinkTextColor = "#1d305e",
                    FontFamily = "Arial, sans-serif",
                    GlassBgOpacity = 0.35,
                    GlassBlurRadius = 12,
                    GlassBorderReflection = 0.15,
                    BgMeshGradient = "radial-gradient(circle at 20% 80%, rgba(80,124,237,0.4) 0%, transparent 50%), radial-gradient(circle at 80% 20%, rgba(82,108,173,0.3) 0%, transparent 50%), linear-gradient(135deg, #1a2a6c, #2b4ea6, #507ced)",
                    BorderRadius = "12px",
                    BorderStyle = "1px solid rgba(255,255,255,0.12)",
                },
                new()
                {
                    IsActive = false,
                    IsSystemPreset = true,
                    InterfaceEra = "modern",
                    ThemeName = "Modern Sleek",
                    BodyColor = "#0f1117",
                    ArticleColor = "#1a1d27",
                    ArticleRightColor = "#222639",
                    ArticleRightInnerColor = "#2a2f45",
                    FooterListTextColor = "#8b8fa3",
                    FooterListLinkTextColor = "#6c63ff",
                    FontFamily = "Inter, system-ui, sans-serif",
                    GlassBgOpacity = 0.95,
                    GlassBlurRadius = 0,
                    GlassBorderReflection = 0,
                    BgMeshGradient = "linear-gradient(135deg, #0f1117 0%, #1a1d27 50%, #222639 100%)",
                    BorderRadius = "4px",
                    BorderStyle = "1px solid rgba(255,255,255,0.06)",
                },
                new()
                {
                    IsActive = false,
                    IsSystemPreset = true,
                    InterfaceEra = "frutiger",
                    ThemeName = "Frutiger Aero",
                    BodyColor = "#2b8a3e",
                    ArticleColor = "#e8f5e9",
                    ArticleRightColor = "#a5d6a7",
                    ArticleRightInnerColor = "#66bb6a",
                    FooterListTextColor = "#1b5e20",
                    FooterListLinkTextColor = "#1565c0",
                    FontFamily = "Segoe UI, Tahoma, sans-serif",
                    GlassBgOpacity = 0.85,
                    GlassBlurRadius = 0,
                    GlassBorderReflection = 0.25,
                    BgMeshGradient = "linear-gradient(135deg, #2b8a3e 0%, #43a047 30%, #1b5e20 70%, #2b8a3e 100%)",
                    BorderRadius = "24px",
                    BorderStyle = "1px solid rgba(255,255,255,0.35)",
                },
            });
            await dbContext.SaveChangesAsync();
        }
    }

    private async Task SeedCommentsAsync()
    {
        using var scope = _scopeFactory.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<WikiDbContext>();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

        var adminUser = await userManager.FindByEmailAsync("admin@admin.com");
        var testUser = await userManager.FindByEmailAsync("test@test.com");

        if (adminUser != null && testUser != null)
        {
            var wikiPage = await dbContext.WikiPages
                .FirstOrDefaultAsync(wp => wp.Title == "Example Page 1" && wp.SiteSub == "Example SiteSub 1");

            if (wikiPage != null && !dbContext.UserComments.Any(comment => comment.WikiPageId == wikiPage.Id))
            {
                var comments = new List<UserComment>
                {
                    new UserComment
                    {
                        UserProfileId = adminUser.ProfileId,
                        UserProfile = adminUser.Profile,
                        Content = "Test comment from Admin",
                        WikiPageId = wikiPage.Id,
                        PostDate = DateTime.UtcNow,
                        IsEdited = false
                    },
                    new UserComment
                    {
                        UserProfileId = testUser.ProfileId,
                        UserProfile = testUser.Profile,
                        Content = "Test comment from Tester",
                        WikiPageId = wikiPage.Id,
                        PostDate = DateTime.UtcNow,
                        IsEdited = false
                    },
                    new UserComment
                    {
                        UserProfileId = testUser.ProfileId,
                        UserProfile = testUser.Profile,
                        Content = "Test comment 2 from Tester",
                        WikiPageId = wikiPage.Id,
                        PostDate = DateTime.UtcNow,
                        IsEdited = true
                    }
                };
                dbContext.UserComments.AddRange(comments);
                await dbContext.SaveChangesAsync();
            }
        }
    }

    private async Task SeedForumTopicsAsync()
    {
        using var scope = _scopeFactory.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<WikiDbContext>();

        if (!await dbContext.ForumTopics.AnyAsync())
        {
            var topics = new List<ForumTopic>
            {
                new() { Title = "Main Forum", Description = "General discussion forum for all topics.", Slug = "main-forum", Order = 0 },
                new() { Title = "Off Topic", Description = "Discussion forum for non-related topics.", Slug = "off-topic", Order = 1 },
                new() { Title = "Foreign Languages Forum", Description = "Forum for discussing topics in different languages.", Slug = "foreign-languages-forum", Order = 2 },
                new() { Title = "Archive", Description = "Forum for archived topics and discussions.", Slug = "archive", Order = 3 },
            };
            dbContext.ForumTopics.AddRange(topics);
            await dbContext.SaveChangesAsync();
        }
    }
}
