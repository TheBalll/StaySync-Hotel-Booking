using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaySync.Application.DTOs.Responses
{
    /// <summary>
    /// Room response.
    /// </summary>
    public class RoomResponse
    {
        /// <summary>
        /// Room id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Room number.
        /// </summary>
        public string Number { get; set; } = null!;

        /// <summary>
        /// Floor.
        /// </summary>
        public int Floor { get; set; }

        /// <summary>
        /// Capacity.
        /// </summary>
        public int Capacity { get; set; }
    }
}
