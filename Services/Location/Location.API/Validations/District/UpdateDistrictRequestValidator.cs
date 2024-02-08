using FluentValidation;
using Location.API.RequestModels.District;

namespace Location.API.Validations.District;

public class UpdateDistrictRequestValidator : AbstractValidator<UpdateDistrictRequest>
{
    public UpdateDistrictRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required")
            .Length(1, 32).WithMessage("Name must be between 1-32 characters");

        RuleFor(x => x.CityId)
            .NotNull().WithMessage("CityId is required")
            .NotEmpty().WithMessage("CityId is required");
    }
}
