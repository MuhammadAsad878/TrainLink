namespace TrainLink.Models
{
    public class MeetingSlot
    {
        public int SlotId { get; set; } 
        public DateTime SlotDate { get; set; } 
        public int IsActive { get; set; } = 1;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public string CreatedBy { get; set; } = string.Empty;
        public string UpdatedBy { get; set; } = string.Empty;
    }
}
