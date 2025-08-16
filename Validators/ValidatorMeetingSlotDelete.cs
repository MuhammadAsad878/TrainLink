using FluentValidation;
using TrainLink.Constants;
using TrainLink.Dtos;

public class ValidatorMeetingSlotDelete : AbstractValidator<DtoMeetingSlotDelete>
{
    public ValidatorMeetingSlotDelete()
    {
        RuleFor(x => x.SlotId)
            .GreaterThan(0)
            .WithMessage(ValidationMessages.MustBePositive);

        RuleFor(x => x.UpdatedBy)
            .NotEmpty()
            .WithMessage(ValidationMessages.UpdatedByRequired)
            .MaximumLength(50)
            .WithMessage(ValidationMessages.UsernameLengthLong);
    }
}
