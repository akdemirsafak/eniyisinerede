using FluentValidation;
using Location.Model.RequestModels.Country;
using Location.Service.Utilities.Constants;

namespace Location.Service.Validations.Country;

public class UpdateCountryRequestValidator : AbstractValidator<UpdateCountryRequest>
{
    public UpdateCountryRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage(ValidationResponseConstants.CountryNameIsRequired)
            .Length(1, 32).WithMessage(ValidationResponseConstants.CountryNameLength);
    }
}
