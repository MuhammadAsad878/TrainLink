using FluentValidation;
using TrainLink.Dtos;
using TrainLink.Constants;

namespace TrainLink.Validators
{
    public class ValidatorUpdateUser : AbstractValidator<DtoUpdateUser>
    {
        public ValidatorUpdateUser()
        {
            When(x => !string.IsNullOrWhiteSpace(x.Name), () =>
            {
                RuleFor(x => x.Name)
                    .MaximumLength(ValidationLengths.NAME_MAX_LENGTH)
                    .WithMessage(ValidationMessages.NAME_LENGTH_LONG);
            });

            When(x => !string.IsNullOrWhiteSpace(x.Mobile), () =>
            {
                RuleFor(x => x.Mobile)
                    .Matches(RegexPatterns.MOBILE_PATTERN)
                    .WithMessage(ValidationMessages.MOBILE_INVALID);
            });

            When(x => x.RoleId.HasValue, () =>
            {
                RuleFor(x => x.RoleId)
                    .GreaterThan(0)
                    .WithMessage(ValidationMessages.ROLE_REQUIRED);
            });

            When(x => !string.IsNullOrWhiteSpace(x.Password), () =>
            {
                RuleFor(x => x.Password)                    
                    .Matches(RegexPatterns.PASSWORD_PATTERN)
                    .WithMessage(ValidationMessages.PASSWORD_MUST_BE);
            });
        }
    }
}
