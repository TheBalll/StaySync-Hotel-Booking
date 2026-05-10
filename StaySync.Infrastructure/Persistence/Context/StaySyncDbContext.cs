using Microsoft.EntityFrameworkCore;
using StaySync.Domain.Entities;

namespace StaySync.Infrastructure.Persistence.Context;

/// <summary>
/// Main database context.
/// </summary>
public class StaySyncDbContext : DbContext
{
    public StaySyncDbContext(DbContextOptions<StaySyncDbContext> options)
        : base(options)
    {
    }

    public DbSet<Hotel> Hotels => Set<Hotel>();

    public DbSet<RoomType> RoomTypes => Set<RoomType>();

    public DbSet<Room> Rooms => Set<Room>();

    public DbSet<Guest> Guests => Set<Guest>();

    public DbSet<Reservation> Reservations => Set<Reservation>();

    public DbSet<Stay> Stays => Set<Stay>();

    public DbSet<AdditionalService> AdditionalServices => Set<AdditionalService>();

    public DbSet<ReservationService> ReservationServices => Set<ReservationService>();

    public DbSet<Payment> Payments => Set<Payment>();

    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(StaySyncDbContext).Assembly);
    }
}