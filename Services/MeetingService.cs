using Microsoft.AspNetCore.Components.Forms;
using TrainLink.Constants;
using TrainLink.Dtos;
using TrainLink.Entities;
using TrainLink.Helpers;
using TrainLink.Models;
using TrainLink.Repositories.Interfaces;
using TrainLink.Services.Interfaces;

namespace TrainLink.Services
{
    public class MeetingService : IMeetingService
    {
        private readonly IMeetingRepository _meetingRepository;
        public MeetingService(IMeetingRepository meetingRepository)
        {
            _meetingRepository = meetingRepository;
        }

        public async Task<DtoMeetingLinkResponse?> CreateMeetingLinkAsync(MeetingLink newLink)
        {
            return await _meetingRepository.CreateMeetingLinkAsync(newLink);
        }

        public async Task<DtoMeetingSlotResponse?> CreateMeetingSlotAsync(EntityMeetingSlot newSlot)
        {
            return await _meetingRepository.CreateMeetingSlotAsync(newSlot);
        }
       
        public async Task<bool?> DeleteMeetingSlotAsync(EntityMeetingSlot delSlot)
        {
            var validate = await _meetingRepository.GetMeetingSlotByIdAsync(delSlot.SlotId);
            if (validate == null || validate.IsActive == 0) return null;
            var result = await _meetingRepository.DeleteMeetingSlotAsync(delSlot);
            return result;
        }

        public async Task<List<DtoMeetingLinkResponse>?> GetMeetingLinksAsync(int? id)
        {
            var result = await _meetingRepository.GetMeetingLinksAsync(id);
            if (result == null || result.Count == 0) return null;
            return result;
        }

        public async Task<List<DtoMeetingSlotResponse>> GetMeetingSlotsAsync(int? id)
        {
            var result = await _meetingRepository.GetMeetingSlotsAsync(id);
            if (result == null || result.Count == 0) return new List<DtoMeetingSlotResponse>();
            return result;
        }

        public async Task<DtoMeetingLinkResponse?> UpdateMeetingLinkAsync(MeetingLink updateLink)
        {
            return await _meetingRepository.UpdateMeetingLinkAsync(updateLink);
        }

      
    }
}
