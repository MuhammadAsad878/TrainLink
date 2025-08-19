using FluentValidation;
using TrainLink.Dtos;
using TrainLink.Constants;
namespace TrainLink.Validators
{
    public class ValidatorLogin : AbstractValidator<DtoLogin>
    {
        public ValidatorLogin()
        {
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage(ValidationMessages.USERNAME_REQUIRED)
                .MinimumLength(ValidationLengths.USERNAME_MIN_LENGTH).WithMessage(ValidationMessages.USERNAME_LENGTH_SHORT)
                .MaximumLength(ValidationLengths.USERNAME_MAX_LENGTH).WithMessage(ValidationMessages.USERNAME_LENGTH_LONG)
                .Matches(RegexPatterns.USERNAME_PATTERN).WithMessage(ValidationMessages.USERNAME_INVALID);


            RuleFor(x => x.Password)
                .NotEmpty().WithMessage(ValidationMessages.PASSWORD_REQUIRED)
                .MinimumLength(ValidationLengths.PASSWORD_MIN_LENGTH).WithMessage(ValidationMessages.PASSWORD_TOO_SHORT)
                .MaximumLength(ValidationLengths.PASSWORD_MAX_LENGTH).WithMessage(ValidationMessages.PASSWORD_TOO_LONG)
                .Matches(RegexPatterns.PASSWORD_UPPERCASE).WithMessage(ValidationMessages.PASSWORD_MUST_HAVE_UPPERCASE)
                .Matches(RegexPatterns.PASSWORD_LOWERCASE).WithMessage(ValidationMessages.PASSWORD_MUST_HAVE_LOWERCASE)
                .Matches(RegexPatterns.PASSWORD_DIGIT).WithMessage(ValidationMessages.PASSWORD_MUST_HAVE_DIGIT)
                .Matches(RegexPatterns.PASSWORD_SPECIAL_CHAR).WithMessage(ValidationMessages.PASSWORD_MUST_HAVE_SPECIAL_CHAR);

        }
    }
    
}
