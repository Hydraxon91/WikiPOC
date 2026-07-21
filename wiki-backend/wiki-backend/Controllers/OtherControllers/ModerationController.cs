using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using wiki_backend.DatabaseServices.Repositories;
using wiki_backend.DatabaseServices.Repositories.ForumRepositories;
using wiki_backend.Identity;
using wiki_backend.Services;

namespace wiki_backend.Controllers.OtherControllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/[controller]")]
public class ModerationController : ControllerBase
{
    private readonly ICommentFlagRepository _flagRepository;
    private readonly IForumCommentRepository _forumCommentRepository;
    private readonly IUserCommentRepository _userCommentRepository;
    private readonly IUserProfileRepository _userProfileRepository;
    private readonly IUserAuthorizationService _authorizationService;

    public ModerationController(
        ICommentFlagRepository flagRepository,
        IForumCommentRepository forumCommentRepository,
        IUserCommentRepository userCommentRepository,
        IUserProfileRepository userProfileRepository,
        IUserAuthorizationService authorizationService)
    {
        _flagRepository = flagRepository;
        _forumCommentRepository = forumCommentRepository;
        _userCommentRepository = userCommentRepository;
        _userProfileRepository = userProfileRepository;
        _authorizationService = authorizationService;
    }

    [Authorize(Policy = IdentityData.ModeratorPolicyName)]
    [HttpGet("flagged-comments")]
    public async Task<IActionResult> GetFlaggedComments()
    {
        var flags = await _flagRepository.GetUnresolvedFlagsAsync();
        return Ok(flags);
    }

    [Authorize(Policy = IdentityData.ModeratorPolicyName)]
    [HttpGet("flagged-comments/count")]
    public async Task<IActionResult> GetFlaggedCommentsCount()
    {
        var count = await _flagRepository.GetUnresolvedCountAsync();
        return Ok(new { count });
    }

    [Authorize(Policy = IdentityData.ModeratorPolicyName)]
    [HttpPut("flagged-comments/{flagId:guid}/resolve")]
    public async Task<IActionResult> ResolveFlag(Guid flagId)
    {
        var userName = User.FindFirstValue(ClaimTypes.Name);
        if (string.IsNullOrEmpty(userName))
            return Unauthorized();

        var userProfile = await _userProfileRepository.GetByUsernameAsync(userName);
        if (userProfile == null)
            return Unauthorized();

        var flag = await _flagRepository.GetFlagByIdAsync(flagId);
        if (flag == null)
            return NotFound(new { Message = "Flag not found" });

        await _flagRepository.ResolveFlagAsync(flagId, userProfile.Id);
        return Ok(new { Message = "Flag resolved" });
    }

    [Authorize(Policy = IdentityData.ModeratorPolicyName)]
    [HttpDelete("flagged-comments/{flagId:guid}/delete-comment")]
    public async Task<IActionResult> DeleteFlaggedComment(Guid flagId)
    {
        var userName = User.FindFirstValue(ClaimTypes.Name);
        if (string.IsNullOrEmpty(userName))
            return Unauthorized();

        var flag = await _flagRepository.GetFlagByIdAsync(flagId);
        if (flag == null)
            return NotFound(new { Message = "Flag not found" });

        if (flag.CommentType == "Forum")
        {
            var comment = await _forumCommentRepository.GetByIdAsync(flag.CommentId);
            if (comment == null)
                return NotFound(new { Message = "Forum comment not found" });

            if (!await IsAuthorizedToModerate(userName, comment.UserProfile?.UserName))
                return Unauthorized(new { Message = "Not authorized to delete this comment" });

            await _forumCommentRepository.DeleteAsync(flag.CommentId);
        }
        else if (flag.CommentType == "Wiki")
        {
            var comment = await _userCommentRepository.GetByIdAsync(flag.CommentId);
            if (comment == null)
                return NotFound(new { Message = "Wiki comment not found" });

            if (!await IsAuthorizedToModerate(userName, comment.UserProfile?.UserName))
                return Unauthorized(new { Message = "Not authorized to delete this comment" });

            await _userCommentRepository.DeleteAsync(flag.CommentId);
        }
        else
        {
            return BadRequest(new { Message = "Unknown comment type" });
        }

        await _flagRepository.ResolveAllFlagsForCommentAsync(flag.CommentId);
        return Ok(new { Message = "Comment deleted and flags resolved" });
    }

    [Authorize(Policy = IdentityData.AdminUserPolicyName)]
    [HttpDelete("flagged-comments/{flagId:guid}")]
    public async Task<IActionResult> DeleteFlag(Guid flagId)
    {
        await _flagRepository.DeleteFlagAsync(flagId);
        return Ok(new { Message = "Flag deleted" });
    }

    private async Task<bool> IsAuthorizedToModerate(string? userName, string? commentAuthorName)
    {
        return userName == commentAuthorName || await _authorizationService.IsUserModerator(userName);
    }
}
