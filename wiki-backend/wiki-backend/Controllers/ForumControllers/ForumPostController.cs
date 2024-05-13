using System.IdentityModel.Tokens.Jwt;
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
    public async Task<ActionResult<ForumPost>> AddForumPost([FromBody] ForumPost forumPost)
    {
        await _forumPostRepository.AddForumPostAsync(forumPost);
        return CreatedAtAction(nameof(GetForumPostById), new { id = forumPost.Id }, forumPost);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateForumPost(Guid id, [FromBody] ForumPost forumPost)
    {
        var userId = GetUserIdFromRequest();
        if (id != forumPost.Id)
        {
            return BadRequest();
        }
        if (await IsAuthorizedToModifyPost(userId, forumPost))
        {
            await _forumPostRepository.UpdateForumPostAsync(forumPost);
            return Ok(new { Message = "Forum Post edited successfully" });
        }
        return Unauthorized(new { Message = "Unauthorized to update this comment" });
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteForumPost(Guid id)
    {
        var userId = GetUserIdFromRequest();
        var existingPost = await _forumPostRepository.GetForumPostByIdAsync(id);
        
        if (await IsAuthorizedToModifyPost(userId, existingPost))
        {
            await _forumPostRepository.UpdateForumPostAsync(existingPost);
            return Ok(new { Message = "Forum Post edited successfully" });
        }

        return Unauthorized(new { Message = "Unauthorized to delete this Post" });
    }
    
    private string GetUserIdFromRequest()
    {
        // Retrieve the user ID from the claims in the current user's identity
        // Extract token from request headers
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
        // Check if the user is the author of the comment or is an admin
        return userId == post.User.UserName || await IsUserAdmin(userId);
    }
    
    private async Task<bool> IsUserAdmin(string userId)
    {
        // Implement logic to check if the user has admin privileges
        // This might involve checking the user's roles or other criteria
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
        {
            // Handle the case where the user is not found
            return false;
        }
        return await _userManager.IsInRoleAsync(user, "Admin");
    }
}