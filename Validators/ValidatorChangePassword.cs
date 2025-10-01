using FluentValidation;
using TrainLink.Constants;
using TrainLink.Dtos;

namespace TrainLink.Validators
{
    public class ValidatorChangePassword : AbstractValidator<DtoChangePassword>
    {
        public ValidatorChangePassword()
        {
           
            RuleFor(x => x.OldPassword)
                .NotEmpty().WithMessage(ValidationMessages.PASSWORD_REQUIRED)
                .Matches(RegexPatterns.PASSWORD_PATTERN).WithMessage(ValidationMessages.PASSWORD_MUST_BE);

            RuleFor(x => x.NewPassword)
               .NotEmpty().WithMessage(ValidationMessages.PASSWORD_REQUIRED)
                               .Matches(RegexPatterns.PASSWORD_PATTERN).WithMessage(ValidationMessages.PASSWORD_MUST_BE)
               .Must((model, NewPassword) => model.OldPassword != model.NewPassword).WithMessage(ValidationMessages.PASSWORD_NOT_SAME);
        }
    }
}
