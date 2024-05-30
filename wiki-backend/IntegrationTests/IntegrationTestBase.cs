using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using wiki_backend.DatabaseServices;
using wiki_backend.Models;
using DotNetEnv;
using IntegrationTests.Services;
using Microsoft.Extensions.Logging;
using wiki_backend.Controllers;
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
        protected readonly string DbConnectionString;
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
            var userManager = ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var authService = new AuthService(userManager, new MockTokenServices());
            return new AuthController(authService);
        }
    }
}
