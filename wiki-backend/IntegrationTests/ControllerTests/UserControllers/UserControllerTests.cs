using System.Net;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using wiki_backend.Controllers;

namespace IntegrationTests.ControllerTests.UserControllers;

[TestFixture]
public class UserControllerTests : IntegrationTestBase
{
    private UsersController _controller;

    [SetUp]
    public async Task SetUp()
    {
        ResetDatabase();
        await EnsureUserRoleExistsAsync();
        await CreateTestUserAsync("test@example.com", "test2_user", "@Testpassword1");
        _controller = CreateUserController();
    }

    [Test]
    public async Task GetUsers_ShouldReturnAllUsers()
    {
        var result = await _controller.GetUsers();

        var okResult = result as OkObjectResult;
        Assert.That(okResult, Is.Not.Null);
        Assert.That(okResult.StatusCode, Is.EqualTo((int)HttpStatusCode.OK));

        var json = JsonSerializer.Serialize(okResult.Value);
        var users = JsonSerializer.Deserialize<List<JsonElement>>(json);
        Assert.That(users, Is.Not.Null);
        Assert.That(users.Count > 0, Is.True);
    }
}
