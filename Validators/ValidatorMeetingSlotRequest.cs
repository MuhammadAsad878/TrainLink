using FluentValidation;
using TrainLink.Constants;
using TrainLink.Dtos;

public class ValidatorMeetingSlotRequest : AbstractValidator<DtoMeetingSlotRequest>
{
    public ValidatorMeetingSlotRequest()
    {
        RuleFor(x => x.SlotTime)
            .NotEmpty()
            .WithMessage(ValidationMessages.SLOT_TIME_REQUIRED);
        RuleFor(x => x.SlotTime)
            .GreaterThan(TimeOnly.MinValue)
            .WithMessage(ValidationMessages.SLOT_TIME_MUST_BE_LESS)
            .LessThan(TimeOnly.MaxValue)
            .WithMessage(ValidationMessages.SLOT_TIME_MUST_BE_GREATER);
    }
}
