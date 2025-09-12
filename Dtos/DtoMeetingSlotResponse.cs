namespace TrainLink.Dtos
{
    public class DtoMeetingSlotResponse
    {
        public int SlotId { get; set; }
        public string SlotTime { get; set; } = string.Empty;
        public int? MeetingLinkId { get; set; }
        public string? MeetingUrl { get; set; }
    }
}
