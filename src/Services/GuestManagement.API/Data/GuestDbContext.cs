using GuestManagement.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace GuestManagement.API.Data;

public class GuestDbContext : DbContext
{
    public GuestDbContext(DbContextOptions<GuestDbContext> options) : base(options)
    {
    }

    public DbSet<GuestProfile> GuestProfiles { get; set; }
}