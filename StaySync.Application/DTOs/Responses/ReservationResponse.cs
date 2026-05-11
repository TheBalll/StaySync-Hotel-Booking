using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaySync.Application.DTOs.Responses
{
    /// <summary>
    /// Reservation response.
    /// </summary>
    public class ReservationResponse
    {
        /// <summary>
        /// Reservation id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Guest id.
        /// </summary>
        public Guid GuestId { get; set; }

        /// <summary>
        /// Room id.
        /// </summary>
        public Guid RoomId { get; set; }

        /// <summary>
        /// Check in date.
        /// </summary>
        public DateTime CheckInDate { get; set; }

        /// <summary>
        /// Check out date.
        /// </summary>
        public DateTime CheckOutDate { get; set; }

        /// <summary>
        /// Reservation status.
        /// </summary>
        public string Status { get; set; } = string.Empty;
    }
}
