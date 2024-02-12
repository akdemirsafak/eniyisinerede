using FluentValidation;
using Location.Model.RequestModels.Country;
using Location.Service.Utilities.Constants;

namespace Location.Service.Validations.Country;

public class CreateCountryRequestValidator : AbstractValidator<CreateCountryRequest>
{
    public CreateCountryRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage(ValidationResponseConstants.CountryNameIsRequired)
            .Length(1, 32).WithMessage(ValidationResponseConstants.CountryNameLength);
    }
}
