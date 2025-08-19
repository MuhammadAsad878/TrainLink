using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TrainLink.Constants;
using TrainLink.Dtos;
using TrainLink.Entities;
using TrainLink.Repositories.Interfaces;
using TrainLink.Services.Interfaces;

namespace TrainLink.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class MeetingController : ControllerBase
    {
        private readonly IMeetingService _service;
        private readonly IMeetingRepository _repository;
        public MeetingController(IMeetingService service,IMeetingRepository repository)
        {
            _service = service;
            _repository = repository;
        }

        [HttpGet(ApiRoutes.GET_SLOTS)]
        public async Task<IActionResult> GetMeetingSlots()
        {
            var result = await _service.GetMeetingSlotsAsync(null);
            if (result == null || result.Count == 0)
            {
                return NotFound(ValidationMessages.MEETING_SLOT_NOT_FOUND);
            }
            return Ok(result);
        }
        

        [HttpGet(ApiRoutes.GET_SLOT_BY_ID)]
        public async Task<IActionResult> GetMeetingSlotsById([FromRoute] int? id)
        {
            var result = await _service.GetMeetingSlotsAsync(id);
            if (result == null || result.Count == 0)
                return NotFound(ValidationMessages.MEETING_SLOT_NOT_FOUND);
            return Ok(result);
        }

        [HttpPost(ApiRoutes.POST_SLOT)]
        public async Task<IActionResult> CreateMeetingSlot([FromBody] DtoMeetingSlotCreate dto)
        {
            var createdBy = User.Identity?.Name;
            if (createdBy == null) return Unauthorized(ValidationMessages.UNAUTHORIZED_USER);
            var newSlot = new EntityMeetingSlot { SlotTime = dto.SlotTime, CreatedBy = createdBy };
            var result = await _service.CreateMeetingSlotAsync(newSlot);
            if (result == null) return BadRequest(ValidationMessages.FAILED_TO_CREATE_MEETING_SLOT);
            return Ok(result);
        }

        [HttpPut(ApiRoutes.PUT_SLOT)]
        public async Task<IActionResult> UpdateMeetingSlot([FromBody] DtoMeetingSlotUpdate slot, [FromRoute] int? id)
        {
            if(id is null || id <= 0) return BadRequest(ValidationMessages.INVALID_MEETING_SLOT_ID);
            var updatedByUser = User.Identity?.Name;
            if (updatedByUser is null) return Unauthorized(ValidationMessages.UNAUTHORIZED_USER);       
            var updateSlot = new EntityMeetingSlot
            {
                SlotId = id,
                SlotTime = slot.SlotTime.ToString(),
                UpdatedBy = updatedByUser
            };
            var result = await _service.UpdateMeetingSlotAsync(updateSlot);
            if (result == null) return BadRequest(ValidationMessages.FAILED_TO_UPDATE_MEETING_SLOT);
            return Ok(result);
        }

        [HttpDelete(ApiRoutes.DELETE_SLOT)]
        public async Task<IActionResult> DeleteMeetingSlot([FromRoute] int slotId)
        { 
            if (slotId <= 0 ) return BadRequest(ValidationMessages.MEETING_SLOT_ID_INVALID);
            var updatedBy = User.Identity?.Name;
            if (updatedBy == null)
            {
                return Unauthorized(ValidationMessages.UNAUTHORIZED_USER);
            }
            var slot = new EntityMeetingSlot { SlotId = slotId, UpdatedBy = updatedBy };
            var result = await _service.DeleteMeetingSlotAsync(slot);
            if (result == null) return BadRequest(ValidationMessages.MEETING_SLOT_NOT_FOUND);
            if (result == true) return Ok(ValidationMessages.MEETING_SLOT_DELETED_SUCCESSFULLY);
            return StatusCode(StatusCodes.Status500InternalServerError,
            ValidationMessages.FAILED_TO_DELETE_MEETING_SLOT);


        }



    }
}
