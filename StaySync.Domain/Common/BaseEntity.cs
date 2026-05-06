using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaySync.Domain.Common;

/// <summary>
/// Base entity for all entities.
/// </summary>
public abstract class BaseEntity
{
    /// <summary>
    /// Primary identifier.
    /// </summary>
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Indicates whether entity is active.
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// Creation date.
    /// </summary>
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}