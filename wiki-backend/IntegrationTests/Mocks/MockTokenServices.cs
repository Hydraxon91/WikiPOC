using wiki_backend.Models;
using wiki_backend.Services.Authentication;

namespace IntegrationTests.Services;

public class MockTokenServices : ITokenServices
{
    public string CreateToken(ApplicationUser user, string role)
    {
        return "mocktoken";
    }
}