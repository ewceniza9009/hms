// src/Services/Reservation.API/Controllers/ReservationsController.cs
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Reservation.API.Contracts;
using Reservation.API.Data;
using ReservationEntity = Reservation.API.Entities.Reservation;

namespace Reservation.API.Controllers;

public record CreateReservationDto(Guid GuestId, string RoomTypeId, DateTime CheckInDate, DateTime CheckOutDate);

[ApiController]
[Route("api/[controller]")]
public class ReservationsController : ControllerBase
{
    private readonly ReservationDbContext _context;
    private readonly IPublishEndpoint _publishEndpoint;

    // Inject MassTransit's IPublishEndpoint
    public ReservationsController(ReservationDbContext context, IPublishEndpoint publishEndpoint)
    {
        _context = context;
        _publishEndpoint = publishEndpoint;
    }

    [HttpGet("guest/{guestId}")]
    public async Task<ActionResult<List<ReservationEntity>>> GetReservationsForGuest(Guid guestId)
    {
        return await _context.Reservations
            .Where(r => r.GuestId == guestId)
            .ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<ReservationEntity>> CreateReservation(CreateReservationDto reservationDto)
    {
        var reservation = new ReservationEntity
        {
            ReservationId = Guid.NewGuid(),
            GuestId = reservationDto.GuestId,
            RoomTypeId = reservationDto.RoomTypeId,
            CheckInDate = reservationDto.CheckInDate,
            CheckOutDate = reservationDto.CheckOutDate,
            Status = "Confirmed",
            TotalPrice = 9999.00m,
            CreatedAt = DateTime.UtcNow
        };

        _context.Reservations.Add(reservation);
        await _context.SaveChangesAsync();

        // After saving, publish the ReservationCreated event to the message bus
        await _publishEndpoint.Publish(new ReservationCreated(
            reservation.ReservationId,
            reservation.GuestId,
            reservation.RoomTypeId,
            reservation.CheckInDate,
            reservation.CheckOutDate,
            reservation.TotalPrice
        ));

        return CreatedAtAction(nameof(GetReservationsForGuest), new { guestId = reservation.GuestId }, reservation);
    }
}