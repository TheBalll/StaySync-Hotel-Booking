using Microsoft.AspNetCore.Mvc;
using StaySync.Application.DTOs.Requests;
using StaySync.Application.DTOs.Responses;
using StaySync.Application.Interfaces.Services;
namespace StaySync_Hotel_Booking.Controllers
{
    /// <summary>
    /// Guests controller.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class GuestsController : ControllerBase
    {
        private readonly IGuestService _guestService;

        public GuestsController(
            IGuestService guestService)
        {
            _guestService = guestService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GuestResponse>>>
            GetAll()
        {
            return Ok(
                await _guestService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GuestResponse>>
            GetById(Guid id)
        {
            var guest =
                await _guestService.GetByIdAsync(id);

            if (guest == null)
            {
                return NotFound();
            }

            return Ok(guest);
        }

        [HttpPost]
        public async Task<ActionResult<GuestResponse>>
            Create(
                [FromBody]
            CreateGuestRequest request)
        {
            var guest =
                await _guestService.CreateAsync(request);

            return Ok(guest);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<GuestResponse>>
            Update(
                Guid id,
                [FromBody]
            UpdateGuestRequest request)
        {
            var guest =
                await _guestService.UpdateAsync(
                    id,
                    request);

            return Ok(guest);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult>
            Deactivate(Guid id)
        {
            await _guestService.DeactivateAsync(id);

            return NoContent();
        }
    }
}
