using Microsoft.AspNetCore.Mvc;
using TrainLink.Dtos;
using TrainLink.Constants;
using TrainLink.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace TrainLink.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost(ApiRoutes.LOGIN)]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginRequest dtoLogin)
        {
            var response = await _accountService.ValidateLoginAsync(dtoLogin);
            if (response is null) return Unauthorized(new {message= ValidationMessages.INVALID_LOGIN_CREDENTIALS });
            return Ok(response);
        }

        [HttpPost(ApiRoutes.CHANGE_PASSWORD)]
        public async Task<IActionResult> ChangePassword([FromBody] DtoChangePassword dto)
        {
            var response = await _accountService.ChangePassword(dto);
            if (response is null || response == false)
                return BadRequest(ValidationMessages.INVALID_LOGIN_CREDENTIALS);
            return Ok(ValidationMessages.PASSWORD_CHANGE_SUCCESS);
        }

        [HttpPost(ApiRoutes.LOGOUT)]
        public IActionResult Logout([FromBody] string? token)
        {
            if (token is null) return BadRequest(ValidationMessages.LOGIN_FIRST);
            return Ok(ValidationMessages.LOGOUT_SUCCESS);
        }
    }
}
