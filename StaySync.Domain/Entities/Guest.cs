using System;
using System.Collections.Generic;
using StaySync.Domain.Common;

namespace StaySync.Domain.Entities;

/// <summary>
/// Represents hotel guest.
/// </summary>
public class Guest : BaseEntity
{
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Phone { get; set; } = string.Empty;

    // Правилният начин: string? означава, че може да е NULL в базата данни
    public string? DocumentNumber { get; set; }

    public ICollection<Reservation> Reservations { get; set; }
        = new List<Reservation>();
}