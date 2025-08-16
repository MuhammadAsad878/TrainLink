using TrainLink.Dtos;
using TrainLink.Models;

namespace TrainLink.Services.Interfaces
{
    public interface IMeetingService
    {
        Task<List<DtoMeetingSlotResponse?>> GetMeetingSlotsAsync(int? id);
        Task<DtoMeetingSlotResponse?> CreateMeetingSlotAsync(DtoMeetingSlotCreate meetingSlot);
        Task<DtoMeetingSlotResponse?> UpdateMeetingSlotAsync(DtoMeetingSlotUpdate meetingSlot);
        Task<bool?> DeleteMeetingSlotAsync(DtoMeetingSlotDelete deleteSlot);
    }
}
