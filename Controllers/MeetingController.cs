using FluentValidation;
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
    [Authorize]
    public class MeetingController : ControllerBase
    {
        private readonly IMeetingService _service;
        private readonly IValidator<DtoMeetingSlotRequest> _slotRequestValidator;
        private readonly IValidator<DtoMeetingLinkRequest> _linkRequestValidator;
        public MeetingController(
            IMeetingService service,
            IValidator<DtoMeetingSlotRequest> slotRequestValidator,
            IValidator<DtoMeetingLinkRequest> linkRequestValidator)
        {
            _service = service;
            _slotRequestValidator = slotRequestValidator;
            _linkRequestValidator = linkRequestValidator;
        }

        // Slot Routes
        [HttpGet(ApiRoutes.GET_SLOTS)]
        public async Task<IActionResult> GetMeetingSlots([FromRoute] int? id)
        {
            var result = await _service.GetMeetingSlotsAsync(id);
            if (result == null || result.Count == 0) {            
                return NotFound(new { message = ValidationMessages.MEETING_SLOT_NOT_FOUND });
            }
            return Ok(result);
        }

        [HttpPost(ApiRoutes.POST_SLOT)]
        [Authorize(Roles = nameof(UserRoles.Admin))]
        public async Task<IActionResult> CreateMeetingSlot([FromBody] DtoMeetingSlotRequest newSlot)
        {
             await _slotRequestValidator.ValidateAndThrowAsync(newSlot);
            var parsedTime = TimeOnly.Parse(newSlot.SlotTime);
            var createdBy = User.Identity?.Name;
            if (createdBy == null)
                return Unauthorized(new { message = ValidationMessages.UNAUTHORIZED_USER });
            var slot = new EntityMeetingSlot { SlotTime = parsedTime, CreatedBy = createdBy };
            var result = await _service.CreateMeetingSlotAsync(slot);
            if (result == null)
                return NotFound(new { message = ValidationMessages.FAILED_TO_CREATE_MEETING_SLOT });
            return Ok(new {message=ValidationMessages.MEETING_SLOT_CREATED_SUCCESSFULLY, response= result});
        }        

        [HttpDelete(ApiRoutes.DELETE_SLOT)]
        [Authorize(Roles = nameof(UserRoles.Admin))]
        public async Task<IActionResult> DeleteMeetingSlot([FromRoute] int? id)
        {
            if (id <= 0)
                return BadRequest(new { message = ValidationMessages.MEETING_SLOT_ID_INVALID });
            var updatedBy = User.Identity?.Name;
            if (updatedBy == null)
                return Unauthorized(new { message = ValidationMessages.UNAUTHORIZED_USER });
            var slot = new EntityMeetingSlot { SlotId = id, UpdatedBy = updatedBy };
            var result = await _service.DeleteMeetingSlotAsync(slot);
            if (result == true)
                return Ok(new { message = ValidationMessages.MEETING_SLOT_DELETED_SUCCESSFULLY });
            return NotFound(new { message = ValidationMessages.MEETING_SLOT_NOT_FOUND });
        }

        // Link Routes
        [HttpGet(ApiRoutes.GET_LINKS)]
        public async Task<IActionResult> GetLinks([FromRoute] int? id)
        {
            if (id <= 0)
                return BadRequest(new { message = ValidationMessages.MEETING_LINK_ID_INVALID });
            var result = await _service.GetMeetingLinksAsync(id);
            if (result == null)
                return NotFound(new { message = ValidationMessages.MEETING_LINK_NOT_FOUND });
            return Ok(result);
        }

        [HttpPost(ApiRoutes.POST_LINK)]
        [Authorize(Roles = $"{nameof(UserRoles.Admin)},{nameof(UserRoles.Trainer)}")]
        public async Task<IActionResult> CreateLink([FromBody] DtoMeetingLinkRequest dto)
        {
            await _linkRequestValidator.ValidateAndThrowAsync(dto);
            var user = User.Identity?.Name;
            if (user is null)
                return Unauthorized(new { message = ValidationMessages.UNAUTHORIZED_USER });
            var newLink = new MeetingLink
            {
                SlotId = dto.SlotId,
                MeetingUrl = dto.MeetingUrl,
                CreatedBy = user
            };
            var result = await _service.CreateMeetingLinkAsync(newLink);
            if (result == null)
                return BadRequest(new { message = ValidationMessages.MEETING_LINK_NOT_FOUND });
            return Ok(new { message = ValidationMessages.MEETING_LINK_CREATED_SUCCESSFULLY, response = result });
        }

        [HttpPut(ApiRoutes.PUT_LINK)]
        [Authorize(Roles = $"{nameof(UserRoles.Admin)},{nameof(UserRoles.Trainer)}")]
        public async Task<IActionResult> UpdateLink([FromBody] DtoMeetingLinkRequest dto, [FromRoute] int id)
        {
            await _linkRequestValidator.ValidateAndThrowAsync(dto);
            if (id <= 0)
                return BadRequest(new { message = ValidationMessages.MEETING_LINK_ID_INVALID });
            var user = User.Identity?.Name;
            if (user is null)
                return Unauthorized(new { message = ValidationMessages.UNAUTHORIZED_USER });
            var updateLink = new MeetingLink
            {
                MeetingLinkId = id,
                SlotId = dto.SlotId,
                MeetingUrl = dto.MeetingUrl,
                UpdatedBy = user
            };
            var result = await _service.UpdateMeetingLinkAsync(updateLink);
            if (result == null)
                return NotFound(new { message = ValidationMessages.MEETING_LINK_NOT_FOUND });
            return Ok(new { message = ValidationMessages.MEETING_LINK_UPDATED_SUCCESSFULLY, response = result });
        }        
    }
}
