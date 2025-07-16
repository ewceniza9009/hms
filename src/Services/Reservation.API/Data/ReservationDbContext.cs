using Microsoft.EntityFrameworkCore;
// 1. We create an alias named 'ReservationEntity' that points directly to our class.
// This solves the name conflict.
using ReservationEntity = Reservation.API.Entities.Reservation;

namespace Reservation.API.Data;

public class ReservationDbContext : DbContext
{
    public ReservationDbContext(DbContextOptions<ReservationDbContext> options) : base(options)
    {
    }

    // 2. We now use the 'ReservationEntity' alias instead of just 'Reservation'.
    public DbSet<ReservationEntity> Reservations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // 3. We also use the alias here.
        modelBuilder.Entity<ReservationEntity>()
            .Property(r => r.TotalPrice)
            .HasPrecision(18, 2);
    }
}