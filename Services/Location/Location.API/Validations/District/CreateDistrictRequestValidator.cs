using FluentValidation;
using Location.API.RequestModels.District;
using Location.API.Utilities.Constants;

namespace Location.API.Validations.District;

public class CreateDistrictRequestValidator : AbstractValidator<CreateDistrictRequest>
{
    public CreateDistrictRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage(ValidationResponseConstants.DistrictNameIsRequired)
            .Length(1, 32).WithMessage(ValidationResponseConstants.DistrictNameLength);

        RuleFor(x => x.CityId)
            .NotNull().WithMessage(ValidationResponseConstants.CityIdIsRequired)
            .NotEmpty().WithMessage(ValidationResponseConstants.CityIdIsRequired);
    }
}
