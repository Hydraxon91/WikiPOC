using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using wiki_backend.DatabaseServices;
using wiki_backend.Models;

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
        }

        await AddRolesAsync();
        await AddAdminAsync();
        await AddUserAsync();
        await SeedCategoriesAsync();
        await SeedWikiPagesAsync();
        await SeedStylesAsync();
        await SeedCommentsAsync();
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;

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
                ProfilePicture = "admin_base.gif"
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
                await userManager.AddToRoleAsync(admin, "Admin");
                adminProfile.UserId = admin.Id;
                dbContext.UserProfiles.Update(adminProfile);
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
                ProfilePicture = "tester_base.gif"
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
                LegacyWikiPage = true,
                PostDate = DateTime.UtcNow,
                CategoryId = characters.Id
            };

            var wikiPage2 = new WikiPage
            {
                Title = "Example Page 2",
                SiteSub = "Example SiteSub 2",
                RoleNote = "Example RoleNote 2",
                LegacyWikiPage = true,
                PostDate = DateTime.UtcNow,
                CategoryId = stories.Id
            };

            dbContext.WikiPages.AddRange(wikiPage1, wikiPage2);

            var paragraphs1 = new List<Paragraph>
            {
                new() { WikiPageId = wikiPage1.Id, Title = "Example Page 1 - Paragraph 1", Content = "This is the first paragraph of Example Page 1.", ParagraphImage = "https://html5-templates.com/demo/wikipedia-template/img/pencil.jpg", ParagraphImageText = "Example ParagraphImageText 1" },
                new() { WikiPageId = wikiPage1.Id, Title = "Example Page 1 - Paragraph 2", Content = "This is the second paragraph." },
                new() { WikiPageId = wikiPage1.Id, Title = "Example Page 1 - Paragraph 3", Content = "This is the third paragraph." }
            };

            var paragraphs2 = new List<Paragraph>
            {
                new() { WikiPageId = wikiPage2.Id, Title = "Example Page 2 - Paragraph 1", Content = "This is the first paragraph of Example Page 2.", ParagraphImage = "https://html5-templates.com/demo/wikipedia-template/img/pencil.jpg", ParagraphImageText = "Example ParagraphImageText 2" },
                new() { WikiPageId = wikiPage2.Id, Title = "Example Page 2 - Paragraph 2", Content = "This is the second paragraph." }
            };

            dbContext.Paragraphs.AddRange(paragraphs1.Concat(paragraphs2));
            await dbContext.SaveChangesAsync();

            var userSubmittedPage = new UserSubmittedWikiPage
            {
                Title = "User Submitted Page",
                SiteSub = "User Submitted SiteSub",
                RoleNote = "User Submitted RoleNote",
                SubmittedBy = "tester",
                LegacyWikiPage = true,
                IsNewPage = true,
                PostDate = DateTime.UtcNow,
                CategoryId = locations.Id
            };

            var userSubmittedUpdate = new UserSubmittedWikiPage
            {
                WikiPageId = wikiPage1.Id,
                Title = "Example Page 1",
                SiteSub = "Example SiteSub 1 Update",
                RoleNote = "Example RoleNote 1 Update",
                SubmittedBy = "tester",
                LegacyWikiPage = true,
                IsNewPage = false,
                PostDate = DateTime.UtcNow,
                CategoryId = events.Id
            };

            dbContext.UserSubmittedWikiPages.AddRange(userSubmittedPage, userSubmittedUpdate);

            var submittedParagraphs = new List<Paragraph>
            {
                new() { WikiPageId = userSubmittedPage.Id, Title = "User Submitted Paragraph 1", Content = "User Submitted Content 1", ParagraphImage = "https://i.kym-cdn.com/entries/icons/original/000/029/079/hellothere.jpg", ParagraphImageText = "Hello there" },
                new() { WikiPageId = userSubmittedPage.Id, Title = "User Submitted Paragraph 2", Content = "User Submitted Content 2", ParagraphImage = "https://i.ytimg.com/vi/jAB3mMdS0xE/maxresdefault.jpg", ParagraphImageText = "General Kenobi" },
                new() { WikiPageId = userSubmittedUpdate.Id, Title = "New Paragraph 1", Content = "Helldivers never die!", ParagraphImage = "https://i.ytimg.com/vi/nhhICroqfpU/hq720_live.jpg", ParagraphImageText = "Helldivers never die!" },
                new() { WikiPageId = userSubmittedUpdate.Id, Title = "Liber-Tea", Content = "Liber-Tea is a funny line haha", ParagraphImage = "https://i.kym-cdn.com/photos/images/original/002/760/001/66d", ParagraphImageText = "Time for a nice cup of Liber-Tea" }
            };

            dbContext.Paragraphs.AddRange(submittedParagraphs);
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
}
