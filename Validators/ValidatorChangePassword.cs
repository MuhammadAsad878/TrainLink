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
                .NotEmpty().WithMessage(ValidationMessages.UsernameRequired)
                .MinimumLength(ValidationLengths.MinUsername).WithMessage(ValidationMessages.UsernameLengthShort)
                .MaximumLength(ValidationLengths.MaxUsername).WithMessage(ValidationMessages.UsernameLengthLong)
                .Matches(RegexPatterns.UsernamePattern).WithMessage(ValidationMessages.UsernameInvalid);


            RuleFor(x => x.OldPassword)
                .NotEmpty().WithMessage(ValidationMessages.PasswordRequired)
                .MinimumLength(ValidationLengths.MinPassword).WithMessage(ValidationMessages.PasswordTooShort)
                .MaximumLength(ValidationLengths.MaxPassword).WithMessage(ValidationMessages.PasswordTooLong)
                .Matches(RegexPatterns.PasswordUppercase).WithMessage(ValidationMessages.PasswordMustHaveUppercase)
                .Matches(RegexPatterns.PasswordLowercase).WithMessage(ValidationMessages.PasswordMustHaveLowercase)
                .Matches(RegexPatterns.PasswordDigit).WithMessage(ValidationMessages.PasswordMustHaveDigit)
                .Matches(RegexPatterns.PasswordSpecialChar).WithMessage(ValidationMessages.PasswordMustHaveSpecialChar);

            RuleFor(x => x.NewPassword)
               .NotEmpty().WithMessage(ValidationMessages.PasswordRequired)
               .MinimumLength(ValidationLengths.MinPassword).WithMessage(ValidationMessages.PasswordTooShort)
               .MaximumLength(ValidationLengths.MaxPassword).WithMessage(ValidationMessages.PasswordTooLong)
               .Matches(RegexPatterns.PasswordUppercase).WithMessage(ValidationMessages.PasswordMustHaveUppercase)
               .Matches(RegexPatterns.PasswordLowercase).WithMessage(ValidationMessages.PasswordMustHaveLowercase)
               .Matches(RegexPatterns.PasswordDigit).WithMessage(ValidationMessages.PasswordMustHaveDigit)
               .Matches(RegexPatterns.PasswordSpecialChar).WithMessage(ValidationMessages.PasswordMustHaveSpecialChar)
               .Must((model, NewPassword) => model.OldPassword != model.NewPassword).WithMessage(ValidationMessages.PasswordNotSame);

        }
    }
}
