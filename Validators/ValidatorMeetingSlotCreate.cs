using FluentValidation;
using TrainLink.Constants;

namespace TrainLink.Dtos
{
    public class ValidatorMeetingSlotCreate : AbstractValidator<DtoMeetingSlotCreate>
    {
        public ValidatorMeetingSlotCreate()
        {
            RuleFor(x => x.SlotTime)
                .NotEmpty()
                .WithMessage(ValidationMessages.SLOT_TIME_REQUIRED);

            RuleFor(x => x.SlotTime)
                  .Must(x => TimeOnly.TryParse(x, out var time))
                  .WithMessage(ValidationMessages.SLOT_TIME_MUST_BE);
        }
    }
}
