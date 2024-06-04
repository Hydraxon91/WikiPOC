using System;
using System.Threading.Channels;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using wiki_backend.DatabaseServices;
using wiki_backend.Models;
using DotNetEnv;
using IntegrationTests.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using wiki_backend.Contracts;
using wiki_backend.Controllers;
using wiki_backend.DatabaseServices.Repositories;
using wiki_backend.Services.Authentication;

namespace IntegrationTests
{
    public class IntegrationTestBase : IDisposable
    {
        protected readonly ServiceProvider ServiceProvider;
        protected readonly WikiDbContext DbContext;
        protected readonly string JwtTokenTime;
        protected readonly string JwtValidIssuer;
        protected readonly string JwtValidAudience;
        protected readonly string JwtIssuerSigningKey;
        protected readonly string PicturesPathContainer;
        private readonly string DbConnectionString;
        protected AuthController _authController;
        private readonly string _uniqueDatabaseName;
        
        public IntegrationTestBase()
        {
            Env.TraversePath().Load(); // Load environment variables from the .env file
            DbConnectionString = Environment.GetEnvironmentVariable("INTEGRATIONTEST_CONNECTIONSTRING");
            JwtTokenTime = Environment.GetEnvironmentVariable("JWT_TOKEN_TIME");
            JwtValidIssuer = Environment.GetEnvironmentVariable("JWT_VALID_ISSUER");
            JwtValidAudience = Environment.GetEnvironmentVariable("JWT_VALID_AUDIENCE");
            JwtIssuerSigningKey = Environment.GetEnvironmentVariable("JWT_ISSUER_SIGNING_KEY");
            PicturesPathContainer = Environment.GetEnvironmentVariable("PICTURES_PATH_CONTAINER") ?? "default/pictures/path";

            _uniqueDatabaseName = $"TestDb_{Guid.NewGuid()}";
            var completeConnectionString = $"{DbConnectionString};Database={_uniqueDatabaseName}";
            
            var services = new ServiceCollection();

            services.AddLogging(); // Add logging service

            services.AddDbContext<WikiDbContext>(options =>
            {
                options.UseSqlServer(completeConnectionString);
            });

            services.AddIdentity<ApplicationUser, IdentityRole>()
                    .AddEntityFrameworkStores<WikiDbContext>()
                    .AddDefaultTokenProviders();

            ServiceProvider = services.BuildServiceProvider();
            DbContext = ServiceProvider.GetRequiredService<WikiDbContext>();
            DbContext.Database.EnsureCreated();
            
            _authController = CreateAuthController();

            // Ensure roles exist
            Task.Run(async () => await EnsureRolesAsync()).Wait(); // Wait for roles creation to finish
        }

        private async Task EnsureRolesAsync()
        {
            using var scope = ServiceProvider.CreateScope();
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
        
        protected void ResetDatabase()
        {
            DbContext.Database.EnsureDeleted();
            DbContext.Database.EnsureCreated();
            // Task.Run(async () => await EnsureRolesAsync()).Wait(); 
        }

        public void Dispose()
        {
            DbContext?.Database.EnsureDeleted();
            DbContext.Dispose();
            ServiceProvider?.Dispose();
        }
        
        protected static string GetRandomizedString(string baseString)
        {
            var random = new Random();
            return $"{baseString}{random.Next(1, 99999)}";
        }
        
        protected AuthController CreateAuthController()
        {
            var tokenService = new TokenServices();
            var userManager = ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            return new AuthController(new AuthService(userManager, tokenService));
        }
        
        protected UsersController CreateUserController()
        {
            var userManager = ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            return new UsersController(userManager, DbContext);
        }
        
        protected UserProfileController CreateUserProfileController()
        {
            var userProfileRepository = new UserProfileRepository(DbContext);
            return new UserProfileController(userProfileRepository);
        }
        
        protected async Task EnsureUserRoleExistsAsync()
        {
            var roleManager = ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userRoleExists = await roleManager.RoleExistsAsync("User");
            var adminRoleExists = await roleManager.RoleExistsAsync("Admin");
            if (!userRoleExists)
            {
                await roleManager.CreateAsync(new IdentityRole("User"));
            }
            if (!adminRoleExists)
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }
        }

        protected async Task<ApplicationUser> CreateTestUserAsync(string email, string username, string password)
        {
            var testUsername = username;

            var testUserProfile = new UserProfile()
            {
                UserName = testUsername,
                DisplayName = "Peter Griffin",
                ProfilePicture = "tester_base.gif"
            };
            // Save UserProfile to the database
            DbContext.UserProfiles.Add(testUserProfile);

            await DbContext.SaveChangesAsync();

            var testUser = new ApplicationUser
            {
                UserName = testUsername,
                Email = email,
                ProfileId = testUserProfile.Id
            };
            var userManager = ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var userCreated = await userManager.CreateAsync(testUser, password);
            if (userCreated.Succeeded)
            {
                await userManager.AddToRoleAsync(testUser, "User");
                // Set the UserId of adminProfile
                testUserProfile.UserId = testUser.Id;

                // Update UserProfile in the database
                DbContext.UserProfiles.Update(testUserProfile);
                await DbContext.SaveChangesAsync();
            }

            return testUser;
        }
        protected async Task<ApplicationUser> CreateAdminUserAsync(string email, string username, string password)
        {
            var testUserProfile = new UserProfile()
            {
                UserName = username,
                DisplayName = "Admin User",
                ProfilePicture = "admin_base.gif"
            };

            DbContext.UserProfiles.Add(testUserProfile);
            await DbContext.SaveChangesAsync();

            var adminUser = new ApplicationUser
            {
                UserName = username,
                Email = email,
                ProfileId = testUserProfile.Id
            };
            
            var userManager = ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var userCreated = await userManager.CreateAsync(adminUser, password);
            if (userCreated.Succeeded)
            {
                await userManager.AddToRoleAsync(adminUser, "Admin");
                testUserProfile.UserId = adminUser.Id;

                DbContext.UserProfiles.Update(testUserProfile);
                await DbContext.SaveChangesAsync();
            }
            return adminUser;
        }
        
        protected async Task<string> GetValidUserToken(string email, string username, string password)
        {
            // Login the user
            var loginRequest = new AuthRequest(email, password);
            var loginResult = await _authController.Authenticate(loginRequest);
            if (!(loginResult.Result is OkObjectResult okResult))
            {
                throw new InvalidOperationException("User login failed.");
            }

            var authResponse = okResult.Value as AuthResponse;
            return authResponse?.Token;
        }
        
    }
}
