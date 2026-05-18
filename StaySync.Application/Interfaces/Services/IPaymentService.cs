using StaySync.Application.DTOs.Requests;
using StaySync.Application.DTOs.Responses;

namespace StaySync.Application.Interfaces.Services;

/// <summary>
/// Payment service interface.
/// </summary>
public interface IPaymentService
{
    /// <summary>
    /// Creates payment.
    /// </summary>
    Task<PaymentResponse> CreateAsync(
        CreatePaymentRequest request);

    /// <summary>
    /// Gets payments by reservation id.
    /// </summary>
    Task<IEnumerable<PaymentResponse>>
        GetByReservationIdAsync(Guid reservationId);
}