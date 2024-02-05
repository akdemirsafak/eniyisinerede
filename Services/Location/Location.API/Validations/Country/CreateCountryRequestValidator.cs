using FluentValidation;
using Location.API.RequestModels.Country;
using Location.API.Utilities.Constants;

namespace Location.API.Validations.Country;

public class CreateCountryRequestValidator : AbstractValidator<CreateCountryRequest>
{
    public CreateCountryRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage(ValidationResponseConstants.CountryNameIsRequired)
            .Length(1, 32).WithMessage(ValidationResponseConstants.CountryNameLength);
    }
}
