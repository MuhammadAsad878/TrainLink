using Microsoft.AspNetCore.Mvc;
using TrainLink.Dtos;
using TrainLink.Constants;
using TrainLink.Services.Interfaces;

namespace TrainLink.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService ?? throw new ArgumentNullException(nameof(accountService));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] DtoLogin dtoLogin)
        {
            if (dtoLogin is null) return BadRequest(ValidationMessages.LoginBadRequest);
            var response = await _accountService.ValidateLoginAsync(dtoLogin);
            if (response is null) return Unauthorized(ValidationMessages.InvalidLoginCredentials);
            return Ok(response);
        }

        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] DtoChangePassword dto)
        {
            if(dto is null ) return BadRequest(ValidationMessages.LoginBadRequest);
            var response = await _accountService.ChangePassword(dto);
            if (!response.IsPasswordChanged) return BadRequest(response);
            return Ok(response);
        }

        [HttpPost("logout")]
        public IActionResult Logout([FromBody] string? token)
        {
            if (token is null) return BadRequest(ValidationMessages.LoginFirst);

            return Ok(ValidationMessages.LogoutSuccess);
        }





    }
}
