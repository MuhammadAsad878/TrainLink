namespace TrainLink.Entities
{
    public class EntityMeetingSlot
    {
        public int? SlotId { get; set; }
        public DateTime SlotDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public string SlotTime { get;set; } = string.Empty;
    }
}
