using Microsoft.AspNetCore.Authorization;
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
    
    [HttpPost]
    [Authorize(Roles = "User,Admin")]
    public async Task<ActionResult<ForumPost>> AddForumPost(ForumPost forumPost)
    {
        await _forumPostRepository.AddForumPostAsync(forumPost);
        return CreatedAtAction(nameof(GetForumPostById), new { id = forumPost.Id }, forumPost);
    }
    
    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateForumPost(Guid id, ForumPost forumPost)
    {
        if (!User.IsInRole("Admin"))
        {
            return Forbid();
        }

        if (id != forumPost.Id)
        {
            return BadRequest();
        }
        await _forumPostRepository.UpdateForumPostAsync(forumPost);
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteForumPost(Guid id)
    {
        if (!User.IsInRole("Admin"))
        {
            return Forbid();
        }

        await _forumPostRepository.DeleteForumPostAsync(id);
        return NoContent();
    }
}