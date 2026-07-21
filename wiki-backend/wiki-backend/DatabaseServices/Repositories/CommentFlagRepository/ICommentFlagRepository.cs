using wiki_backend.Models;

namespace wiki_backend.DatabaseServices.Repositories;

public record FlaggedCommentItem
{
    public CommentFlag Flag { get; init; } = null!;
    public string? CommentContent { get; init; }
    public string? CommentAuthorName { get; init; }
    public Guid? CommentAuthorProfileId { get; init; }
}

public interface ICommentFlagRepository
{
    Task AddFlagAsync(CommentFlag flag);
    Task<List<FlaggedCommentItem>> GetUnresolvedFlagsAsync();
    Task<int> GetUnresolvedCountAsync();
    Task<CommentFlag?> GetFlagByIdAsync(Guid flagId);
    Task ResolveFlagAsync(Guid flagId, Guid resolvedByUserProfileId);
    Task ResolveAllFlagsForCommentAsync(Guid commentId);
    Task DeleteFlagAsync(Guid flagId);
    Task DeleteFlagsForCommentAsync(Guid commentId);
}
