using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace wiki_backend.DatabaseServices;

public class WikiDbContextDesignTimeFactory : IDesignTimeDbContextFactory<WikiDbContext>
{
    public WikiDbContext CreateDbContext(string[] args)
    {
        var connectionString = Environment.GetEnvironmentVariable("ASPNETCORE_CONNECTIONSTRING")
            ?? "Server=localhost,1433;Database=WikiDb;User=sa;Password=DummyPassword123!;TrustServerCertificate=True";
        var optionsBuilder = new DbContextOptionsBuilder<WikiDbContext>();
        optionsBuilder.UseSqlServer(connectionString);
        return new WikiDbContext(optionsBuilder.Options);
    }
}
