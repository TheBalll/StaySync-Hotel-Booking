using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaySync.Domain.Entities;

public class ReservationAdditionalService
{
    public Guid ReservationId { get; set; }
    public Reservation Reservation { get; set; } = null!;

    public Guid AdditionalServiceId { get; set; }
    public AdditionalService AdditionalService { get; set; } = null!;
}
