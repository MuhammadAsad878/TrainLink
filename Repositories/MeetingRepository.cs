using Dapper;
using TrainLink.DataAccess;
using System.Data;
using TrainLink.Dtos;
using TrainLink.Repositories.Interfaces;
using TrainLink.Entities;
using TrainLink.Constants;

namespace TrainLink.Repositories
{
    public class MeetingRepository : IMeetingRepository
    {
        private readonly DapperContext _dapper;
        public MeetingRepository(DapperContext dapper)
        {
            _dapper = dapper;
        }

        public async Task<DtoMeetingSlotResponse?> CreateMeetingSlotAsync(EntityMeetingSlot dto)
        {
            var time = TimeOnly.Parse(dto.SlotTime);
            dto.SlotDate = DateTime.Today.Add(time.ToTimeSpan());
            using var conn = _dapper.CreateConnection();
            var result = await conn.QuerySingleOrDefaultAsync<DtoMeetingSlot>(
                "CreateMeetingSlot",
                new { dto.SlotDate, dto.CreatedBy },
                commandType: CommandType.StoredProcedure
                );
            if (result == null) return null;
            return new DtoMeetingSlotResponse { 
            SlotId = result.SlotId,
            SlotTime = result.SlotDate.ToString(Formats.TIME_Format)
            };

        }

        public async Task<bool> DeleteMeetingSlotAsync(EntityMeetingSlot delSlot)
        {
            using var conn = _dapper.CreateConnection();
            var result = await conn.QuerySingleAsync<int>(
                "DeleteMeetingSlot",
                new {  delSlot.SlotId, delSlot.UpdatedBy },
                commandType: CommandType.StoredProcedure
            );
            if (result > 0) return true;
            return false;
        }

        public async Task<DtoMeetingSlot?> GetMeetingSlotByIdAsync(int? slotId)
        {
            if (slotId <= 0) return null;
            using var conn = _dapper.CreateConnection();
            var result = await conn.QueryFirstOrDefaultAsync<DtoMeetingSlot?>(
                "GetMeetingSlotById",
                new { SlotId = slotId },
                commandType: CommandType.StoredProcedure
            );
            if (result == null) return null;
           return result;
        }

        public async Task<List<DtoMeetingSlotResponse>?> GetMeetingSlotsAsync(int? id)
        {
            using var conn = _dapper.CreateConnection();            
            if (id is null || id <= 0)
            {
                var result = await conn.QueryAsync<DtoMeetingSlot?>(
                    "GetActiveMeetingSlots",
                    commandType: CommandType.StoredProcedure
                    );
                if(result is null || !result.Any()) return null;
                var newResult = result.Select(x => new DtoMeetingSlotResponse
                {
                    SlotId = x.SlotId,
                    SlotTime = x.SlotDate.ToLocalTime().ToString(Formats.TIME_Format)
                });
                return newResult?.ToList();
            }
            else
            {
                var result = await conn.QuerySingleOrDefaultAsync<DtoMeetingSlot?>(
                    "GetMeetingSlotById",
                    new { @SlotId = id },
                    commandType: CommandType.StoredProcedure
                );
                if (result == null || result.IsActive == 0) return null;
                var response = new DtoMeetingSlotResponse
                {
                    SlotId = result.SlotId,
                    SlotTime = result.SlotDate.ToString(Formats.TIME_Format)
                };
                return new List<DtoMeetingSlotResponse> { response };
            }
        }

        public async Task<DtoMeetingSlotResponse?> UpdateMeetingSlotAsync(EntityMeetingSlot updSlot)
        {          
            using var conn = _dapper.CreateConnection();
            var result = await conn.QueryFirstOrDefaultAsync<DtoMeetingSlot?>(
                "UpdateMeetingSlot",
                new
                {
                    updSlot.SlotId,
                    updSlot.SlotDate,
                    updSlot.UpdatedBy
                },
                commandType: CommandType.StoredProcedure
            );
            if (result == null) return null;
            var updResult = new DtoMeetingSlotResponse {
                SlotId = result.SlotId,
                SlotTime = result.SlotDate.ToString(Formats.TIME_Format)
            };
            return updResult ?? null;
        }
    }
}
