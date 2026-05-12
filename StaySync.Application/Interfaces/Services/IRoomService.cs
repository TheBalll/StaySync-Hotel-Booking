using StaySync.Application.DTOs.Responses;

namespace StaySync.Application.Interfaces.Services
{
    /// <summary>
    /// Room service interface.
    /// </summary>
    public interface IRoomService
    {
        /// <summary>
        /// Gets available rooms.
        /// </summary>
        Task<IEnumerable<RoomResponse>> GetAvailableRoomsAsync(
            DateTime checkInDate,
            DateTime checkOutDate);
    }
}
