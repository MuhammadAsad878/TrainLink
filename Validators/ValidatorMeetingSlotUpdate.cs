using FluentValidation;
using TrainLink.Constants;
using TrainLink.Dtos;

public class ValidatorMeetingSlotUpdate : AbstractValidator<DtoMeetingSlotUpdate>
{
    public ValidatorMeetingSlotUpdate()
    {
        RuleFor(x => x.SlotId)
            .GreaterThan(0)
            .WithMessage(ValidationMessages.MeetingSlotIdInvalid);

        RuleFor(x => x.SlotDate)
            .NotEmpty()
            .WithMessage(ValidationMessages.MeetingSlotDateRequired);

        RuleFor(x => x.IsActive)
            .InclusiveBetween(0, 1)
            .WithMessage(ValidationMessages.MeetingSlotIsActiveInvalid);

        RuleFor(x => x.UpdatedBy)
            .NotEmpty()
            .WithMessage(ValidationMessages.UpdatedByRequired);
    }
}
