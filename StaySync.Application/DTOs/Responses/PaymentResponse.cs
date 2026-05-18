namespace StaySync.Application.DTOs.Responses;

/// <summary>
/// Payment response.
/// </summary>
public class PaymentResponse
{
    /// <summary>
    /// Payment id.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Reservation id.
    /// </summary>
    public Guid ReservationId { get; set; }

    /// <summary>
    /// Amount.
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// Created at.
    /// </summary>
    public DateTime CreatedAt { get; set; }
}