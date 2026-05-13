using FluentValidation;
using StaySync.Application.DTOs.Requests;

namespace StaySync.Application.DTOs.Requests
{
    /// <summary>
    /// Create guest request.
    /// </summary>
    public class CreateGuestRequest
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        // ТРЯБВА да е string? тук
        public string? DocumentNumber { get; set; } 
    }
}
