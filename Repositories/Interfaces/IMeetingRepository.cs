using TrainLink.Dtos;
using TrainLink.Entities;
using TrainLink.Models;

namespace TrainLink.Repositories.Interfaces
{
    public interface IMeetingRepository
    {
        // Slots
        Task<List<DtoMeetingSlotResponse>?> GetMeetingSlotsAsync(int? id);
        Task<DtoMeetingSlotResponse?> CreateMeetingSlotAsync(EntityMeetingSlot newSlot);
        Task<bool> DeleteMeetingSlotAsync(EntityMeetingSlot delSlot);
        Task<DtoMeetingSlot?> GetMeetingSlotByIdAsync(int? slotId);
        // Links
        Task<List<DtoMeetingLinkResponse>?> GetMeetingLinksAsync(int? id);
        Task<DtoMeetingLinkResponse?> CreateMeetingLinkAsync(MeetingLink newLink);
        Task<DtoMeetingLinkResponse?> UpdateMeetingLinkAsync(MeetingLink updateLink);
    }
}
