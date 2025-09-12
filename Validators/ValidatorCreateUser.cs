using FluentValidation;
using TrainLink.Dtos;
using TrainLink.Constants;

namespace TrainLink.Validators
{
    public class ValidatorCreateUser : AbstractValidator<DtoCreateUser>
    {
        public ValidatorCreateUser()
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
                .Matches(RegexPatterns.PASSWORD_PATTERN).WithMessage(ValidationMessages.PASSWORD_MUST_BE);

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(ValidationMessages.NAME_REQUIRED)
                .MaximumLength(ValidationLengths.NAME_MAX_LENGTH).WithMessage(ValidationMessages.NAME_LENGTH_LONG);

            RuleFor(x => x.Mobile)
                .NotEmpty().WithMessage(ValidationMessages.MOBILE_REQUIRED)
                .Matches(RegexPatterns.MOBILE_PATTERN).WithMessage(ValidationMessages.MOBILE_INVALID);

            RuleFor(x => x.RoleId)
                .GreaterThan(0).WithMessage(ValidationMessages.ROLE_REQUIRED);

            RuleFor(x => x.MembershipExpiry)
                .GreaterThan(DateTime.UtcNow).When(x => x.MembershipExpiry.HasValue)
                .WithMessage(ValidationMessages.MEMBERSHIP_EXPIRY_INVALID);
        }
    }
}
