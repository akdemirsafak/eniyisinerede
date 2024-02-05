using eniyisinerede.API.RequestModels.Country;
using FluentValidation;

namespace eniyisinerede.API.Validations;

public class UpdateCountryRequestValidator : AbstractValidator<UpdateCountryRequest>
{
    public UpdateCountryRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required")
            .Length(1, 32).WithMessage("Name must be between 2 and 32 characters");
    }
}
