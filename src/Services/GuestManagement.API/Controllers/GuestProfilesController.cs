using GuestManagement.API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GuestManagement.API.Controllers;

[Authorize] // <-- ADD THIS ATTRIBUTE
[ApiController]
[Route("api/[controller]")]
public class GuestProfilesController : ControllerBase
{
    private readonly ILogger<GuestProfilesController> _logger;

    public GuestProfilesController(ILogger<GuestProfilesController> logger)
    {
        _logger = logger;
    }

    // This is a simple GET endpoint to retrieve all guest profiles.
    [HttpGet]
    public IActionResult GetAllGuests()
    {
        _logger.LogInformation("Attempting to retrieve all guest profiles.");
        
        // For now, we return a hard-coded list for easy testing.
        // Later, we will fetch this data from our database.
        var testGuests = new List<GuestProfile>
        {
            new GuestProfile
            {
                GuestId = Guid.NewGuid(),
                AuthUserId = Guid.NewGuid(), // Corresponds to a user in the Identity Service
                FirstName = "Juan",
                LastName = "Dela Cruz",
                DateOfBirth = new DateTime(1990, 5, 15),
                Address = "123 Rizal St, Cebu City"
            },
            new GuestProfile
            {
                GuestId = Guid.NewGuid(),
                AuthUserId = Guid.NewGuid(),
                FirstName = "Maria",
                LastName = "Clara",
                DateOfBirth = new DateTime(1992, 8, 22),
                Address = "456 Mabini Ave, Mandaue City"
            }
        };

        return Ok(testGuests);
    }
}