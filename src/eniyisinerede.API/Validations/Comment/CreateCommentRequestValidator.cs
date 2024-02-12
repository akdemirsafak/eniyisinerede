using eniyisinerede.API.RequestModels.Comment;
using FluentValidation;

namespace eniyisinerede.API.Validations.Comment;

public class CreateCommentRequestValidator : AbstractValidator<CreateCommentRequest>
{
    public CreateCommentRequestValidator()
    {
        RuleFor(x => x.Header)
     .NotEmpty().WithMessage("Content is required")
     .Length(1, 32).WithMessage("Content must be between 1-32 characters");
        RuleFor(x => x.PalaceId)
            .NotNull().WithMessage("PalaceId is required")
            .GreaterThan(0).WithMessage("PalaceId must be greater than 0");
    }
}
