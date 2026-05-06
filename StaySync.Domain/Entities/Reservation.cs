using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StaySync.Domain.Common;
using StaySync.Domain.Enums;

namespace StaySync.Domain.Entities;

/// <summary>
/// Represents reservation.
/// </summary>
public class Reservation : BaseEntity
{
    public Guid GuestId { get; set; }

    public Guest Guest { get; set; } = null!;

    public Guid RoomId { get; set; }

    public Room Room { get; set; } = null!;

    public DateTime CheckInDate { get; set; }

    public DateTime CheckOutDate { get; set; }

    public ReservationStatus Status { get; set; }

    public ICollection<Payment> Payments { get; set; }
        = new List<Payment>();

    public ICollection<ReservationService> ReservationServices { get; set; }
        = new List<ReservationService>();
}