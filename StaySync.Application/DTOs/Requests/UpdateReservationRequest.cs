using System.ComponentModel.DataAnnotations;

namespace StaySync.Application.DTOs.Requests
{
    /// <summary>
    /// Request for updating reservation.
    /// </summary>
    public class UpdateReservationRequest
    {
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
