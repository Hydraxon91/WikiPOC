using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using wiki_backend.DatabaseServices.Repositories.ForumRepositories;
using wiki_backend.Identity;
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
    
    [HttpGet("{slug}")]
    public async Task<ActionResult<IEnumerable<ForumTopic>>> GetForumTopicById(string slug)
    {
        var forumTopic = await _forumTopicRepository.GetForumTopicBySlugAsync(slug);
        if (forumTopic == null)
        {
            return NotFound();
        }
        return Ok(forumTopic);
    }
    
    [Authorize(Policy = IdentityData.AdminUserPolicyName)]
    [HttpPost]
    public async Task<ActionResult<ForumTopic>> AddForumTopic([FromBody] ForumTopic forumTopic)
    {
        await _forumTopicRepository.AddForumTopicAsync(forumTopic);
        return CreatedAtAction(nameof(GetForumTopics), new { id = forumTopic.Id }, forumTopic);
    }
    
    [Authorize(Policy = IdentityData.AdminUserPolicyName)]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateForumTopic(Guid id, [FromBody] ForumTopic forumTopic)
    {
        if (id != forumTopic.Id)
        {
            return BadRequest();
        }
        await _forumTopicRepository.UpdateForumTopicAsync(forumTopic);
        return NoContent();
    }
    
    [Authorize(Policy = IdentityData.AdminUserPolicyName)]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteForumTopic(Guid id)
    {
        await _forumTopicRepository.DeleteForumTopicAsync(id);
        return NoContent();
    }
}