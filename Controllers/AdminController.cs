using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrainLink.Constants;
using TrainLink.Dtos;
using TrainLink.Entities;
using TrainLink.Models;
using TrainLink.Services.Interfaces;

namespace TrainLink.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = nameof(UserRoles.Admin))]
    public class AdminController : ControllerBase
    {
        private readonly IMeetingService _service;
        public AdminController(IMeetingService service)
        {
            _service = service;
        }

        // Slot Routes
        [HttpPost(ApiRoutes.POST_SLOT)]
        public async Task<IActionResult> CreateMeetingSlot([FromBody] DtoMeetingSlotRequest newSlot)
        {
            var createdBy = User.Identity?.Name;
            if (createdBy == null) return Unauthorized(ValidationMessages.UNAUTHORIZED_USER);
            var slot = new EntityMeetingSlot { SlotTime = newSlot.SlotTime, CreatedBy = createdBy };
            var result = await _service.CreateMeetingSlotAsync(slot);
            if (result == null) return NotFound(ValidationMessages.FAILED_TO_CREATE_MEETING_SLOT);
            return Ok(result);
        }

        [HttpPut(ApiRoutes.PUT_SLOT)]
        public async Task<IActionResult> UpdateMeetingSlot([FromBody] DtoMeetingSlotRequest oldSlot, [FromRoute] int putId)
        {
            if (putId <= 0) return BadRequest(ValidationMessages.INVALID_MEETING_SLOT_ID);
            var updatedByUser = User.Identity?.Name;
            if (updatedByUser is null) return Unauthorized(ValidationMessages.UNAUTHORIZED_USER);
            var updateSlot = new EntityMeetingSlot
            {
                SlotId = putId,
                SlotTime = oldSlot.SlotTime,
                UpdatedBy = updatedByUser
            };
            var result = await _service.UpdateMeetingSlotAsync(updateSlot);
            if (result == null) return NotFound(ValidationMessages.MEETING_SLOT_NOT_FOUND);
            return Ok(result);
        }

        [HttpDelete(ApiRoutes.DELETE_SLOT)]
        public async Task<IActionResult> DeleteMeetingSlot([FromRoute] int? delId)
        {
            if (delId <= 0) return BadRequest(ValidationMessages.MEETING_SLOT_ID_INVALID);
            var updatedBy = User.Identity?.Name;
            if (updatedBy == null)
                return Unauthorized(ValidationMessages.UNAUTHORIZED_USER);
            var slot = new EntityMeetingSlot { SlotId = delId, UpdatedBy = updatedBy };
            var result = await _service.DeleteMeetingSlotAsync(slot);
            if (result == true) return Ok(ValidationMessages.MEETING_SLOT_DELETED_SUCCESSFULLY);
            return NotFound(ValidationMessages.MEETING_SLOT_NOT_FOUND);           
        }

        // Link Routes
        [HttpPost(ApiRoutes.POST_LINK)]
        public async Task<IActionResult> CreateLink([FromBody] DtoMeetingLinkRequest dto)
        {
            var user = User.Identity?.Name;
            if (user is null) return Unauthorized(ValidationMessages.UNAUTHORIZED_USER);
            var newLink = new MeetingLink
            {
                SlotId = dto.SlotId,
                MeetingUrl = dto.MeetingUrl,
                CreatedBy = user
            };
            var result = await _service.CreateMeetingLinkAsync(newLink);
            if (result == null)
                return BadRequest(ValidationMessages.MEETING_SLOT_NOT_FOUND);
            return Ok(result);
        }

        [HttpPut(ApiRoutes.PUT_LINK)]
        public async Task<IActionResult> UpdateLink([FromBody] DtoMeetingLinkRequest dto, [FromRoute] int putId)
        {
            if (putId <= 0) return BadRequest(ValidationMessages.MEETING_LINK_ID_INVALID);
            var user = User.Identity?.Name;
            if (user is null) return Unauthorized(ValidationMessages.UNAUTHORIZED_USER);
            var updateLink = new MeetingLink
            {
                MeetingLinkId = putId,
                SlotId = dto.SlotId,
                MeetingUrl = dto.MeetingUrl,
                UpdatedBy = user
            };
            var result = await _service.UpdateMeetingLinkAsync(updateLink);
            if (result == null) return NotFound(ValidationMessages.MEETING_LINK_NOT_FOUND);
            return Ok(result);
        }

        [HttpDelete(ApiRoutes.DELETE_LINK)]
        public async Task<IActionResult> DeleteLink(int delId)
        {
            if (delId <= 0) return BadRequest(ValidationMessages.MEETING_LINK_ID_INVALID);
            var user = User.Identity?.Name;
            if (user is null) return Unauthorized(ValidationMessages.UNAUTHORIZED_USER);
            var link = new MeetingLink { MeetingLinkId = delId, UpdatedBy = user };
            var isDeleted = await _service.DeleteMeetingLinkAsync(link);
            if (isDeleted == true) return Ok(ValidationMessages.MEETING_LINK_DELETED_SUCCESSFULLY);
            return NotFound(ValidationMessages.MEETING_LINK_NOT_FOUND);
        }
    }
}
