using StaySync.Domain.Entities;

namespace StaySync.Application.Interfaces.Repositories;

/// <summary>
/// Reservation repository contract.
/// </summary>
public interface IReservationRepository
{
    Task<IEnumerable<Reservation>> GetAllAsync();

    Task<Reservation?> GetByIdAsync(Guid id);

    Task AddAsync(Reservation reservation);

    Task UpdateAsync(Reservation reservation);

    Task<bool> HasOverlappingReservationAsync(
        Guid roomId,
        DateTime checkIn,
        DateTime checkOut);

    Task SaveChangesAsync();
}