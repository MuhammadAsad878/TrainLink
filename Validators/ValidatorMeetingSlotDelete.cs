using FluentValidation;
using TrainLink.Constants;
using TrainLink.Dtos;

public class ValidatorMeetingSlotDelete : AbstractValidator<DtoMeetingSlotDelete>
{
    public ValidatorMeetingSlotDelete()
    {
        RuleFor(x => x.SlotId)
            .NotEmpty()
            .WithMessage(ValidationMessages.SLOT_ID_REQUIRED);

        RuleFor(x => x.SlotId)
            .GreaterThan(0)
            .WithMessage(ValidationMessages.MUST_BE_POSITIVE);

       
    }
}
