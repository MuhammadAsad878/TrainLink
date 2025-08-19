using TrainLink.Dtos;
using TrainLink.Entities;
using TrainLink.Models;

namespace TrainLink.Services.Interfaces
{
    public interface IMeetingService
    {
        Task<List<DtoMeetingSlotResponse?>> GetMeetingSlotsAsync(int? id);
        Task<DtoMeetingSlotResponse?> CreateMeetingSlotAsync(EntityMeetingSlot SlotTime);
        Task<DtoMeetingSlotResponse?> UpdateMeetingSlotAsync(EntityMeetingSlot UpdateMeetingSlot);
        Task<bool?> DeleteMeetingSlotAsync(EntityMeetingSlot deleteSlot);
    }
}
