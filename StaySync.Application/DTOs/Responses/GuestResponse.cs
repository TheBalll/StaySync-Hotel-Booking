using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaySync.Application.DTOs.Responses
{
    /// <summary>
    /// Guest response.
    /// </summary>
    public class GuestResponse
    {
        /// <summary>
        /// Guest id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// First name.
        /// </summary>
        public string FirstName { get; set; } = null!;

        /// <summary>
        /// Last name.
        /// </summary>
        public string LastName { get; set; } = null!;

        /// <summary>
        /// Email.
        /// </summary>
        public string Email { get; set; } = null!;
    }
}
