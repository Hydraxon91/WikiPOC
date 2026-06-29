namespace wiki_backend.DatabaseServices.Repositories;

public record WikiPageTitleEntry(string Title, Guid Id, string? Slug = null);
