namespace TrainLink.Dtos
{
    public class DtoMeetingSlotDelete
    {
        public int SlotId { get; set; } // The ID of the meeting slot to be deleted
        public string UpdatedBy { get; set; } = string.Empty; // The username of the person deleting the slot
    }
}
