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
        public MeetingController(IMeetingService service)
        {
            _service = service;
        }

        // Slot Routes
        [HttpGet(ApiRoutes.GET_SLOTS)]
        public async Task<IActionResult> GetMeetingSlots([FromRoute] int? id)
        {
            var result = await _service.GetMeetingSlotsAsync(id);
            if (result == null || result.Count == 0)
                return NotFound(ValidationMessages.MEETING_SLOT_NOT_FOUND);
            return Ok(result);
        }       

        // Link Routes
        [HttpGet(ApiRoutes.GET_LINKS)]
        public async Task<IActionResult> GetLinks([FromRoute] int? id)
        {
            if (id <= 0) return BadRequest(ValidationMessages.MEETING_LINK_ID_INVALID);
            var result = await _service.GetMeetingLinksAsync(id);
            if (result == null) return NotFound(ValidationMessages.MEETING_LINK_NOT_FOUND);
            return Ok(result);
        }       
    }
}
