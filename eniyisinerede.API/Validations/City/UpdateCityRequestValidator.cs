using eniyisinerede.API.RequestModels.City;
using FluentValidation;

namespace eniyisinerede.API.Validations.City;

public class UpdateCityRequestValidator : AbstractValidator<UpdateCityRequest>
{
    public UpdateCityRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("City name is required")
            .Length(1, 32).WithMessage("City name must be between 1 and 32 characters");
        RuleFor(x => x.CountryId)
            .NotEmpty().WithMessage("Country id is required");
    }
}
