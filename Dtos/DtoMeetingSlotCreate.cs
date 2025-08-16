namespace TrainLink.Dtos
{
    public class DtoMeetingSlotCreate
    {
        public DateTime SlotDate { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
    }
}
