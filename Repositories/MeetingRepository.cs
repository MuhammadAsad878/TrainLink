using Dapper;
using TrainLink.DataAccess;
using System.Data;
using TrainLink.Dtos;
using TrainLink.Repositories.Interfaces;
using TrainLink.Constants;
using TrainLink.Models;
using TrainLink.Entities;

namespace TrainLink.Repositories
{
    public class MeetingRepository : IMeetingRepository
    {
        private readonly DapperContext _dapper;
        public MeetingRepository(DapperContext dapper)
        {
            _dapper = dapper;
        }

        public async Task<DtoMeetingLinkResponse?> CreateMeetingLinkAsync(MeetingLink newLink)
        {
            using var conn = _dapper.CreateConnection();
            var result = await conn.QuerySingleOrDefaultAsync<MeetingLink?>(
                "CreateMeetingLink",
                new { newLink.SlotId, newLink.MeetingUrl, newLink.CreatedBy },
                commandType: CommandType.StoredProcedure
            );
            if (result == null) return null;
            return new DtoMeetingLinkResponse
            {
                LinkId = result.MeetingLinkId,
                SlotId = result.SlotId,
                Url = result.MeetingUrl
            };
        }

        public async Task<DtoMeetingSlotResponse?> CreateMeetingSlotAsync(EntityMeetingSlot dto)
        {
            dto.SlotDate = DateTime.Today.Add(dto.SlotTime.ToTimeSpan());
            using var conn = _dapper.CreateConnection();
            var result = await conn.QuerySingleOrDefaultAsync<DtoMeetingSlot>(
                "CreateMeetingSlot",
                new { dto.SlotDate, dto.CreatedBy },
                commandType: CommandType.StoredProcedure
                );
            if (result == null) return null;
            return new DtoMeetingSlotResponse
            {
                SlotId = result.SlotId,
                SlotTime = result.SlotDate.ToString(Formats.TIME_Format)
            };
        }

        public async Task<bool> DeleteMeetingLinkAsync(MeetingLink deleteLink)
        {
            using var conn = _dapper.CreateConnection();
            var rowsEffected = await conn.QuerySingleAsync<int>(
                "DeleteMeetingLink",
                new { deleteLink.MeetingLinkId, deleteLink.UpdatedBy },
                commandType: CommandType.StoredProcedure
                );
            return rowsEffected > 0;
        }

        public async Task<bool> DeleteMeetingSlotAsync(EntityMeetingSlot delSlot)
        {
            using var conn = _dapper.CreateConnection();
            var result = await conn.QuerySingleAsync<int>(
                "DeleteMeetingSlot",
                new { delSlot.SlotId, delSlot.UpdatedBy },
                commandType: CommandType.StoredProcedure
            );
            return result > 0;
        }

        public async Task<List<DtoMeetingLinkResponse>?> GetMeetingLinksAsync(int? id)
        {
            using var conn = _dapper.CreateConnection();
            if (id is null || id <= 0)
            {
                var result = await conn.QueryAsync<MeetingLink>(
                    "GetActiveMeetingLinks",
                    commandType: CommandType.StoredProcedure
                );
                if (result is null || !result.Any()) return null;
                var newResult = result.Select(x => new DtoMeetingLinkResponse
                {
                    LinkId = x.MeetingLinkId,
                    SlotId = x.SlotId,
                    Url = x.MeetingUrl,
                }).ToList();
                return newResult;
            }
            else
            {
                var result = await conn.QuerySingleOrDefaultAsync<MeetingLink?>(
                    "GetMeetingLinkById",
                    new { @MeetingLinkId = id },
                    commandType: CommandType.StoredProcedure
                );
                if (result is null || result.SlotId <= 0 || result.IsActive == 0) return null;
                return new List<DtoMeetingLinkResponse> {
                   new DtoMeetingLinkResponse
                    {
                        LinkId = result.MeetingLinkId,
                        SlotId = result.SlotId,
                        Url = result.MeetingUrl
                    }
               };
            }
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
                var result = await conn.QueryAsync<DtoMeetingSlot>(
                    "GetActiveMeetingSlots",
                    commandType: CommandType.StoredProcedure
                    );
                if (result is null || !result.Any()) return null;
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

        public async Task<DtoMeetingLinkResponse?> UpdateMeetingLinkAsync(MeetingLink updateLink)
        {
            using var conn = _dapper.CreateConnection();
            var result = await conn.QueryFirstOrDefaultAsync<MeetingLink>(
                "UpdateMeetingLink",
                new { updateLink.MeetingLinkId, updateLink.UpdatedBy, updateLink.MeetingUrl, updateLink.SlotId },
                commandType: CommandType.StoredProcedure
                );
            if (result == null) return null;
            return new DtoMeetingLinkResponse { LinkId = result.MeetingLinkId, SlotId = result.SlotId, Url = result.MeetingUrl };
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
            var updResult = new DtoMeetingSlotResponse
            {
                SlotId = result.SlotId,
                SlotTime = result.SlotDate.ToString(Formats.TIME_Format)
            };
            return updResult ?? null;
        }
    }
}
