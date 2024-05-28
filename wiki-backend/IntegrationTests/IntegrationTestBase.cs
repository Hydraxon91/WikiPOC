using System;
using IntegrationTests.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using wiki_backend.DatabaseServices;
using wiki_backend.Models;
using DotNetEnv;

namespace IntegrationTests
{
    public class IntegrationTestBase : IDisposable
    {
        protected readonly ServiceProvider ServiceProvider;
        protected readonly WikiDbContext DbContext;
        
        public IntegrationTestBase()
        {
            Env.Load();
            
            var services = new ServiceCollection();
            services.AddDbContext<WikiDbContext>(options =>
                options.UseSqlServer(GetConnectionString())); // Use the method to get connection string
            
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddUserStore<TestUserStore>() // Use the test user store
                .AddDefaultTokenProviders(); // Add token provider
            
            ServiceProvider = services.BuildServiceProvider();
            DbContext = ServiceProvider.GetRequiredService<WikiDbContext>();
            DbContext.Database.EnsureCreated();
        }

        private static string GetConnectionString()
        {
            // Retrieve the connection string from environment variables or configuration
            return Environment.GetEnvironmentVariable("INTEGRATIONTEST_CONNECTIONSTRING");
        }

        public void Dispose()
        {
            DbContext.Database.EnsureDeleted();
            DbContext.Dispose();
        }
    }
}