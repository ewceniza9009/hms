using Microsoft.AspNetCore.Identity;
using System;

namespace Identity.API.Entities;

// Inherit from IdentityUser and specify Guid as the key type
public class User : IdentityUser<Guid>
{
    // We can remove properties that are already in IdentityUser:
    // - UserId is now Id (and it's a Guid)
    // - Email is in the base class
    // - PasswordHash is in the base class
    // - We will manage IsActive through Identity's lockout features later.
    // - The UserName property from IdentityUser will be our primary identifier, and we'll set it to the user's email.

    // We keep the properties that are custom to our application
    public required string Role { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public bool IsActive { get; set; } = true;

    // We can also override Id to ensure it's set on creation, although IdentityUser handles this.
    public User()
    {
        Id = Guid.NewGuid();
    }
}