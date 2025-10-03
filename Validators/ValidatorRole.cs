using FluentValidation;
using TrainLink.Constants;
using TrainLink.Dtos;

namespace TrainLink.Validators
{
    public class ValidatorRole : AbstractValidator<DtoRole>
    {
        public ValidatorRole()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(ValidationMessages.ROLE_REQUIRED)
                .Matches(RegexPatterns.AlphabetsOnlyRegex).WithMessage(ValidationMessages.ROLE_NAME_INVALID);
        }
    }
}
