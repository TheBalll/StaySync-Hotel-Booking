using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaySync.Domain.Enums;

/// <summary>
/// Room status.
/// </summary>
public enum RoomStatus
{
    Available = 1,
    Occupied = 2,
    Maintenance = 3
}