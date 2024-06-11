using System.IdentityModel.Tokens.Jwt;
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
    [Authorize(Roles = "Admin, User")]
    public async Task<ActionResult<ForumPost>> AddForumPost([FromForm] ForumPostForm forumPostForm)
    {
        var forumPostId = new Guid();
        
        var forumPost = new ForumPost
        {
            Id = forumPostId,
            PostTitle = forumPostForm.PostTitle,
            PostDate = forumPostForm.PostDate,
            Content = forumPostForm.Content,
            ForumTopicId = Guid.Parse(forumPostForm.ForumTopicId), // Convert string to Guid
            UserId = Guid.Parse(forumPostForm.UserId), 
            UserName = forumPostForm.UserName,
        };
        await _forumPostRepository.AddForumPostAsync(forumPost);
        return CreatedAtAction(nameof(GetForumPostBySlug), new { slug = forumPost.Slug }, forumPost);
    }
    
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateForumPost(Guid id, [FromBody] ForumPost forumPost)
    {
        var userId = GetUserIdFromRequest();
        if (id != forumPost.Id)
        {
            return BadRequest();
        }

        var existingPost = await _forumPostRepository.GetForumPostByIdAsync(id);
        if (existingPost == null)
        {
            return NotFound();
        }

        if (await IsAuthorizedToModifyPost(userId, existingPost))
        {
            await _forumPostRepository.UpdateForumPostAsync(existingPost, forumPost);
            return Ok(new { Message = "Forum Post edited successfully" });
        }

        return Unauthorized(new { Message = "Unauthorized to update this post" });
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteForumPost(Guid id)
    {
        var userId = GetUserIdFromRequest();
        var existingPost = await _forumPostRepository.GetForumPostByIdAsync(id);
        if (existingPost == null)
        {
            return NotFound();
        }

        if (await IsAuthorizedToModifyPost(userId, existingPost))
        {
            await _forumPostRepository.DeleteForumPostAsync(id);
            return Ok(new { Message = "Forum Post deleted successfully" });
        }

        return Unauthorized(new { Message = "Unauthorized to delete this post" });
    }
    
    private string GetUserIdFromRequest()
    {
        var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
        var handler = new JwtSecurityTokenHandler();
        var jsonToken = handler.ReadToken(token) as JwtSecurityToken;
        var nameClaim = jsonToken.Claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name");
        
        if (nameClaim != null)
        {
            return nameClaim.Value;
        }
        
        // If the user ID is not found in claims, handle it accordingly (throw an exception, return null, etc.)
        // This depends on how your application handles authentication errors
        throw new InvalidOperationException("User ID not found in claims.");
    }
    private async Task<bool> IsAuthorizedToModifyPost(string userId, ForumPost post)
    {
        return userId == post.UserName|| await IsUserAdmin(userId);
    }
    
    private async Task<bool> IsUserAdmin(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
        {
            return false;
        }
        return await _userManager.IsInRoleAsync(user, "Admin");
    }
}