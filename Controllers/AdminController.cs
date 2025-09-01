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

        
    }
}
