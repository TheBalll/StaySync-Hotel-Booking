using StaySync.Application.Interfaces.Repositories;
using StaySync.Application.Interfaces.Services;
using StaySync.Domain.Entities;

namespace StaySync.Application.Services;

/// <summary>
/// Hotel service.
/// </summary>
public class HotelService : IHotelService
{
    private readonly IHotelRepository _hotelRepository;

    public HotelService(IHotelRepository hotelRepository)
    {
        _hotelRepository = hotelRepository;
    }

    public async Task<IEnumerable<Hotel>> GetAllAsync()
    {
        return await _hotelRepository.GetAllAsync();
    }

    public async Task<Hotel?> GetByIdAsync(Guid id)
    {
        return await _hotelRepository.GetByIdAsync(id);
    }

    public async Task<Hotel> CreateAsync(Hotel hotel)
    {
        await _hotelRepository.AddAsync(hotel);

        await _hotelRepository.SaveChangesAsync();

        return hotel;
    }

    public async Task UpdateAsync(Hotel hotel)
    {
        await _hotelRepository.UpdateAsync(hotel);

        await _hotelRepository.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var hotel = await _hotelRepository.GetByIdAsync(id);

        if (hotel is null)
        {
            throw new Exception("Hotel not found.");
        }

        hotel.IsActive = false;

        await _hotelRepository.SaveChangesAsync();
    }
}