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
            var baseSlug = Slugify(page.Title);
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

    private static string Slugify(string? title)
    {
        if (string.IsNullOrWhiteSpace(title))
            return "untitled";
        var slug = title.Trim().ToLowerInvariant();
        slug = slug.Replace(' ', '-');
        slug = System.Text.RegularExpressions.Regex.Replace(slug, @"[^a-z0-9\-]", "");
        slug = System.Text.RegularExpressions.Regex.Replace(slug, @"-+", "-").Trim('-');
        return string.IsNullOrEmpty(slug) ? "untitled" : slug;
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

    private async Task AddAdminAsync()
    {
        using var scope = _scopeFactory.CreateScope();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        var dbContext = scope.ServiceProvider.GetRequiredService<WikiDbContext>();
        var adminInDb = await userManager.FindByEmailAsync("admin@admin.com");
        if (adminInDb == null)
        {
            var adminName = _configuration["ADMINUSER_USERNAME"]!;
            
            var adminProfile = new UserProfile()
            {
                UserName = adminName,
                DisplayName = "Hydraxon",
                ProfilePicture = "admin_base.gif",
                JoinDate = DateTime.UtcNow
            };
            await dbContext.UserProfiles.AddAsync(adminProfile);
            await dbContext.SaveChangesAsync();
            
            var admin = new ApplicationUser
            {
                UserName = adminName,
            Email = _configuration["ADMINUSER_EMAIL"]!,
            ProfileId = adminProfile.Id
        };
        
        var adminCreated = await userManager.CreateAsync(admin, _configuration["ADMINUSER_PASSWORD"]!);

            if (adminCreated.Succeeded)
            {
                await userManager.AddToRoleAsync(admin, "Owner");
                adminProfile.UserId = admin.Id;
                dbContext.UserProfiles.Update(adminProfile);
                await dbContext.SaveChangesAsync();
            }
        }
    }

    private async Task AddModeratorAsync()
    {
        using var scope = _scopeFactory.CreateScope();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        var dbContext = scope.ServiceProvider.GetRequiredService<WikiDbContext>();
        var modUsername = _configuration["MODERATOR_USERNAME"];
        if (string.IsNullOrEmpty(modUsername)) return;
        var modEmail = _configuration["MODERATOR_EMAIL"];
        if (string.IsNullOrEmpty(modEmail)) return;
        var modPassword = _configuration["MODERATOR_PASSWORD"];
        if (string.IsNullOrEmpty(modPassword)) return;
        var modInDb = await userManager.FindByEmailAsync(modEmail);
        if (modInDb == null)
        {
            var modProfile = new UserProfile()
            {
                UserName = modUsername,
                DisplayName = "Moderator",
                ProfilePicture = "default_pfp.png",
                JoinDate = DateTime.UtcNow
            };
            await dbContext.UserProfiles.AddAsync(modProfile);
            await dbContext.SaveChangesAsync();

            var modUser = new ApplicationUser
            {
                UserName = modUsername,
                Email = modEmail,
                ProfileId = modProfile.Id
            };

            var modCreated = await userManager.CreateAsync(modUser, modPassword);

            if (modCreated.Succeeded)
            {
                await userManager.AddToRoleAsync(modUser, "Moderator");
                modProfile.UserId = modUser.Id;
                dbContext.UserProfiles.Update(modProfile);
                await dbContext.SaveChangesAsync();
            }
        }
    }

    private async Task AddUserAsync()
    {
        using var scope = _scopeFactory.CreateScope();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        var dbContext = scope.ServiceProvider.GetRequiredService<WikiDbContext>();
        var userInDb = await userManager.FindByEmailAsync(_configuration["TESTUSER_EMAIL"]!);
    if (userInDb == null)
    {
        var testUsername = _configuration["TESTUSER_USERNAME"]!;
            
            var testUserProfile = new UserProfile()
            {
                UserName = testUsername,
                DisplayName = "Peter Griffin",
                ProfilePicture = "tester_base.gif",
                JoinDate = DateTime.UtcNow
            };
            await dbContext.UserProfiles.AddAsync(testUserProfile);
            await dbContext.SaveChangesAsync();

            var testUser = new ApplicationUser
            {
                UserName = testUsername,
                Email = _configuration["TESTUSER_EMAIL"]!,
                ProfileId = testUserProfile.Id
            };
            
            var userCreated = await userManager.CreateAsync(testUser, _configuration["TESTUSER_PASSWORD"]!);

            if (userCreated.Succeeded)
            {
                await userManager.AddToRoleAsync(testUser, "User");
                testUserProfile.UserId = testUser.Id;
                dbContext.UserProfiles.Update(testUserProfile);
                await dbContext.SaveChangesAsync();
            }
        }
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

        if (!await dbContext.Styles.AnyAsync())
        {
            dbContext.Styles.Add(new StyleModel
            {
                Logo = "logo/logo_pfp.png",
                WikiName = "Your Wiki",
                BodyColor = "#507ced",
                ArticleRightColor = "#3c5fb8",
                ArticleRightInnerColor = "#2b4ea6",
                ArticleColor = "#526cad",
                FooterListLinkTextColor = "#1d305e",
                FooterListTextColor = "#233a71",
                FontFamily = "Arial, sans-serif",
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
