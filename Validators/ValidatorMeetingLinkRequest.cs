using FluentValidation;
using TrainLink.Constants;
using TrainLink.Dtos;

namespace TrainLink.Validators
{
    public class ValidatorMeetingLinkRequest  : AbstractValidator<DtoMeetingLinkRequest>
    {
        public ValidatorMeetingLinkRequest()
        {
            RuleFor(x => x.SlotId)
                .NotEmpty()
                .WithMessage(ValidationMessages.SLOT_ID_REQUIRED);
            RuleFor(x => x.MeetingUrl)
                .NotEmpty()
                .WithMessage(ValidationMessages.MEETING_URL_REQUIRED);
            RuleFor(x => x.MeetingUrl)
                .Matches(RegexPatterns.VALID_URL)
                .WithMessage(ValidationMessages.MEETING_URL_INVALID);
        }
    }    
}
