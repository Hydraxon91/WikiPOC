using wiki_backend.Models;

namespace wiki_backend.DatabaseServices.Repositories;

public interface IParagraphRepository
{
    Task<Paragraph?> GetByIdAsync(int id);
    Task<Paragraph?> CreateAsync(Paragraph paragraph);
    Task DeleteAsync(int id);
}