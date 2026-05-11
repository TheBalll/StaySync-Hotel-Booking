namespace StaySync.Application.DTOs.Responses
{
    /// <summary>
    /// Hotel response model.
    /// </summary>
    public class HotelResponse
    {
        /// <summary>
        /// Hotel id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Hotel name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Hotel address.
        /// </summary>
        public string Address { get; set; } = string.Empty;

        /// <summary>
        /// Hotel city.
        /// </summary>
        public string City { get; set; } = string.Empty;

        /// <summary>
        /// Is hotel active.
        /// </summary>
        public bool IsActive { get; set; }
    }
}
