using StaySync.Domain.Entities;

namespace StaySync.Application.Interfaces.Repositories;

/// <summary>
/// Hotel repository contract.
/// </summary>
public interface IHotelRepository
{
    Task<IEnumerable<Hotel>> GetAllAsync();

    Task<Hotel?> GetByIdAsync(Guid id);

    Task AddAsync(Hotel hotel);

    Task UpdateAsync(Hotel hotel);

    Task SaveChangesAsync();
}