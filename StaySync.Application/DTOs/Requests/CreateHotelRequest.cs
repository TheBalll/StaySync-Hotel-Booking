using System.ComponentModel.DataAnnotations;

namespace StaySync.Application.DTOs.Requests;

/// <summary>
/// Request for creating hotel.
/// </summary>
  public class CreateHotelRequest
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