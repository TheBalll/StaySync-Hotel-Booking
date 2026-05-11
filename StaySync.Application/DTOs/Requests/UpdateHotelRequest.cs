using System.ComponentModel.DataAnnotations;

namespace StaySync.Application.DTOs.Requests;

/// <summary>
/// Request for updating hotel.
/// </summary>
public class UpdateHotelRequest
{
    /// <summary>
    /// Hotel name.
    /// </summary>
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Hotel address.
    /// </summary>
    [Required]
    [MaxLength(200)]
    public string Address { get; set; } = string.Empty;

    /// <summary>
    /// Hotel city.
    /// </summary>
    [Required]
    [MaxLength(100)]
    public string City { get; set; } = string.Empty;
}