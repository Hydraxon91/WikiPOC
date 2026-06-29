using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace wiki_backend.DatabaseServices;

public class WikiDbContextDesignTimeFactory : IDesignTimeDbContextFactory<WikiDbContext>
{
    public WikiDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<WikiDbContext>();
        optionsBuilder.UseSqlServer("Server=localhost,1433;Database=WikiDb;User=sa;Password=DummyPassword123!;TrustServerCertificate=True");
        return new WikiDbContext(optionsBuilder.Options);
    }
}
