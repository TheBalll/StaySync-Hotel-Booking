using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StaySync.Domain.Common;

namespace StaySync.Domain.Entities;

/// <summary>
/// Represents room type.
/// </summary>
public class RoomType : BaseEntity
{
    public string Name { get; set; } = null!;

    public int Capacity { get; set; }

    public decimal BasePrice { get; set; }

    public string Description { get; set; } = null!;

    public Guid HotelId { get; set; }

    public Hotel Hotel { get; set; } = null!;

    public ICollection<Room> Rooms { get; set; }
        = new List<Room>();
}
