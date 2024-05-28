using System.Runtime.InteropServices;
using wiki_backend.Models;

namespace wiki_backend.DatabaseServices.Repositories;

public interface IParagraphRepository
{
    Task<Paragraph?> GetByIdAsync(Guid id);
    Task<Paragraph?> CreateAsync(Paragraph paragraph);
    Task DeleteAsync(Guid id);
}