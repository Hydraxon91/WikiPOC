using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using wiki_backend.DatabaseServices;

namespace IntegrationTests;

public class IntegrationTestBase : IDisposable
{
    protected readonly ServiceProvider ServiceProvider;
    protected readonly WikiDbContext DbContext;
    
    public IntegrationTestBase()
    {
        var services = new ServiceCollection();
        services.AddDbContext<WikiDbContext>(options =>
            options.UseSqlServer("YourTestDatabaseConnectionString"));
        
        ServiceProvider = services.BuildServiceProvider();

        DbContext = ServiceProvider.GetRequiredService<WikiDbContext>();
        DbContext.Database.EnsureCreated();
    }

    public void Dispose()
    {
        DbContext.Database.EnsureDeleted();
        DbContext.Dispose();
    }
}