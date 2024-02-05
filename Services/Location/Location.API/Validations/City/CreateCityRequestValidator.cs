using FluentValidation;
using Location.API.RequestModels.City;
using Location.API.Utilities.Constants;

namespace Location.API.Validations.City;

public class CreateCityRequestValidator : AbstractValidator<CreateCityRequest>
{
    public CreateCityRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage(ValidationResponseConstants.CityNameIsRequired)
            .Length(1, 32).WithMessage(ValidationResponseConstants.CityNameLength);
        RuleFor(x => x.CountryId)
            .NotEmpty().WithMessage(ValidationResponseConstants.CountryIdIsRequired);
    }
}
