using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using wiki_backend.DatabaseServices;
using wiki_backend.Models;
using wiki_backend.Models.ForumModels;

namespace wiki_backend.Services.Database;

public class DbInitializer : IHostedService
{
    private readonly IServiceScopeFactory _scopeFactory;

    public DbInitializer(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        if (Environment.GetEnvironmentVariable("Environment") == "Testing")
            return;

        await AddRolesAsync();
        await AddAdminAsync();
        await AddUserAsync();
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
            var adminName = Environment.GetEnvironmentVariable("ADMINUSER_USERNAME")!;
            
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
                Email = Environment.GetEnvironmentVariable("ADMINUSER_EMAIL")!,
                ProfileId = adminProfile.Id
            };
            
            var adminCreated = await userManager.CreateAsync(admin, Environment.GetEnvironmentVariable("ADMINUSER_PASSWORD")!);

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
        var userInDb = await userManager.FindByEmailAsync(Environment.GetEnvironmentVariable("TESTUSER_EMAIL")!);
        if (userInDb == null)
        {
            var testUsername = Environment.GetEnvironmentVariable("TESTUSER_USERNAME")!;
            
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
                Email = Environment.GetEnvironmentVariable("TESTUSER_EMAIL")!,
                ProfileId = testUserProfile.Id
            };
            
            var userCreated = await userManager.CreateAsync(testUser, Environment.GetEnvironmentVariable("TESTUSER_PASSWORD")!);

            if (userCreated.Succeeded)
            {
                await userManager.AddToRoleAsync(testUser, "User");
                testUserProfile.UserId = testUser.Id;
                dbContext.UserProfiles.Update(testUserProfile);
                await dbContext.SaveChangesAsync();
            }
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
                        PostDate = DateTime.Now,
                        IsEdited = false
                    },
                    new UserComment
                    {
                        UserProfileId = testUser.ProfileId,
                        UserProfile = testUser.Profile,
                        Content = "Test comment from Tester",
                        WikiPageId = wikiPage.Id,
                        PostDate = DateTime.Now,
                        IsEdited = false
                    },
                    new UserComment
                    {
                        UserProfileId = testUser.ProfileId,
                        UserProfile = testUser.Profile,
                        Content = "Test comment 2 from Tester",
                        WikiPageId = wikiPage.Id,
                        PostDate = DateTime.Now,
                        IsEdited = true
                    }
                };
                dbContext.UserComments.AddRange(comments);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
