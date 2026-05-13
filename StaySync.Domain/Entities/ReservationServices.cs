using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaySync.Domain.Entities;

/// <summary>
/// Join entity for reservation and services.
/// </summary>
public class ReservationServices
{
    public Guid ReservationId { get; set; }

    public Reservation Reservation { get; set; } = null!;

    public Guid AdditionalServiceId { get; set; }

    public AdditionalService AdditionalService { get; set; } = null!;
}