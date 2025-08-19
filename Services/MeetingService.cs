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

        public async Task<DtoMeetingSlotResponse?> CreateMeetingSlotAsync(EntityMeetingSlot newSlot)
        {
            if (newSlot is null || newSlot.CreatedBy is null) return null;
            return await _meetingRepository.CreateMeetingSlotAsync(newSlot);
        }

        public async Task<bool?> DeleteMeetingSlotAsync(EntityMeetingSlot delSlot)
        {
            if (delSlot == null || delSlot.SlotId <= 0) return null;
            var validate = await _meetingRepository.GetMeetingSlotByIdAsync(delSlot.SlotId);
            if (validate == null || validate.IsActive == 0) return null;
            var result = await _meetingRepository.DeleteMeetingSlotAsync(delSlot);
            return result;

        }

        public async Task<List<DtoMeetingSlotResponse?>> GetMeetingSlotsAsync(int? id)
        {
           var result = await _meetingRepository.GetMeetingSlotsAsync(id);          
            return result;
        }

        public async Task<DtoMeetingSlotResponse?> UpdateMeetingSlotAsync(EntityMeetingSlot updSlot)
        {
            if (updSlot == null || updSlot.SlotId == null) return null;
            var validate = await _meetingRepository.GetMeetingSlotByIdAsync(updSlot.SlotId);
            if (validate == null || validate.IsActive == 0) return null;
            var time = TimeOnly.Parse(updSlot.SlotTime);
            updSlot.SlotDate = DateOnly.FromDateTime(DateTime.Now).ToDateTime(time);
            return await _meetingRepository.UpdateMeetingSlotAsync(updSlot);

        }
    }
}
