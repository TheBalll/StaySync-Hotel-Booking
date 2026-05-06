using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StaySync.Domain.Common;
using StaySync.Domain.Enums;


namespace StaySync.Domain.Entities;

/// <summary>
/// Represents hotel room.
/// </summary>
public class Room : BaseEntity
{
    public string Number { get; set; } = null!;

    public int Floor { get; set; }

    public RoomStatus Status { get; set; }

    public Guid HotelId { get; set; }

    public Hotel Hotel { get; set; } = null!;

    public Guid RoomTypeId { get; set; }

    public RoomType RoomType { get; set; } = null!;

    public ICollection<Reservation> Reservations { get; set; }
        = new List<Reservation>();
}
