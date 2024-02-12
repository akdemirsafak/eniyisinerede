using eniyisinerede.API.RequestModels.Palace;
using FluentValidation;

namespace eniyisinerede.API.Validations.Palace;

public class UpdatePalaceRequestValidator : AbstractValidator<UpdatePalaceRequest>
{
    public UpdatePalaceRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Palace name is required")
            .Length(1, 32).WithMessage("Palace name must be between 1 and 32 characters");
        RuleFor(x => x.DistrictId)
            .NotEmpty().WithMessage("District id is required");
    }
}
