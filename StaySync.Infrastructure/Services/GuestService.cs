using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StaySync.Application.DTOs.Requests;
using StaySync.Application.DTOs.Responses;
using StaySync.Application.Interfaces.Services;
using StaySync.Domain.Entities;
using StaySync.Infrastructure.Persistence.Context;

namespace StaySync.Infrastructure.Services;

/// <summary>
/// Guest service.
/// </summary>
public class GuestService : IGuestService
{
    private readonly StaySyncDbContext _context;

    private readonly IMapper _mapper;

    public GuestService(
        StaySyncDbContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GuestResponse>>
        GetAllAsync()
    {
        var guests =
            await _context.Guests.ToListAsync();

        return _mapper.Map<IEnumerable<GuestResponse>>(
            guests);
    }

    public async Task<GuestResponse?>
        GetByIdAsync(Guid id)
    {
        var guest =
            await _context.Guests.FindAsync(id);

        if (guest == null)
        {
            return null;
        }

        return _mapper.Map<GuestResponse>(guest);
    }

    public async Task<GuestResponse>
        CreateAsync(CreateGuestRequest request)
    {
        var guest =
            _mapper.Map<Guest>(request);

        _context.Guests.Add(guest);

        await _context.SaveChangesAsync();

        return _mapper.Map<GuestResponse>(guest);
    }

    public async Task<GuestResponse>
        UpdateAsync(
            Guid id,
            UpdateGuestRequest request)
    {
        var guest =
            await _context.Guests.FindAsync(id);

        if (guest == null)
        {
            throw new Exception("Guest not found.");
        }

        _mapper.Map(request, guest);

        await _context.SaveChangesAsync();

        return _mapper.Map<GuestResponse>(guest);
    }

    public async Task DeactivateAsync(Guid id)
    {
        var guest =
            await _context.Guests.FindAsync(id);

        if (guest == null)
        {
            throw new Exception("Guest not found.");
        }

        guest.IsActive = false;

        await _context.SaveChangesAsync();
    }
}