using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StaySync.Application.DTOs.Responses;
using StaySync.Application.Interfaces.Services;
using StaySync.Domain.Entities;
using StaySync.Domain.Enums;
using StaySync.Infrastructure.Persistence.Context;

namespace StaySync.Infrastructure.Services;

/// <summary>
/// Room service.
/// </summary>
public class RoomService : IRoomService
{
    private readonly StaySyncDbContext _context;

    private readonly IMapper _mapper;

    public RoomService(
        StaySyncDbContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Gets available rooms.
    /// </summary>
    public async Task<IEnumerable<RoomResponse>>
        GetAvailableRoomsAsync(
            DateTime checkInDate,
            DateTime checkOutDate)
    {
        var reservedRoomIds =
            await _context.Reservations
                .Where(r =>
                    r.Status != ReservationStatus.Cancelled &&
                    r.CheckInDate < checkOutDate &&
                    r.CheckOutDate > checkInDate)
                .Select(r => r.RoomId)
                .ToListAsync();

        var availableRooms =
            await _context.Rooms
                .Where(r =>
                    !reservedRoomIds.Contains(r.Id))
                .ToListAsync();

        return _mapper.Map<IEnumerable<RoomResponse>>(
            availableRooms);
    }
}