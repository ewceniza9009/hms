using System.ComponentModel.DataAnnotations;

namespace GuestManagement.API.Entities;

public class GuestProfile
{
    [Key]
    public Guid GuestId { get; set; }

    [Required]
    public Guid AuthUserId { get; set; } // This will link to the User in the Identity Service

    [Required]
    [StringLength(100)]
    public required string FirstName { get; set; }

    [Required]
    [StringLength(100)]
    public required string LastName { get; set; }

    [StringLength(20)]
    public string? PhoneNumber { get; set; }

    public DateTime? DateOfBirth { get; set; }

    [StringLength(500)]
    public string? Address { get; set; }
}