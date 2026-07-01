using Microsoft.EntityFrameworkCore;
using wiki_backend.DatabaseServices;
using wiki_backend.Models;

namespace wiki_backend.Services;

public static class ForumStatsHelper
{
    public static async Task SetPostCountsAsync(WikiDbContext context, IEnumerable<Guid> profileIds)
    {
        var ids = profileIds.Distinct().ToList();
        if (ids.Count == 0) return;

        var postCounts = await context.ForumPosts
            .Where(fp => ids.Contains(fp.UserId))
            .GroupBy(fp => fp.UserId)
            .Select(g => new { UserId = g.Key, Count = g.Count() })
            .ToDictionaryAsync(x => x.UserId, x => x.Count);

        var commentCounts = await context.ForumComments
            .Where(fc => ids.Contains(fc.UserProfileId))
            .GroupBy(fc => fc.UserProfileId)
            .Select(g => new { UserProfileId = g.Key, Count = g.Count() })
            .ToDictionaryAsync(x => x.UserProfileId, x => x.Count);

        var trackedProfiles = context.ChangeTracker.Entries<UserProfile>()
            .Select(e => e.Entity)
            .Where(p => ids.Contains(p.Id))
            .ToList();

        foreach (var profile in trackedProfiles)
        {
            postCounts.TryGetValue(profile.Id, out var pCount);
            commentCounts.TryGetValue(profile.Id, out var cCount);
            profile.PostCount = pCount + cCount;
        }
    }
}
