using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using RoomManagement.API.Data;
using RoomManagement.API.Entities;

namespace RoomManagement.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoomsController : ControllerBase
{
    private readonly RoomDbContext _context;

    // Inject our RoomDbContext to get access to the database collections
    public RoomsController(RoomDbContext context)
    {
        _context = context;
    }

    [HttpGet("types")]
    public async Task<ActionResult<List<RoomType>>> GetRoomTypes()
    {
        // Find(_ => true) is the MongoDB equivalent of "SELECT * FROM ..."
        return await _context.RoomTypes.Find(_ => true).ToListAsync();
    }

    [HttpGet]
    public async Task<ActionResult<List<Room>>> GetRooms()
    {
        return await _context.Rooms.Find(_ => true).ToListAsync();
    }
}