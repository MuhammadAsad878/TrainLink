using FluentValidation;
using TrainLink.Constants;

namespace TrainLink.Dtos
{
    public class ValidatorMeetingSlotCreate : AbstractValidator<DtoMeetingSlotCreate>
    {
        public ValidatorMeetingSlotCreate()
        {
            RuleFor(x => x.SlotDate)
                .NotEmpty()
                .WithMessage(ValidationMessages.MeetingSlotDateRequired)
                .GreaterThan(DateTime.UtcNow)
                .WithMessage(ValidationMessages.MeetingSlotDateFuture);

            RuleFor(x => x.CreatedBy)
                .NotEmpty()
                .WithMessage(ValidationMessages.CreatedByRequired)
                .MaximumLength(ValidationLengths.CreatedByMaxLength)
                .WithMessage($"{ValidationMessages.MaxLengthExceeded} (Max {ValidationLengths.CreatedByMaxLength} characters)");
        }
    }
}
