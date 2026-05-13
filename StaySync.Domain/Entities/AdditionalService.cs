using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StaySync.Domain.Common;

namespace StaySync.Domain.Entities;

/// <summary>
/// Represents additional service.
/// </summary>
public class AdditionalService : BaseEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public bool IsActive { get; set; } = true;

    public ICollection<ReservationServices> ReservationServices { get; set; }
        = new List<ReservationServices>();
}