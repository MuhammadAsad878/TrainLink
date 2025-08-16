using Dapper;
using TrainLink.DataAccess;
using System.Data;
using TrainLink.Dtos;
using TrainLink.Repositories.Interfaces;

namespace TrainLink.Repositories
{
    public class MeetingRepository : IMeetingRepository
    {
        private readonly DapperContext _dapper;
        public MeetingRepository(DapperContext dapper)
        {
            _dapper = dapper;
        }

        public async Task<DtoMeetingSlotResponse?> CreateMeetingSlotAsync(DtoMeetingSlotCreate slot)
        {
            using var conn = _dapper.CreateConnection();
            var result = await conn.QuerySingleOrDefaultAsync<DtoMeetingSlotResponse>(
                "CreateMeetingSlot",
                new { slot.SlotDate, slot.CreatedBy, },
                commandType: CommandType.StoredProcedure
                );
            if (result == null) return null;
            return result;

        }

        public async Task<bool> DeleteMeetingSlotAsync(DtoMeetingSlotDelete delSlot)
        {
            using var conn = _dapper.CreateConnection();
            var result = await conn.QuerySingleAsync<int>(
                "DeleteMeetingSlot",
                new { SlotId = delSlot.SlotId, UpdatedBy = delSlot.UpdatedBy },
                commandType: CommandType.StoredProcedure
            );
            if (result > 0) return true;
            return false;
        }

        public async Task<DtoMeetingSlotResponse?> GetMeetingSlotByIdAsync(int slotId)
        {
            if (slotId <= 0) return null;
            using var conn = _dapper.CreateConnection();
            var result = await conn.QueryFirstOrDefaultAsync<DtoMeetingSlotResponse?>(
                "GetMeetingSlotById",
                new { SlotId = slotId },
                commandType: CommandType.StoredProcedure
            );
            if (result == null) return null;
            return new DtoMeetingSlotResponse
            {
                SlotId = result.SlotId,
                SlotDate = result.SlotDate,
                IsActive = result.IsActive,
            };
        }

        public async Task<List<DtoMeetingSlotResponse?>> GetMeetingSlotsAsync(int? id)
        {
            if (id is null || id <= 0)
            {
                using var conn = _dapper.CreateConnection();
                var result = await conn.QueryAsync<DtoMeetingSlotResponse?>(
                    "GetActiveMeetingSlots",
                    commandType: CommandType.StoredProcedure
                    );
                result.ToList();
                return result?.ToList() ?? new List<DtoMeetingSlotResponse?>();
            }
            else
            {
                using var conn = _dapper.CreateConnection();
                var result = await conn.QuerySingleOrDefaultAsync<DtoMeetingSlotResponse?>(
                    "GetMeetingSlotById",
                    new { @SlotId = id },
                    commandType: CommandType.StoredProcedure
                );
                if (result == null || result.IsActive == 0) return new List<DtoMeetingSlotResponse?>();
                return new List<DtoMeetingSlotResponse?> { result };
            }


        }

        public async Task<DtoMeetingSlotResponse?> UpdateMeetingSlotAsync(DtoMeetingSlotUpdate meetingSlot)
        {
            using var conn = _dapper.CreateConnection();
            var result = await conn.QueryFirstOrDefaultAsync<DtoMeetingSlotResponse?>(
                "UpdateMeetingSlot",
                new
                {
                    meetingSlot.SlotId,
                    meetingSlot.SlotDate,
                    meetingSlot.IsActive,
                    meetingSlot.UpdatedBy
                },
                commandType: CommandType.StoredProcedure
            );
            return result ?? null;
        }
    }
}
