using FluentValidation;
using StaySync.Application.DTOs.Requests;

namespace StaySync.Application.Validators;

public class CreateGuestRequestValidator : AbstractValidator<CreateGuestRequest>
{
    public CreateGuestRequestValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("First name is required.");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Last name is required.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("A valid email address is required.");

        // За DocumentNumber и Phone НЕ слагаме NotEmpty(). 
        // Може само проверка за дължина, ако има стойност.
        RuleFor(x => x.DocumentNumber)
            .MaximumLength(20).When(x => !string.IsNullOrEmpty(x.DocumentNumber));

       
    }
}