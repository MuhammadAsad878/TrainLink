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
                .NotEmpty().WithMessage(ValidationMessages.UsernameRequired)
                .MinimumLength(ValidationLengths.MinUsername).WithMessage(ValidationMessages.UsernameLengthShort)
                .MaximumLength(ValidationLengths.MaxUsername).WithMessage(ValidationMessages.UsernameLengthLong)
                .Matches(RegexPatterns.UsernamePattern).WithMessage(ValidationMessages.UsernameInvalid);


            RuleFor(x => x.Password)
                .NotEmpty().WithMessage(ValidationMessages.PasswordRequired)
                .MinimumLength(ValidationLengths.MinPassword).WithMessage(ValidationMessages.PasswordTooShort)
                .MaximumLength(ValidationLengths.MaxPassword).WithMessage(ValidationMessages.PasswordTooLong)
                .Matches(RegexPatterns.PasswordUppercase).WithMessage(ValidationMessages.PasswordMustHaveUppercase)
                .Matches(RegexPatterns.PasswordLowercase).WithMessage(ValidationMessages.PasswordMustHaveLowercase)
                .Matches(RegexPatterns.PasswordDigit).WithMessage(ValidationMessages.PasswordMustHaveDigit)
                .Matches(RegexPatterns.PasswordSpecialChar).WithMessage(ValidationMessages.PasswordMustHaveSpecialChar);

        }
    }
    
}
