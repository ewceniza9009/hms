using System.ComponentModel.DataAnnotations;

namespace Identity.API.DTOs;

public class RegisterDto
{
    [Required]
    [EmailAddress]
    public required string Email { get; set; }

    [Required]
    public required string Password { get; set; }

    [Required]
    public required string Role { get; set; } // e.g., "Guest", "Admin"
}