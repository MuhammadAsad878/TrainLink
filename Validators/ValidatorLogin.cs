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
                .Matches(RegexPatterns.USERNAME_PATTERN).WithMessage(ValidationMessages.USERNAME_INVALID);

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage(ValidationMessages.PASSWORD_REQUIRED)
                .Matches(RegexPatterns.PASSWORD_PATTERN).WithMessage(ValidationMessages.PASSWORD_INVALID);
        }
    }

}
