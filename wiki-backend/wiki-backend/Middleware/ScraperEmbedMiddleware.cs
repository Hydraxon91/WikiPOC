using System.Text.RegularExpressions;
using wiki_backend.Identity;

namespace wiki_backend.Middleware;

public partial class ScraperEmbedMiddleware
{
    private readonly RequestDelegate _next;
    private static readonly Regex ScraperUA = BotPatterns.ScraperUserAgentRegex;
    private static readonly Regex ForumPostPathPattern = ForumPostRegex();

    public ScraperEmbedMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        if (context.Request.Method is "GET" or "HEAD")
        {
            var ua = context.Request.Headers.UserAgent.ToString();
            if (!string.IsNullOrEmpty(ua) && ScraperUA.IsMatch(ua))
            {
                var path = context.Request.Path.Value ?? "";
                var wikiMatch = path.StartsWith("/page/") && path.Length > 6;
                if (wikiMatch)
                {
                    var slug = path[6..];
                    context.Request.Path = $"/embed/wiki/{slug}";
                    await _next(context);
                    return;
                }

                var forumMatch = ForumPostPathPattern.Match(path);
                if (forumMatch.Success)
                {
                    context.Request.Path = $"/embed/forum/{forumMatch.Groups[1].Value}";
                }
            }
        }

        await _next(context);
    }

    [GeneratedRegex(@"^/forum/[^/]+/([^/]+)$", RegexOptions.Compiled)]
    private static partial Regex ForumPostRegex();
}
