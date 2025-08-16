using TrainLink.Dtos;

namespace TrainLink.Repositories.Interfaces
{
    public interface IMeetingRepository
    {
        Task<List<DtoMeetingSlotResponse?>> GetMeetingSlotsAsync(int? id);
        Task<DtoMeetingSlotResponse?> CreateMeetingSlotAsync(DtoMeetingSlotCreate meetingSlot);
        Task<DtoMeetingSlotResponse?> UpdateMeetingSlotAsync(DtoMeetingSlotUpdate meetingSlot);
        Task<bool> DeleteMeetingSlotAsync(DtoMeetingSlotDelete delSlot);
        Task<DtoMeetingSlotResponse?> GetMeetingSlotByIdAsync(int slotId);
    }
}
