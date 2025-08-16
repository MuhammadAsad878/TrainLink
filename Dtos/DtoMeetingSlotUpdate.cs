namespace TrainLink.Dtos
{
    public class DtoMeetingSlotUpdate
    {
        public int SlotId { get; set; }
        public DateTime SlotDate { get; set; }
        public int IsActive { get; set; }
        public string UpdatedBy { get; set; } = string.Empty;
    }
      
}
