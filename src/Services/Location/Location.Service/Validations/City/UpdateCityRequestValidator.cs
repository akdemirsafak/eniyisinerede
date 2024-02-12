using FluentValidation;
using Location.Model.RequestModels.City;
using Location.Service.Utilities.Constants;

namespace Location.Service.Validations.City;

public class UpdateCityRequestValidator : AbstractValidator<UpdateCityRequest>
{
    public UpdateCityRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage(ValidationResponseConstants.CityNameIsRequired)
            .Length(1, 32).WithMessage(ValidationResponseConstants.CityNameLength);
        RuleFor(x => x.CountryId)
            .NotEmpty().WithMessage(ValidationResponseConstants.CountryIdIsRequired);
    }
}
