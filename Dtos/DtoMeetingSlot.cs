namespace TrainLink.Dtos
{
    public class DtoMeetingSlot
    {
        public int SlotId { get; set; }
        public DateTime SlotDate { get; set; }
        public int IsActive { get; set; } 
        public int? MeetingLinkId { get; set; }
        public string? MeetingUrl { get; set; }
    }
}
