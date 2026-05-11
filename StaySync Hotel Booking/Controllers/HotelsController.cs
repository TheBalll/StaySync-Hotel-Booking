using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StaySync.Application.DTOs.Requests;
using StaySync.Application.DTOs.Responses;
using StaySync.Application.Interfaces.Services;
using StaySync.Domain.Entities;

namespace StaySync_Hotel_Booking.Controllers
{
    /// <summary>
    /// Controller for hotel operations.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class HotelsController : ControllerBase
    {
        private readonly IHotelService _hotelService;
        private readonly IMapper _mapper;

        public HotelsController(
            IHotelService hotelService,
            IMapper mapper)
        {
            _hotelService = hotelService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all hotels.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelResponse>>> GetAll()
        {
            var hotels = await _hotelService.GetAllAsync();

            var response = _mapper.Map<IEnumerable<HotelResponse>>(hotels);

            return Ok(response);
        }

        /// <summary>
        /// Get hotel by id.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<HotelResponse>> GetById(Guid id)
        {
            var hotel = await _hotelService.GetByIdAsync(id);

            if (hotel is null)
            {
                return NotFound();
            }

            var response = _mapper.Map<HotelResponse>(hotel);

            return Ok(response);
        }

        /// <summary>
        /// Create hotel.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<HotelResponse>> Create(
            CreateHotelRequest request)
        {
            var hotel = _mapper.Map<Hotel>(request);

            var createdHotel = await _hotelService.CreateAsync(hotel);

            var response = _mapper.Map<HotelResponse>(createdHotel);

            return CreatedAtAction(
                nameof(GetById),
                new { id = response.Id },
                response);
        }

        /// <summary>
        /// Update hotel.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            Guid id,
            UpdateHotelRequest request)
        {
            var hotel = await _hotelService.GetByIdAsync(id);

            if (hotel is null)
            {
                return NotFound();
            }

            _mapper.Map(request, hotel);

            await _hotelService.UpdateAsync(hotel);

            return NoContent();
        }

        /// <summary>
        /// Delete hotel.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _hotelService.DeleteAsync(id);

            return NoContent();
        }
    }
}
