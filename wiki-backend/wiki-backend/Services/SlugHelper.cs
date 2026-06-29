using System.Text.RegularExpressions;

namespace wiki_backend.Services;

public static class SlugHelper
{
    public static string Slugify(string? title)
    {
        if (string.IsNullOrWhiteSpace(title))
            return "untitled";
        var slug = title.Trim().ToLowerInvariant();
        slug = slug.Replace(' ', '-');
        slug = Regex.Replace(slug, @"[^a-z0-9\-]", "");
        slug = Regex.Replace(slug, @"-+", "-").Trim('-');
        return string.IsNullOrEmpty(slug) ? "untitled" : slug;
    }

    public static async Task<string> GenerateUniqueSlugAsync(string? title, Func<string, Task<bool>> existsAsync)
    {
        var baseSlug = Slugify(title);
        var slug = baseSlug;
        var suffix = 1;
        while (await existsAsync(slug))
        {
            slug = $"{baseSlug}-{suffix}";
            suffix++;
        }
        return slug;
    }

    public static string GenerateUniqueSlug(string? title, Func<string, bool> exists)
    {
        var baseSlug = Slugify(title);
        var slug = baseSlug;
        var suffix = 1;
        while (exists(slug))
        {
            slug = $"{baseSlug}-{suffix}";
            suffix++;
        }
        return slug;
    }
}
