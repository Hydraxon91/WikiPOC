using System.ComponentModel.DataAnnotations;

namespace wiki_backend.Contracts;

public record AuthRequest(
    [Required] string Email,
    [Required] string Password);