using FluentValidation;
using TrainLink.Dtos;
using TrainLink.Constants;
namespace TrainLink.Validators
{
    public class ValidatorLogin : AbstractValidator<LoginRequest>
    {
        public ValidatorLogin()
        {
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage(ValidationMessages.USERNAME_REQUIRED)
                .MinimumLength(ValidationLengths.MIN_USERNAME).WithMessage(ValidationMessages.USERNAME_LENGTH_SHORT)
                .MaximumLength(ValidationLengths.MAX_USERNAME).WithMessage(ValidationMessages.USERNAME_LENGTH_LONG)
                .Matches(RegexPatterns.USERNAME_PATTERN).WithMessage(ValidationMessages.USERNAME_INVALID);

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage(ValidationMessages.PASSWORD_REQUIRED)
                .MinimumLength(ValidationLengths.MIN_PASSWORD).WithMessage(ValidationMessages.PASSWORD_TOO_SHORT)
                .MaximumLength(ValidationLengths.MAX_PASSWORD).WithMessage(ValidationMessages.PASSWORD_TOO_LONG)
                .Matches(RegexPatterns.PASSWORD_PATTERN).WithMessage(ValidationMessages.PASSWORD_INVALID);
        }
    }

}
