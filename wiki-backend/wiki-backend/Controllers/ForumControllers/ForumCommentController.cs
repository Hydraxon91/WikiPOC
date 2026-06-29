using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using wiki_backend.DatabaseServices.Repositories.ForumRepositories;
using wiki_backend.Models.ForumModels;
using wiki_backend.Services;

namespace wiki_backend.Controllers.ForumControllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/[controller]")]
public class ForumCommentController : ControllerBase
{
    private readonly IForumCommentRepository _commentRepository;
    private readonly IUserAuthorizationService _authorizationService;
    
    public ForumCommentController(IForumCommentRepository commentRepository, IUserAuthorizationService authorizationService)
    {
        _commentRepository = commentRepository;
        _authorizationService = authorizationService;
    }
    
    [HttpGet("GetById/{id:guid}")]
    public async Task<ActionResult<ForumComment>> GetComment(Guid id)
    {
        var comment = await _commentRepository.GetByIdAsync(id);

        if (comment == null)
        {
            return NotFound(new { Message = "Comment not found" });
        }

        return Ok(comment);
    }
    
    [Authorize]
    [HttpPost("comment")]
    public async Task<ActionResult<ForumComment>> PostComment([FromBody] ForumComment comment)
    {
        await _commentRepository.AddAsync(comment);

        return CreatedAtAction(nameof(PostComment), new { id = comment.Id }, comment);
    }
    
    [Authorize]
    [HttpPut("comment/{id:guid}")]
    public async Task<IActionResult> EditComment(Guid id, [FromBody] string updatedContent)
    {
        var userName = User.FindFirstValue(ClaimTypes.Name);

        var existingComment = await _commentRepository.GetByIdAsync(id);
        
        if (existingComment == null)
        {
            return NotFound(new { Message = "Comment not found" });
        }
        
        if (await IsAuthorizedToModifyComment(userName, existingComment))
        {
            await _commentRepository.UpdateAsync(id, updatedContent);
            return Ok(new { Message = "Comment edited successfully" });
        }

        return Unauthorized(new { Message = "Unauthorized to update this comment" });
    }
    
    [Authorize]
    [HttpDelete("comment/{id:guid}")]
    public async Task<IActionResult> DeleteComment(Guid id)
    {
        var userName = User.FindFirstValue(ClaimTypes.Name);
        var existingComment = await _commentRepository.GetByIdAsync(id);
        
        if (existingComment == null)
        {
            return NotFound(new { Message = "Comment not found" });
        }

        if (await IsAuthorizedToModifyComment(userName, existingComment))
        {
            await _commentRepository.DeleteAsync(id);
            return Ok(new { Message = "Comment deleted successfully" });
        }

        return Unauthorized(new { Message = "Unauthorized to delete this comment" });
    }
    
    private async Task<bool> IsAuthorizedToModifyComment(string? userName, ForumComment comment)
    {
        return userName == comment.UserProfile?.UserName || await _authorizationService.IsUserAdmin(userName);
    }
}