using StaySync.Application.DTOs.Requests;
using StaySync.Application.DTOs.Responses;

namespace StaySync.Application.Interfaces.Services
{
    /// <summary>
    /// Guest service interface.
    /// </summary>
    public interface IGuestService
    {
        Task<IEnumerable<GuestResponse>> GetAllAsync();

        Task<GuestResponse?> GetByIdAsync(Guid id);

        Task<GuestResponse> CreateAsync(
            CreateGuestRequest request);

        Task<GuestResponse> UpdateAsync(
            Guid id,
            UpdateGuestRequest request);

        Task DeactivateAsync(Guid id);
    }
}
