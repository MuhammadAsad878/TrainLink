using FluentValidation;
using TrainLink.Constants;
using TrainLink.Dtos;

namespace TrainLink.Validators
{
    public class ValidatorChangePassword : AbstractValidator<DtoChangePassword>
    {
        public ValidatorChangePassword()
        {
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage(ValidationMessages.USERNAME_REQUIRED)
                .MinimumLength(ValidationLengths.MIN_USERNAME).WithMessage(ValidationMessages.USERNAME_LENGTH_SHORT)
                .MaximumLength(ValidationLengths.MAX_USERNAME).WithMessage(ValidationMessages.USERNAME_LENGTH_LONG)
                .Matches(RegexPatterns.USERNAME_PATTERN).WithMessage(ValidationMessages.USERNAME_INVALID);

            RuleFor(x => x.OldPassword)
                .NotEmpty().WithMessage(ValidationMessages.PASSWORD_REQUIRED)
                .MinimumLength(ValidationLengths.MIN_PASSWORD).WithMessage(ValidationMessages.PASSWORD_TOO_SHORT)
                .MaximumLength(ValidationLengths.MAX_PASSWORD).WithMessage(ValidationMessages.PASSWORD_TOO_LONG)
                .Matches(RegexPatterns.PASSWORD_PATTERN).WithMessage(ValidationMessages.PASSWORD_INVALID);

            RuleFor(x => x.NewPassword)
               .NotEmpty().WithMessage(ValidationMessages.PASSWORD_REQUIRED)
               .MinimumLength(ValidationLengths.MIN_PASSWORD).WithMessage(ValidationMessages.PASSWORD_TOO_SHORT)
               .MaximumLength(ValidationLengths.MAX_PASSWORD).WithMessage(ValidationMessages.PASSWORD_TOO_LONG)
               .Matches(RegexPatterns.PASSWORD_PATTERN).WithMessage(ValidationMessages.PASSWORD_INVALID)
               .Must((model, NewPassword) => model.OldPassword != model.NewPassword).WithMessage(ValidationMessages.PASSWORD_NOT_SAME);

        }
    }
}
