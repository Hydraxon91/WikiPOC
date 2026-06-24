using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using wiki_backend.DatabaseServices.Repositories.ForumRepositories;
using wiki_backend.Models;
using wiki_backend.Models.ForumModels;

namespace wiki_backend.Controllers.ForumControllers;

[Route("api/[controller]")]
[ApiController]
public class ForumPostController : ControllerBase
{
    private readonly IForumPostRepository _forumPostRepository;
    private readonly UserManager<ApplicationUser> _userManager;

    public ForumPostController(IForumPostRepository forumPostRepository, UserManager<ApplicationUser> userManager)
    {
        _forumPostRepository = forumPostRepository;
        _userManager = userManager;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<string>>> GetForumPostTitles()
    {
        var forumPosts = await _forumPostRepository.GetAllForumPostTitlesAsync();
        return Ok(forumPosts);
    }
    
    
    [HttpGet("{slug}")]
    public async Task<ActionResult<ForumPost>> GetForumPostBySlug(string slug)
    {
        var forumPost = await _forumPostRepository.GetForumPostBySlugAsync(slug);
        if (forumPost == null)
        {
            return NotFound();
        }
        return Ok(forumPost);
    }
    
    [HttpPost("postTopic")]
    [Authorize]
    public async Task<ActionResult<ForumPost>> AddForumPost([FromForm] ForumPostForm forumPostForm)
    {
        var forumPostId = Guid.NewGuid();
        
        var forumPost = new ForumPost
        {
            Id = forumPostId,
            PostTitle = forumPostForm.PostTitle,
            PostDate = forumPostForm.PostDate,
            Content = forumPostForm.Content,
            ForumTopicId = Guid.Parse(forumPostForm.ForumTopicId),
            UserId = Guid.Parse(forumPostForm.UserId), 
            UserName = forumPostForm.UserName,
        };
        await _forumPostRepository.AddForumPostAsync(forumPost);
        return CreatedAtAction(nameof(GetForumPostBySlug), new { slug = forumPost.Slug }, forumPost);
    }
    
    [Authorize]
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateForumPost(Guid id, [FromBody] ForumPost forumPost)
    {
        var userName = User.FindFirstValue(ClaimTypes.Name);
        if (id != forumPost.Id)
        {
            return BadRequest();
        }

        var existingPost = await _forumPostRepository.GetForumPostByIdAsync(id);
        if (existingPost == null)
        {
            return NotFound();
        }

        if (await IsAuthorizedToModifyPost(userName, existingPost))
        {
            await _forumPostRepository.UpdateForumPostAsync(existingPost, forumPost);
            return Ok(new { Message = "Forum Post edited successfully" });
        }

        return Unauthorized(new { Message = "Unauthorized to update this post" });
    }
    
    [Authorize]
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteForumPost(Guid id)
    {
        var userName = User.FindFirstValue(ClaimTypes.Name);
        var existingPost = await _forumPostRepository.GetForumPostByIdAsync(id);
        if (existingPost == null)
        {
            return NotFound();
        }

        if (await IsAuthorizedToModifyPost(userName, existingPost))
        {
            await _forumPostRepository.DeleteForumPostAsync(id);
            return Ok(new { Message = "Forum Post deleted successfully" });
        }

        return Unauthorized(new { Message = "Unauthorized to delete this post" });
    }
    
    private async Task<bool> IsAuthorizedToModifyPost(string? userName, ForumPost post)
    {
        return userName == post.UserName || await IsUserAdmin(userName);
    }
    
    private async Task<bool> IsUserAdmin(string? userName)
    {
        if (string.IsNullOrEmpty(userName))
            return false;
        var user = await _userManager.FindByNameAsync(userName);
        return user != null && await _userManager.IsInRoleAsync(user, "Admin");
    }
}