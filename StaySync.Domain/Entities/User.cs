using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StaySync.Domain.Common;

namespace StaySync.Domain.Entities;

/// <summary>
/// Represents system user.
/// </summary>
public class User : BaseEntity
{
    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Role { get; set; } = null!;
}