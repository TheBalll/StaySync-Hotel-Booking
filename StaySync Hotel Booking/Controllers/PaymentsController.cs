using Microsoft.AspNetCore.Mvc;
using StaySync.Application.DTOs.Requests;
using StaySync.Application.DTOs.Responses;
using StaySync.Application.Interfaces.Services;
namespace StaySync_Hotel_Booking.Controllers
{
    /// <summary>
    /// Payments controller.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        /// <summary>
        /// Constructor.
        /// </summary>
        public PaymentsController(
            IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        /// <summary>
        /// Creates payment.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<PaymentResponse>>
            Create(
                [FromBody]
            CreatePaymentRequest request)
        {
            var payment =
                await _paymentService.CreateAsync(
                    request);

            return Ok(payment);
        }

        /// <summary>
        /// Gets payments by reservation id.
        /// </summary>
        [HttpGet("reservation/{reservationId}")]
        public async Task<ActionResult<
            IEnumerable<PaymentResponse>>>
            GetByReservationId(Guid reservationId)
        {
            var payments =
                await _paymentService
                    .GetByReservationIdAsync(
                        reservationId);

            return Ok(payments);
        }
    }
}
