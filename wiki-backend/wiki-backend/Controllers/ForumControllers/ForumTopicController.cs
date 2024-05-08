using Microsoft.AspNetCore.Mvc;
using wiki_backend.DatabaseServices.Repositories.ForumRepositories;
using wiki_backend.Models.ForumModels;

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
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ForumTopic>>> GetForumTopics()
    {
        var forumTopics = await _forumTopicRepository.GetAllForumTopicsAsync();
        return Ok(forumTopics);
    }
}