using Microsoft.AspNetCore.Mvc;
using wiki_backend.DatabaseServices.Repositories.ForumRepositories;
using wiki_backend.Models.ForumModels;

namespace wiki_backend.Controllers.ForumControllers;

[Route("api/[controller]")]
[ApiController]
public class ForumPostController : ControllerBase
{
    private readonly IForumPostRepository _forumPostRepository;

    public ForumPostController(IForumPostRepository forumPostRepository)
    {
        _forumPostRepository = forumPostRepository;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<string>>> GetForumPostTitles()
    {
        var forumPosts = await _forumPostRepository.GetAllForumPostTitlesAsync();
        return Ok(forumPosts);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<ForumPost>> GetForumPostById(Guid id)
    {
        var forumPost = await _forumPostRepository.GetForumPostByIdAsync(id);
        if (forumPost == null)
        {
            return NotFound();
        }
        return forumPost;
    }
}