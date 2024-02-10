using FluentValidation;
using Location.Model.RequestModels.District;
using Location.Service.Utilities.Constants;

namespace Location.Service.Validations.District;

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
