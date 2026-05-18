using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StaySync.Application.DTOs.Requests;
using StaySync.Application.DTOs.Responses;
using StaySync.Application.Interfaces.Services;
using StaySync.Domain.Entities;
using StaySync.Infrastructure.Persistence.Context;

namespace StaySync.Infrastructure.Services;

/// <summary>
/// Payment service.
/// </summary>
public class PaymentService : IPaymentService
{
    private readonly StaySyncDbContext _context;

    private readonly IMapper _mapper;

    public PaymentService(
        StaySyncDbContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Creates payment.
    /// </summary>
    public async Task<PaymentResponse>
        CreateAsync(CreatePaymentRequest request)
    {
        if (request.Amount <= 0)
        {
            throw new Exception(
                "Payment amount must be greater than zero.");
        }

        var reservation =
            await _context.Reservations
                .FirstOrDefaultAsync(r =>
                    r.Id == request.ReservationId);

        if (reservation == null)
        {
            throw new Exception(
                "Reservation not found.");
        }

        var payment = new Payment
        {
            Id = Guid.NewGuid(),
            ReservationId = request.ReservationId,
            Amount = request.Amount,
            CreatedAt = DateTime.UtcNow
        };

        _context.Payments.Add(payment);

        await _context.SaveChangesAsync();

        return _mapper.Map<PaymentResponse>(
            payment);
    }

    /// <summary>
    /// Gets payments by reservation id.
    /// </summary>
    public async Task<IEnumerable<PaymentResponse>>
        GetByReservationIdAsync(Guid reservationId)
    {
        var payments =
            await _context.Payments
                .Where(p =>
                    p.ReservationId == reservationId)
                .ToListAsync();

        return _mapper.Map<IEnumerable<PaymentResponse>>(
            payments);
    }
}