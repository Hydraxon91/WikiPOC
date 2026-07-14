using System.Text.RegularExpressions;

namespace wiki_backend.Identity;

public static partial class BotPatterns
{
    public const string ScraperUserAgentPattern =
        "Discordbot|Twitterbot|facebookexternalhit|Slackbot|LinkedInBot|WhatsApp|TelegramBot|Pinterest|redditbot|Iframely";

    public static Regex ScraperUserAgentRegex { get; } = BuildScraperRegex();

    private static Regex BuildScraperRegex()
    {
        try
        {
            return GenerateScraperRegex();
        }
        catch
        {
            return new Regex(ScraperUserAgentPattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
        }
    }

    [GeneratedRegex(ScraperUserAgentPattern, RegexOptions.Compiled | RegexOptions.IgnoreCase)]
    private static partial Regex GenerateScraperRegex();
}
