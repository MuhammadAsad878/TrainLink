using TrainLink.Dtos;
using TrainLink.Entities;
using TrainLink.Models;

namespace TrainLink.Services.Interfaces
{
    public interface IMeetingService
    {
        // Slot Routes
        Task<List<DtoMeetingSlotResponse>> GetMeetingSlotsAsync(int? id);
        Task<DtoMeetingSlotResponse?> CreateMeetingSlotAsync(EntityMeetingSlot slotTime);
        Task<bool?> DeleteMeetingSlotAsync(EntityMeetingSlot deleteSlotId);
        // Link Routes
         Task<List<DtoMeetingLinkResponse>?> GetMeetingLinksAsync(int? id);
         Task<DtoMeetingLinkResponse?> CreateMeetingLinkAsync(MeetingLink newLink);
         Task<DtoMeetingLinkResponse?> UpdateMeetingLinkAsync(MeetingLink updateLink);
    }
}
