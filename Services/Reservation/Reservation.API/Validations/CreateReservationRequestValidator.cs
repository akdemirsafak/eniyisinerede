using FluentValidation;
using Reservation.API.RequestModels;

namespace Reservation.API.Validations;

public class CreateReservationRequestValidator:AbstractValidator<CreateReservationRequest>
{
    public CreateReservationRequestValidator()
    {
        RuleFor(x => x.DateAndTime)
            .NotNull().WithMessage("Date and time is required")
            .Must(x => x.Date >= DateTime.UtcNow).WithMessage("Date and time should be greater than current date and time");
       
        RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage("Phone is required")
            .Matches(@"^\d{10}$").WithMessage("Invalid phone number");

        RuleFor(x => x.Notes).MaximumLength(128).WithMessage("Notes should be less than 128 characters");

        RuleFor(x => x.NumberOfPerson)
            .Null().WithMessage("Number of person is required")
            .GreaterThan(0).WithMessage("Number of person should be greater than 0");
    }
}
