// src/Services/Reservation.API/Contracts/ReservationCreated.cs
namespace Reservation.API.Contracts;

public record ReservationCreated(
    Guid ReservationId,
    Guid GuestId,
    string RoomTypeId,
    DateTime CheckInDate,
    DateTime CheckOutDate,
    decimal TotalPrice
);