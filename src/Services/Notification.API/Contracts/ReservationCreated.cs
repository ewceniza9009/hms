// src/Services/Notification.API/Contracts/ReservationCreated.cs
namespace Notification.API.Contracts;

public record ReservationCreated(
    Guid ReservationId,
    Guid GuestId,
    string RoomTypeId,
    DateTime CheckInDate,
    DateTime CheckOutDate,
    decimal TotalPrice
);