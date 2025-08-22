namespace TrainLink.Models
{
    public class MeetingLink
    {
        public int MeetingLinkId { get; set; }
        public int SlotId { get; set; }
        public string MeetingUrl { get; set; } = string.Empty;
        public int IsActive { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public string UpdatedBy { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
