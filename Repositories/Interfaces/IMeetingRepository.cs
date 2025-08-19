using TrainLink.Dtos;
using TrainLink.Entities;

namespace TrainLink.Repositories.Interfaces
{
    public interface IMeetingRepository
    {
        Task<List<DtoMeetingSlotResponse>?> GetMeetingSlotsAsync(int? id);
        Task<DtoMeetingSlotResponse?> CreateMeetingSlotAsync(EntityMeetingSlot newSlot);
        Task<DtoMeetingSlotResponse?> UpdateMeetingSlotAsync(EntityMeetingSlot updSlot);
        Task<bool> DeleteMeetingSlotAsync(EntityMeetingSlot delSlot);
        Task<DtoMeetingSlot?> GetMeetingSlotByIdAsync(int? slotId);
    }
}
