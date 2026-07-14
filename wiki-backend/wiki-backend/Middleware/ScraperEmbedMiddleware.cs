using System.Text.RegularExpressions;
using Microsoft.Extensions.Caching.Memory;
using wiki_backend.Controllers;
using wiki_backend.DatabaseServices.Repositories;
using wiki_backend.DatabaseServices.Repositories.ForumRepositories;
using wiki_backend.Identity;

namespace wiki_backend.Middleware;

public partial class ScraperEmbedMiddleware
{
    private readonly RequestDelegate _next;

    [GeneratedRegex(@"^/forum/[^/]+/([^/]+)$", RegexOptions.Compiled | RegexOptions.IgnoreCase)]
    private static partial Regex ForumPostPathRegex();

    public ScraperEmbedMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        if (context.Request.Method is "GET" or "HEAD")
        {
            var ua = context.Request.Headers.UserAgent.ToString();
            if (!string.IsNullOrEmpty(ua) && BotPatterns.ScraperUserAgentRegex.IsMatch(ua))
            {
                var path = context.Request.Path.Value ?? "";

                if (path.StartsWith("/page/", StringComparison.OrdinalIgnoreCase) && path.Length > 6)
                {
                    var slug = path[6..];
                    var cache = context.RequestServices.GetRequiredService<IMemoryCache>();
                    var html = await cache.GetOrCreateAsync($"embed:wiki:{slug}", async entry =>
                    {
                        entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(60);

                        var pageRepo = context.RequestServices.GetRequiredService<IWikiPageRepository>();
                        var page = await pageRepo.GetBySlugAsync(slug);
                        if (page?.WikiPage == null) return null;

                        var title = page.WikiPage.Title ?? "WikiPOC";
                        var description = EmbedController.Truncate(EmbedController.StripHtml(page.WikiPage.Content), 200);

                        var siteSettingsRepo = context.RequestServices.GetRequiredService<ISiteSettingsRepository>();
                        var siteSettings = await siteSettingsRepo.GetAsync();
                        var wikiName = siteSettings?.WikiName ?? "WikiPOC";

                        var scheme = context.Request.Headers["X-Forwarded-Proto"].FirstOrDefault() ?? "https";
                        var articleImage = page.Images?.FirstOrDefault()?.FileName;
                        string imageUrl;
                        if (!string.IsNullOrEmpty(articleImage))
                        {
                            imageUrl = $"{scheme}://{context.Request.Host}/api/Image/{articleImage}";
                        }
                        else if (!string.IsNullOrEmpty(siteSettings?.Logo) && siteSettings.Logo != "logo/logo_pfp.png")
                        {
                            imageUrl = $"{scheme}://{context.Request.Host}/api/Image/{siteSettings.Logo}";
                        }
                        else
                        {
                            imageUrl = $"{scheme}://{context.Request.Host}/img/logo.png";
                        }

                        var frontendUrl = Environment.GetEnvironmentVariable("FRONTEND_URL");
                        string pageUrl;
                        if (!string.IsNullOrEmpty(frontendUrl))
                            pageUrl = $"{frontendUrl.TrimEnd('/')}/page/{slug}";
                        else
                            pageUrl = $"{scheme}://{context.Request.Host}/page/{slug}";

                        return EmbedController.BuildHtml(title, wikiName, description, imageUrl, pageUrl, ogType: "article");
                    });

                    if (html != null)
                    {
                        context.Response.StatusCode = 200;
                        context.Response.ContentType = "text/html; charset=utf-8";
                        await context.Response.WriteAsync(html);
                        return;
                    }
                }

                var forumMatch = ForumPostPathRegex().Match(path);
                if (forumMatch.Success)
                {
                    var postSlug = forumMatch.Groups[1].Value;
                    var cache = context.RequestServices.GetRequiredService<IMemoryCache>();
                    var html = await cache.GetOrCreateAsync($"embed:forum:{postSlug}", async entry =>
                    {
                        entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(60);

                        var postRepo = context.RequestServices.GetRequiredService<IForumPostRepository>();
                        var post = await postRepo.GetForumPostBySlugAsync(postSlug);
                        if (post == null) return null;

                        var topicRepo = context.RequestServices.GetRequiredService<IForumTopicRepository>();
                        var topic = await topicRepo.GetForumTopicByIdAsync(post.ForumTopicId);
                        var topicSlug = topic?.Slug ?? "topic";

                        var title = post.PostTitle ?? "Forum Post";
                        var description = EmbedController.Truncate(EmbedController.StripHtml(post.Content), 200);

                        var siteSettingsRepo = context.RequestServices.GetRequiredService<ISiteSettingsRepository>();
                        var siteSettings = await siteSettingsRepo.GetAsync();
                        var wikiName = siteSettings?.WikiName ?? "WikiPOC";

                        var scheme = context.Request.Headers["X-Forwarded-Proto"].FirstOrDefault() ?? "https";

                        string logoUrl;
                        if (!string.IsNullOrEmpty(siteSettings?.Logo) && siteSettings.Logo != "logo/logo_pfp.png")
                            logoUrl = $"{scheme}://{context.Request.Host}/api/Image/{siteSettings.Logo}";
                        else
                            logoUrl = $"{scheme}://{context.Request.Host}/img/logo.png";

                        var frontendUrl = Environment.GetEnvironmentVariable("FRONTEND_URL");
                        string pageUrl;
                        if (!string.IsNullOrEmpty(frontendUrl))
                            pageUrl = $"{frontendUrl.TrimEnd('/')}/forum/{topicSlug}/{postSlug}";
                        else
                            pageUrl = $"{scheme}://{context.Request.Host}/forum/{topicSlug}/{postSlug}";

                        return EmbedController.BuildHtml(title, wikiName, description, logoUrl, pageUrl);
                    });

                    if (html != null)
                    {
                        context.Response.StatusCode = 200;
                        context.Response.ContentType = "text/html; charset=utf-8";
                        await context.Response.WriteAsync(html);
                        return;
                    }
                }
            }
        }

        await _next(context);
    }
}
