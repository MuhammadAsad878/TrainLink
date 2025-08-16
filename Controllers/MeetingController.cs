using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TrainLink.Constants;
using TrainLink.Dtos;
using TrainLink.Services.Interfaces;

namespace TrainLink.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MeetingController : ControllerBase
    {
        private readonly IMeetingService _service;
        public MeetingController(IMeetingService service)
        {
            _service = service;
        }

        [HttpGet("get-meeting-slots")]
        public async Task<IActionResult> GetMeetingSlots([FromQuery] int? id)
        {            
            var result = await _service.GetMeetingSlotsAsync(id);
            if (result == null || result.Count == 0)
            {
                return NotFound(ValidationMessages.MeetingSlotNotFound);
            }
            return Ok(result);
        }

        [HttpPost("create-meeting-slot")]
        public async Task<IActionResult> CreateMeetingSlot([FromBody] DtoMeetingSlotCreate slot)
        {
            var result = await _service.CreateMeetingSlotAsync(slot);
            if (result == null) return BadRequest(ValidationMessages.FailedToCreateMeetingSlot);
            return Ok(result);
        }

        [HttpPut("update-meeting-slot")]
        public async Task<IActionResult> UpdateMeetingSlot([FromBody] DtoMeetingSlotUpdate slot)
        {
            var result = await _service.UpdateMeetingSlotAsync(slot);
            if (result == null) return BadRequest(ValidationMessages.FailedToUpdateMeetingSlot);
            return Ok(result);
        }

        [HttpDelete("delete-slot")]
        public async Task<IActionResult> DeleteMeetingSlot([FromBody] DtoMeetingSlotDelete deleteSlot)
        {
            var result = await _service.DeleteMeetingSlotAsync(deleteSlot);
            if (result == null) return BadRequest(ValidationMessages.MeetingSlotNotFound);
            if (result == false)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                ValidationMessages.FailedToDeleteMeetingSlot);
            }
            return Ok(ValidationMessages.MeetingSlotDeletedSuccessfully);
        }



    }
}
