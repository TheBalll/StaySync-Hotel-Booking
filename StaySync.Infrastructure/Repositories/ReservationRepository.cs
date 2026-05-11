using Microsoft.EntityFrameworkCore;
using StaySync.Application.Interfaces.Repositories;
using StaySync.Domain.Entities;
using StaySync.Domain.Enums;
using StaySync.Infrastructure.Persistence.Context;

namespace StaySync.Infrastructure.Repositories
{
    /// <summary>
    /// Reservation repository.
    /// </summary>
    public class ReservationRepository : IReservationRepository
    {
        private readonly StaySyncDbContext _context;

        public ReservationRepository(StaySyncDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Reservation>> GetAllAsync()
        {
            return await _context.Reservations
                .Include(r => r.Guest)
                .Include(r => r.Room)
                .ToListAsync();
        }

        public async Task<Reservation?> GetByIdAsync(Guid id)
        {
            return await _context.Reservations
                .Include(r => r.Guest)
                .Include(r => r.Room)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task AddAsync(Reservation reservation)
        {
            await _context.Reservations.AddAsync(reservation);
        }

        public Task UpdateAsync(Reservation reservation)
        {
            _context.Reservations.Update(reservation);

            return Task.CompletedTask;
        }

        public async Task<bool> HasOverlappingReservationAsync(
            Guid roomId,
            DateTime checkIn,
            DateTime checkOut)
        {
            return await _context.Reservations.AnyAsync(r =>
                r.RoomId == roomId &&
                r.Status != ReservationStatus.Cancelled &&
                checkIn < r.CheckOutDate &&
                checkOut > r.CheckInDate);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
