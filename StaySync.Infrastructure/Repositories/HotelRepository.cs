using Microsoft.EntityFrameworkCore;
using StaySync.Application.Interfaces.Repositories;
using StaySync.Domain.Entities;
using StaySync.Infrastructure.Persistence.Context;

namespace StaySync.Infrastructure.Repositories;

/// <summary>
/// Hotel repository.
/// </summary>
public class HotelRepository : IHotelRepository
{
    private readonly StaySyncDbContext _context;

    public HotelRepository(StaySyncDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Hotel>> GetAllAsync()
    {
        return await _context.Hotels.ToListAsync();
    }

    public async Task<Hotel?> GetByIdAsync(Guid id)
    {
        return await _context.Hotels.FindAsync(id);
    }

    public async Task AddAsync(Hotel hotel)
    {
        await _context.Hotels.AddAsync(hotel);
    }

    public Task UpdateAsync(Hotel hotel)
    {
        _context.Hotels.Update(hotel);

        return Task.CompletedTask;
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}