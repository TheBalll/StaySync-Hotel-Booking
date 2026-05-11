using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaySync.Domain.Enums;

/// <summary>
/// Reservation status.
/// </summary>
public enum ReservationStatus
{
    Pending = 0,

    Confirmed = 1,

    Cancelled = 2,

    CheckedIn = 3,

    Completed = 4
}
