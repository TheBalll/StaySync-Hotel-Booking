using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StaySync.Domain.Common;

namespace StaySync.Domain.Entities;

/// <summary>
/// Represents payment.
/// </summary>
public class Payment : BaseEntity
{
    public Guid ReservationId { get; set; }

    public Reservation Reservation { get; set; } = null!;

    public decimal Amount { get; set; }

    public DateTime PaidAt { get; set; }
}
