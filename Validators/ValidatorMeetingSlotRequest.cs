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
            .Must(BeParsedTime)
            .WithMessage(ValidationMessages.SLOT_MUST_BE);        
    }

    private bool BeParsedTime(string slotTime)
    {
        return DateTime.TryParse(slotTime, out _);
    }
}
