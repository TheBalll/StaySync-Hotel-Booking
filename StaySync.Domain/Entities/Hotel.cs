using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StaySync.Domain.Common;

namespace StaySync.Domain.Entities;

/// <summary>
/// Represents a hotel.
/// </summary>
public class Hotel : BaseEntity
{
    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public ICollection<RoomType> RoomTypes { get; set; }
        = new List<RoomType>();

    public ICollection<Room> Rooms { get; set; }
        = new List<Room>();
}