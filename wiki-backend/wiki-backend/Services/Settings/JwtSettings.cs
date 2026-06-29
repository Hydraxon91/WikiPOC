namespace wiki_backend.Services.Settings;

public class JwtSettings
{
    public string ValidIssuer { get; set; } = string.Empty;
    public string ValidAudience { get; set; } = string.Empty;
    public string IssuerSigningKey { get; set; } = string.Empty;
    public int TokenTime { get; set; } = 30;
}
