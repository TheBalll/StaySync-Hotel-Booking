using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StaySync.Application.DTOs.Requests;
using StaySync.Application.DTOs.Responses;
using StaySync.Application.Interfaces.Services;
using StaySync.Domain.Entities;

namespace StaySync_Hotel_Booking.Controllers
{
    /// <summary>
    /// Controller for reservation operations.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationService _reservationService;
        private readonly IMapper _mapper;

        public ReservationsController(
            IReservationService reservationService,
            IMapper mapper)
        {
            _reservationService = reservationService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReservationResponse>>> GetAll()
        {
            var reservations =
                await _reservationService.GetAllAsync();

            var response =
                _mapper.Map<IEnumerable<ReservationResponse>>(
                    reservations);

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ReservationResponse>> Create(
    [FromBody] CreateReservationRequest request)
        {
            var reservation =
                _mapper.Map<Reservation>(request);

            var created =
                await _reservationService.CreateAsync(
                    reservation);

            var response =
                _mapper.Map<ReservationResponse>(created);

            return Ok(response);
        }

        [HttpPost("{id}/confirm")]
        public async Task<IActionResult> Confirm(Guid id)
        {
            await _reservationService.ConfirmAsync(id);

            return NoContent();
        }

        [HttpPost("{id}/cancel")]
        public async Task<IActionResult> Cancel(Guid id)
        {
            await _reservationService.CancelAsync(id);

            return NoContent();
        }

        [HttpPost("{id}/check-in")]
        public async Task<IActionResult> CheckIn(Guid id)
        {
            await _reservationService.CheckInAsync(id);

            return NoContent();
        }

        [HttpPost("{id}/check-out")]
        public async Task<IActionResult> CheckOut(Guid id)
        {
            await _reservationService.CheckOutAsync(id);

            return NoContent();
        }
    }
}
