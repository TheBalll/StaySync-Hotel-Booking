namespace StaySync.Application.DTOs.Requests;

/// <summary>
/// Create payment request.
/// </summary>
public class CreatePaymentRequest
{
    /// <summary>
    /// Reservation id.
    /// </summary>
    public Guid ReservationId { get; set; }

    /// <summary>
    /// Payment amount.
    /// </summary>
    public decimal Amount { get; set; }
}