using Microsoft.AspNetCore.Mvc;
using wiki_backend.DatabaseServices.Repositories.ForumRepositories;

namespace wiki_backend.Controllers.ForumControllers;

[Route("api/[controller]")]
[ApiController]
public class ForumTopicController : ControllerBase
{
    private readonly IForumTopicRepository _forumTopicRepository;

    public ForumTopicController(IForumTopicRepository forumTopicRepository)
    {
        _forumTopicRepository = forumTopicRepository;
    }
}