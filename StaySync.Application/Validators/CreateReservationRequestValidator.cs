using FluentValidation;
using StaySync.Application.DTOs.Requests;

namespace StaySync.Application.Validators;

public class CreateReservationRequestValidator : AbstractValidator<CreateReservationRequest>
{
    public CreateReservationRequestValidator()
    {
        RuleFor(x => x.RoomId).NotEmpty();
        RuleFor(x => x.GuestId).NotEmpty();

        RuleFor(x => x.CheckInDate)
            .GreaterThanOrEqualTo(DateTime.Today).WithMessage("Check-in date cannot be in the past.");

        RuleFor(x => x.CheckOutDate)
            .GreaterThan(x => x.CheckInDate).WithMessage("Check-out date must be after check-in date.");

        RuleFor(x => x.ServiceIds)
            .NotNull().WithMessage("Service list cannot be null.");
    }
}