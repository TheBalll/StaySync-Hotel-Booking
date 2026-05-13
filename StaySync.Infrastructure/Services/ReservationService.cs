using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StaySync.Application.Interfaces.Services;
using StaySync.Domain.Entities;
using StaySync.Infrastructure.Persistence.Context;

namespace StaySync.Infrastructure.Services;

public class ReservationService : IReservationService
{
    private readonly StaySyncDbContext _context;
    private readonly IMapper _mapper;

    public ReservationService(StaySyncDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    // Връща IEnumerable<Reservation> според снимката
    public async Task<IEnumerable<Reservation>> GetAllAsync()
    {
        return await _context.Reservations
            .Include(r => r.Room)
            .Include(r => r.Guest)
            .ToListAsync();
    }

    // Връща Reservation? според снимката
    public async Task<Reservation?> GetByIdAsync(Guid id)
    {
        return await _context.Reservations
            .Include(r => r.Room)
            .Include(r => r.Guest)
            .FirstOrDefaultAsync(r => r.Id == id);
    }

    // Приема Reservation reservation според снимката
    public async Task<Reservation> CreateAsync(Reservation reservation)
    {
        // Тук можеш да добавиш логиката за цената, ако искаш
        _context.Reservations.Add(reservation);
        await _context.SaveChangesAsync();
        return reservation;
    }

    // Методите от интерфейса, които липсваха:

    public async Task ConfirmAsync(Guid reservationId)
    {
        var reservation = await _context.Reservations.FindAsync(reservationId);
        if (reservation != null)
        {
            // Тук трябва да имаш статус в Reservation Entity-то
            // reservation.Status = ReservationStatus.Confirmed; 
            await _context.SaveChangesAsync();
        }
    }

    public async Task CancelAsync(Guid reservationId)
    {
        var reservation = await _context.Reservations.FindAsync(reservationId);
        if (reservation != null)
        {
            await _context.SaveChangesAsync();
        }
    }

    public async Task CheckInAsync(Guid reservationId)
    {
        var reservation = await _context.Reservations.FindAsync(reservationId);
        if (reservation != null)
        {
            await _context.SaveChangesAsync();
        }
    }

    public async Task CheckOutAsync(Guid reservationId)
    {
        var reservation = await _context.Reservations.FindAsync(reservationId);
        if (reservation != null)
        {
            await _context.SaveChangesAsync();
        }
    }
}