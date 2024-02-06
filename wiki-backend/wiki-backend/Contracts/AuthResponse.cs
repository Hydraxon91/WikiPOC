namespace wiki_backend.Contracts;

public record AuthResponse(string Email, string UserName, string Token);