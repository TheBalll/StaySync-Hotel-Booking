using StaySync.Domain.Entities;

namespace StaySync.Application.Interfaces.Services
{
    /// <summary>
    /// Reservation service contract.
    /// </summary>
    public interface IReservationService
    {
        Task<IEnumerable<Reservation>> GetAllAsync();

        Task<Reservation?> GetByIdAsync(Guid id);

        Task<Reservation> CreateAsync(Reservation reservation);

        Task ConfirmAsync(Guid reservationId);

        Task CancelAsync(Guid reservationId);

        Task CheckInAsync(Guid reservationId);

        Task CheckOutAsync(Guid reservationId);
    }
}
