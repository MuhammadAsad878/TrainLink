using FluentValidation;
using TrainLink.Constants;
using TrainLink.Dtos;

public class ValidatorMeetingSlotRequest : AbstractValidator<DtoMeetingSlotRequest>
{
    public ValidatorMeetingSlotRequest()
    {
        RuleFor(x => x.SlotTime)
            .NotNull()
            .WithMessage(ValidationMessages.SLOT_TIME_REQUIRED);
        RuleFor(x => x.SlotTime)            
            .GreaterThanOrEqualTo(TimeOnly.MinValue)
            .WithMessage(ValidationMessages.SLOT_TIME_MUST_BE_LESS)
            .LessThanOrEqualTo(TimeOnly.MaxValue)
            .WithMessage(ValidationMessages.SLOT_TIME_MUST_BE_GREATER);
    }
}
