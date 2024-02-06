using System.ComponentModel.DataAnnotations;

namespace wiki_backend.Contracts;

public record RegistrationRequest([Required]string Email,
    [Required]string Username,
    [Required]string Password);