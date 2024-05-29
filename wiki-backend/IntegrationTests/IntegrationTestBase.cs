using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using wiki_backend.DatabaseServices;
using wiki_backend.Models;
using DotNetEnv;
using Microsoft.Extensions.Logging;

namespace IntegrationTests
{
    public class IntegrationTestBase : IDisposable
    {
        protected readonly ServiceProvider ServiceProvider;
        protected readonly WikiDbContext DbContext;

        public IntegrationTestBase()
        {
            Env.TraversePath().Load(); // Load environment variables from the .env file
            var dbConnectionString = Environment.GetEnvironmentVariable("INTEGRATIONTEST_CONNECTIONSTRING");

            var services = new ServiceCollection();

            services.AddLogging(); // Add logging service

            services.AddDbContext<WikiDbContext>(options =>
            {
                options.UseSqlServer(dbConnectionString);
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
            Task.Run(async () => await EnsureRolesAsync()).Wait(); 
        }

        public void Dispose()
        {
            DbContext.Database.EnsureDeleted();
            DbContext.Dispose();
        }
    }
}
