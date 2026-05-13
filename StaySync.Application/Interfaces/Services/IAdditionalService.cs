using StaySync.Application.DTOs.Responses;

namespace StaySync.Application.Interfaces.Services
{
    public interface IAdditionalService
    {
        Task<IEnumerable<AdditionalServiceResponse>> GetAllActiveAsync();
    }
}
