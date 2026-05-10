using StaySync.Domain.Entities;

namespace StaySync.Application.Interfaces.Services;

/// <summary>
/// Hotel service contract.
/// </summary>
public interface IHotelService
{
    Task<IEnumerable<Hotel>> GetAllAsync();

    Task<Hotel?> GetByIdAsync(Guid id);

    Task<Hotel> CreateAsync(Hotel hotel);

    Task UpdateAsync(Hotel hotel);

    Task DeleteAsync(Guid id);
}