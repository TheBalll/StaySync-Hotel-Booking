using System.ComponentModel.DataAnnotations;

namespace StaySync.Application.DTOs.Requests
{
    /// <summary>
    /// Request for creating reservation.
    /// </summary>
    public class CreateReservationRequest
    {
        /// <summary>
        /// Guest id.
        /// </summary>
        [Required]
        public Guid GuestId { get; set; }

        /// <summary>
        /// Room id.
        /// </summary>
        [Required]
        public Guid RoomId { get; set; }

        /// <summary>
        /// Check in date.
        /// </summary>
        [Required]
        public DateTime CheckInDate { get; set; }

        /// <summary>
        /// Check out date.
        /// </summary>
        [Required]
        public DateTime CheckOutDate { get; set; }
    }
}
