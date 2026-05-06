using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StaySync.Domain.Common;

namespace StaySync.Domain.Entities;

/// <summary>
/// Represents guest stay.
/// </summary>
public class Stay : BaseEntity
{
    public Guid ReservationId { get; set; }

    public Reservation Reservation { get; set; } = null!;

    public DateTime ActualCheckIn { get; set; }

    public DateTime? ActualCheckOut { get; set; }
}
