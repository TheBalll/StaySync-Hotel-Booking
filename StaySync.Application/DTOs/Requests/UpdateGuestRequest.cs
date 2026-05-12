using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaySync.Application.DTOs.Requests
{
    /// <summary>
    /// Update guest request.
    /// </summary>
    public class UpdateGuestRequest
    {
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
