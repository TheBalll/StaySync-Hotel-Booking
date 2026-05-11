using StaySync.Application.Interfaces.Repositories;
using StaySync.Application.Interfaces.Services;
using StaySync.Domain.Entities;
using StaySync.Domain.Enums;

namespace StaySync.Application.Interfaces.Services
{
    /// <summary>
    /// Reservation service.
    /// </summary>
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;

        public ReservationService(
            IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task<IEnumerable<Reservation>> GetAllAsync()
        {
            return await _reservationRepository.GetAllAsync();
        }

        public async Task<Reservation?> GetByIdAsync(Guid id)
        {
            return await _reservationRepository.GetByIdAsync(id);
        }

        public async Task<Reservation> CreateAsync(
            Reservation reservation)
        {
            if (reservation.CheckOutDate <= reservation.CheckInDate)
            {
                throw new Exception(
                    "Check-out date must be after check-in date.");
            }

            var overlapping =
                await _reservationRepository
                    .HasOverlappingReservationAsync(
                        reservation.RoomId,
                        reservation.CheckInDate,
                        reservation.CheckOutDate);

            if (overlapping)
            {
                throw new Exception(
                    "Room already reserved for selected period.");
            }

            reservation.Status = ReservationStatus.Pending;

            await _reservationRepository.AddAsync(reservation);

            await _reservationRepository.SaveChangesAsync();

            return reservation;
        }

        public async Task ConfirmAsync(Guid reservationId)
        {
            var reservation =
                await _reservationRepository.GetByIdAsync(
                    reservationId);

            if (reservation is null)
            {
                throw new Exception("Reservation not found.");
            }

            reservation.Status = ReservationStatus.Confirmed;

            await _reservationRepository.SaveChangesAsync();
        }

        public async Task CancelAsync(Guid reservationId)
        {
            var reservation =
                await _reservationRepository.GetByIdAsync(
                    reservationId);

            if (reservation is null)
            {
                throw new Exception("Reservation not found.");
            }

            reservation.Status = ReservationStatus.Cancelled;

            await _reservationRepository.SaveChangesAsync();
        }

        public async Task CheckInAsync(Guid reservationId)
        {
            var reservation =
                await _reservationRepository.GetByIdAsync(
                    reservationId);

            if (reservation is null)
            {
                throw new Exception("Reservation not found.");
            }

            if (reservation.Status == ReservationStatus.Cancelled)
            {
                throw new Exception(
                    "Cannot check in cancelled reservation.");
            }

            reservation.Status = ReservationStatus.CheckedIn;

            await _reservationRepository.SaveChangesAsync();
        }

        public async Task CheckOutAsync(Guid reservationId)
        {
            var reservation =
                await _reservationRepository.GetByIdAsync(
                    reservationId);

            if (reservation is null)
            {
                throw new Exception("Reservation not found.");
            }

            if (reservation.Status != ReservationStatus.CheckedIn)
            {
                throw new Exception(
                    "Reservation is not checked in.");
            }

            reservation.Status = ReservationStatus.Completed;

            await _reservationRepository.SaveChangesAsync();
        }
    }
}
