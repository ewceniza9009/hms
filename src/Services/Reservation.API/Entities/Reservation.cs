using System.ComponentModel.DataAnnotations;

namespace Reservation.API.Entities;

public class Reservation
{
    [Key]
    public Guid ReservationId { get; set; }

    [Required]
    public Guid GuestId { get; set; } // From GuestManagement service

    [Required]
    public string RoomTypeId { get; set; } = string.Empty; // From RoomManagement service

    public string? AssignedRoomId { get; set; } // From RoomManagement service

    [Required]
    public DateTime CheckInDate { get; set; }

    [Required]
    public DateTime CheckOutDate { get; set; }

    public int NumberOfGuests { get; set; } = 1;

    public decimal TotalPrice { get; set; }

    [Required]
    public required string Status { get; set; } // e.g., 'Confirmed', 'CheckedIn', 'Cancelled'

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}