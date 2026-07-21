using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using wiki_backend.DatabaseServices.Repositories;
using wiki_backend.DatabaseServices.Repositories.ForumRepositories;
using wiki_backend.Models;
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
    private readonly ICommentFlagRepository _flagRepository;
    private readonly IUserProfileRepository _userProfileRepository;
    
    public ForumCommentController(IForumCommentRepository commentRepository, IUserAuthorizationService authorizationService, ICommentFlagRepository flagRepository, IUserProfileRepository userProfileRepository)
    {
        _commentRepository = commentRepository;
        _authorizationService = authorizationService;
        _flagRepository = flagRepository;
        _userProfileRepository = userProfileRepository;
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
            await _flagRepository.DeleteFlagsForCommentAsync(id);
            return Ok(new { Message = "Comment deleted successfully" });
        }

        return Unauthorized(new { Message = "Unauthorized to delete this comment" });
    }
    
    [Authorize]
    [HttpPost("{id:guid}/flag")]
    public async Task<IActionResult> FlagComment(Guid id, [FromBody] string reason)
    {
        var userName = User.FindFirstValue(ClaimTypes.Name);
        if (string.IsNullOrEmpty(userName))
            return Unauthorized(new { Message = "User not authenticated" });

        var existingComment = await _commentRepository.GetByIdAsync(id);
        if (existingComment == null)
            return NotFound(new { Message = "Comment not found" });

        var userProfile = await _userProfileRepository.GetByUsernameAsync(userName);
        if (userProfile == null)
            return Unauthorized(new { Message = "User profile not found" });

        var flag = new CommentFlag
        {
            Id = Guid.NewGuid(),
            CommentId = id,
            CommentType = "Forum",
            FlaggedByUserProfileId = userProfile.Id,
            Reason = reason,
            CreatedAt = DateTime.UtcNow,
            IsResolved = false
        };

        await _flagRepository.AddFlagAsync(flag);
        return Ok(new { Message = "Comment flagged successfully" });
    }
    
    private async Task<bool> IsAuthorizedToModifyComment(string? userName, ForumComment comment)
    {
        return userName == comment.UserProfile?.UserName || await _authorizationService.IsUserAdmin(userName);
    }
}