using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using wiki_backend.DatabaseServices.Repositories;
using wiki_backend.DatabaseServices.Repositories.ForumRepositories;

namespace wiki_backend.Controllers;

[ApiController]
[Route("embed")]
public class EmbedController : ControllerBase
{
    private readonly IWikiPageRepository _wikiPageRepo;
    private readonly IForumPostRepository _forumPostRepo;
    private readonly IForumTopicRepository _forumTopicRepo;
    private readonly ISiteSettingsRepository _siteSettingsRepo;

    private string? _frontendUrl;

    public EmbedController(
        IWikiPageRepository wikiPageRepo,
        IForumPostRepository forumPostRepo,
        IForumTopicRepository forumTopicRepo,
        ISiteSettingsRepository siteSettingsRepo)
    {
        _wikiPageRepo = wikiPageRepo;
        _forumPostRepo = forumPostRepo;
        _forumTopicRepo = forumTopicRepo;
        _siteSettingsRepo = siteSettingsRepo;
        _frontendUrl = Environment.GetEnvironmentVariable("FRONTEND_URL");
    }

    [HttpGet("wiki/{slug}")]
    [Produces("text/html")]
    public async Task<IActionResult> WikiEmbed(string slug)
    {
        var page = await _wikiPageRepo.GetBySlugAsync(slug);
        if (page?.WikiPage == null) return NotFound();

        var title = page.WikiPage.Title ?? "WikiPOC";
        var description = Truncate(StripHtml(page.WikiPage.Content), 200);
        var (wikiName, logo) = await GetIdentityAsync();
        var imageUrl = BuildImageUrl(page.Images?.FirstOrDefault()?.FileName ?? logo);
        var pageUrl = BuildPageUrl($"/page/{slug}");

        return Content(BuildHtml(title, wikiName, description, imageUrl, pageUrl, ogType: "article"), "text/html; charset=utf-8");
    }

    [HttpGet("forum/{postSlug}")]
    [Produces("text/html")]
    public async Task<IActionResult> ForumEmbed(string postSlug)
    {
        var post = await _forumPostRepo.GetForumPostBySlugAsync(postSlug);
        if (post == null) return NotFound();

        var topic = await _forumTopicRepo.GetForumTopicByIdAsync(post.ForumTopicId);
        var topicSlug = topic?.Slug ?? "topic";

        var title = post.PostTitle ?? "Forum Post";
        var description = Truncate(StripHtml(post.Content), 200);
        var (wikiName, logo) = await GetIdentityAsync();
        var logoUrl = BuildImageUrl(logo);
        var pageUrl = BuildPageUrl($"/forum/{topicSlug}/{postSlug}");

        return Content(BuildHtml(title, wikiName, description, logoUrl, pageUrl), "text/html; charset=utf-8");
    }

    private async Task<(string wikiName, string logo)> GetIdentityAsync()
    {
        var siteSettings = await _siteSettingsRepo.GetAsync();
        var wikiName = siteSettings?.WikiName ?? "WikiPOC";
        var logo = siteSettings?.Logo ?? "logo_pfp.png";
        return (wikiName, logo);
    }

    private string BuildImageUrl(string filename)
    {
        var scheme = Request.Headers["X-Forwarded-Proto"].FirstOrDefault() ?? "https";
        return $"{scheme}://{Request.Host}/api/Image/{filename}";
    }

    private string BuildPageUrl(string path)
    {
        if (!string.IsNullOrEmpty(_frontendUrl))
            return $"{_frontendUrl.TrimEnd('/')}{path}";

        var scheme = Request.Headers["X-Forwarded-Proto"].FirstOrDefault() ?? "https";
        return $"{scheme}://{Request.Host}{path}";
    }

    private static string StripHtml(string? html)
    {
        if (string.IsNullOrWhiteSpace(html)) return "";
        html = Regex.Replace(html, "</?(p|h[1-6]|li|div|br|tr|td|th|blockquote|pre)[^>]*>", " ");
        html = Regex.Replace(html, "<[^>]+>", "");
        html = Regex.Replace(html, @"\s+", " ");
        html = System.Net.WebUtility.HtmlDecode(html);
        return html.Trim();
    }

    private static string Truncate(string text, int maxLength)
    {
        if (string.IsNullOrEmpty(text) || text.Length <= maxLength)
            return text;
        return text[..(maxLength - 3)] + "...";
    }

    private static string BuildHtml(string title, string wikiName, string description, string imageUrl, string pageUrl, string ogType = "website")
    {
        return $@"<!DOCTYPE html>
<html lang=""en"">
<head>
<meta charset=""utf-8"">
<title>{Escape(title)} — {Escape(wikiName)}</title>
<meta property=""og:title"" content=""{Escape(title)} — {Escape(wikiName)}"">
<meta property=""og:description"" content=""{Escape(description)}"">
<meta property=""og:image"" content=""{Escape(imageUrl)}"">
<meta property=""og:url"" content=""{Escape(pageUrl)}"">
<meta property=""og:type"" content=""{ogType}"">
<meta name=""twitter:card"" content=""summary"">
<meta name=""twitter:title"" content=""{Escape(title)} — {Escape(wikiName)}"">
<meta name=""twitter:description"" content=""{Escape(description)}"">
<meta name=""twitter:image"" content=""{Escape(imageUrl)}"">
<meta http-equiv=""refresh"" content=""0;url={Escape(pageUrl)}"">
</head>
<body>
<p>Redirecting to <a href=""{Escape(pageUrl)}"">{Escape(pageUrl)}</a>...</p>
</body>
</html>";
    }

    private static string Escape(string value) =>
        System.Net.WebUtility.HtmlEncode(value ?? "");
}
