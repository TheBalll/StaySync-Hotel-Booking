using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StaySync.Domain.Common;

namespace StaySync.Domain.Entities;

/// <summary>
/// Represents hotel guest.
/// </summary>
public class Guest : BaseEntity
{
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string DocumentNumber { get; set; } = null!;

    public ICollection<Reservation> Reservations { get; set; }
        = new List<Reservation>();
}
