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

    // Тази таблица е за връзката Many-to-Many
    public DbSet<ReservationAdditionalService> ReservationAdditionalServices => Set<ReservationAdditionalService>();

    public DbSet<Payment> Payments => Set<Payment>();
    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // 1. Първо викаме базовия метод
        base.OnModelCreating(modelBuilder);

        // 2. Конфигурираме композитния ключ за Many-to-Many таблицата
        modelBuilder.Entity<ReservationAdditionalService>()
            .HasKey(ras => new { ras.ReservationId, ras.AdditionalServiceId });

        // 3. Зареждаме всички останали конфигурации от папката Configurations (ако имаш такива)
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(StaySyncDbContext).Assembly);
    }
}