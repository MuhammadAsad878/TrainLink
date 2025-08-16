using Microsoft.AspNetCore.Components.Forms;
using TrainLink.Constants;
using TrainLink.Dtos;
using TrainLink.Helpers;
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

        public async Task<DtoMeetingSlotResponse?> CreateMeetingSlotAsync(DtoMeetingSlotCreate slot)
        {
            if (slot == null) return null;
            return await _meetingRepository.CreateMeetingSlotAsync(slot);

        }

        public async Task<bool?> DeleteMeetingSlotAsync(DtoMeetingSlotDelete? deleteSlot)
        {
            if (deleteSlot == null || deleteSlot.SlotId <= 0) return null;
            var validate = await _meetingRepository.GetMeetingSlotByIdAsync(deleteSlot.SlotId);
            if (validate == null || validate.IsActive == 0) return null;
            var result = await _meetingRepository.DeleteMeetingSlotAsync(deleteSlot);
            return result;

        }

        public async Task<List<DtoMeetingSlotResponse?>> GetMeetingSlotsAsync(int? id)
        {
           var result = await _meetingRepository.GetMeetingSlotsAsync(id);          
            return result;
        }

        public async Task<DtoMeetingSlotResponse?> UpdateMeetingSlotAsync(DtoMeetingSlotUpdate updSlot)
        {
            if (updSlot == null) return null;
            return await _meetingRepository.UpdateMeetingSlotAsync(updSlot);

        }
    }
}
