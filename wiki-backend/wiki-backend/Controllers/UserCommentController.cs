using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using wiki_backend.DatabaseServices.Repositories;
using wiki_backend.Identity;
using wiki_backend.Models;

namespace wiki_backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserCommentController : ControllerBase
{
    private readonly IUserCommentRepository _commentRepository;
    private readonly UserManager<ApplicationUser> _userManager;

    public UserCommentController(IUserCommentRepository commentRepository, UserManager<ApplicationUser> userManager)
    {
        _commentRepository = commentRepository;
        _userManager = userManager;
    }

    [HttpGet("GetById/{id:int}")]
    public async Task<ActionResult<UserComment>> GetComment(int id)
    {
        var comment = await _commentRepository.GetByIdAsync(id);

        if (comment == null)
        {
            return NotFound(new { Message = "Comment not found" });
        }

        return Ok(comment);
    }
    
    [Authorize(Roles = "Admin, User")]
    [HttpPost("comment")]
    public async Task<ActionResult<UserComment>> PostComment([FromBody] UserComment comment)
    {
        await _commentRepository.AddAsync(comment);

        return CreatedAtAction(nameof(PostComment), new { id = comment.Id }, comment);
    }
    
    [HttpPut("comment/{id:int}")]
    public async Task<IActionResult> EditComment(int id, [FromBody] string updatedContent)
    {
        var userId = GetUserIdFromRequest();

        var existingComment = await _commentRepository.GetByIdAsync(id);
        
        if (existingComment == null)
        {
            return NotFound(new { Message = "Comment not found" });
        }
        
        if (await IsAuthorizedToDeleteComment(userId, existingComment))
        {
            await _commentRepository.UpdateAsync(id, updatedContent);
            return Ok(new { Message = "Comment edited successfully" });
        }

        return Unauthorized(new { Message = "Unauthorized to update this comment" });
    }
    
    [HttpDelete("comment/{id:int}")]
    public async Task<IActionResult> DeleteComment(int id)
    {
        var userId = GetUserIdFromRequest();
        var existingComment = await _commentRepository.GetByIdAsync(id);
        
        if (existingComment == null)
        {
            return NotFound(new { Message = "Comment not found" });
        }

        if (await IsAuthorizedToDeleteComment(userId, existingComment))
        {
            await _commentRepository.DeleteAsync(id);
            return Ok(new { Message = "Comment deleted successfully" });
        }

        return Unauthorized(new { Message = "Unauthorized to delete this comment" });
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
    private async Task<bool> IsAuthorizedToDeleteComment(string userId, UserComment comment)
    {
        // Check if the user is the author of the comment or is an admin
        return userId == comment.UserProfile.UserName || await IsUserAdmin(userId);
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