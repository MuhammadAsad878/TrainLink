using FluentValidation;
using TrainLink.Constants;
using TrainLink.Dtos;

public class ValidatorMeetingSlotUpdate : AbstractValidator<DtoMeetingSlotUpdate>
{
    public ValidatorMeetingSlotUpdate()
    {
        

        RuleFor(x => x.SlotTime)
            .Must(t => t != default)  // Prevent "00:00" if not allowed
            .WithMessage(ValidationMessages.SLOT_TIME_MUST_BE);

       
    }
}
