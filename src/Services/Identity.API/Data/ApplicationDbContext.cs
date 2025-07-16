using Identity.API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Identity.API.Data;

// Inherit from IdentityDbContext to include all the ASP.NET Identity tables
public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    // The Users DbSet is now inherited from the base class, so we don't need to declare it.
    // public DbSet<User> Users { get; set; }
}