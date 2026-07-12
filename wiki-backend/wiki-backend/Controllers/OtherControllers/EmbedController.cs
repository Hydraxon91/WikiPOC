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
    private readonly ISiteSettingsRepository _siteSettingsRepo;

    public EmbedController(
        IWikiPageRepository wikiPageRepo,
        IForumPostRepository forumPostRepo,
        ISiteSettingsRepository siteSettingsRepo)
    {
        _wikiPageRepo = wikiPageRepo;
        _forumPostRepo = forumPostRepo;
        _siteSettingsRepo = siteSettingsRepo;
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
        var logoUrl = BuildImageUrl(logo);
        var pageUrl = BuildPageUrl($"/page/{slug}");

        return Content(BuildHtml(title, wikiName, description, logoUrl, pageUrl), "text/html; charset=utf-8");
    }

    [HttpGet("forum/{postSlug}")]
    [Produces("text/html")]
    public async Task<IActionResult> ForumEmbed(string postSlug)
    {
        var post = await _forumPostRepo.GetForumPostBySlugAsync(postSlug);
        if (post == null) return NotFound();

        var title = post.PostTitle ?? "Forum Post";
        var description = Truncate(StripHtml(post.Content), 200);
        var (wikiName, logo) = await GetIdentityAsync();
        var logoUrl = BuildImageUrl(logo);
        var pageUrl = BuildPageUrl($"/forum/{post.ForumTopic?.Slug ?? "topic"}/{postSlug}");

        return Content(BuildHtml(title, wikiName, description, logoUrl, pageUrl), "text/html; charset=utf-8");
    }

    private async Task<(string wikiName, string logo)> GetIdentityAsync()
    {
        var siteSettings = await _siteSettingsRepo.GetAsync();
        var wikiName = siteSettings?.WikiName ?? "WikiPOC";
        var logo = siteSettings?.Logo ?? "logo_pfp.png";
        return (wikiName, logo);
    }

    private string BuildImageUrl(string logo)
    {
        return $"{Request.Scheme}://{Request.Host}/api/Image/{logo}";
    }

    private string BuildPageUrl(string path)
    {
        return $"{Request.Scheme}://{Request.Host}{path}";
    }

    private static string StripHtml(string? html)
    {
        if (string.IsNullOrWhiteSpace(html)) return "";
        return Regex.Replace(html, "<[^>]+>", "").Trim();
    }

    private static string Truncate(string text, int maxLength)
    {
        if (string.IsNullOrEmpty(text) || text.Length <= maxLength)
            return text;
        return text[..(maxLength - 3)] + "...";
    }

    private static string BuildHtml(string title, string wikiName, string description, string logoUrl, string pageUrl)
    {
        return $@"<!DOCTYPE html>
<html lang=""en"">
<head>
<meta charset=""utf-8"">
<title>{Escape(title)} — {Escape(wikiName)}</title>
<meta property=""og:title"" content=""{Escape(title)} — {Escape(wikiName)}"">
<meta property=""og:description"" content=""{Escape(description)}"">
<meta property=""og:image"" content=""{Escape(logoUrl)}"">
<meta property=""og:url"" content=""{Escape(pageUrl)}"">
<meta property=""og:type"" content=""website"">
<meta name=""twitter:card"" content=""summary"">
<meta name=""twitter:title"" content=""{Escape(title)} — {Escape(wikiName)}"">
<meta name=""twitter:description"" content=""{Escape(description)}"">
<meta name=""twitter:image"" content=""{Escape(logoUrl)}"">
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
