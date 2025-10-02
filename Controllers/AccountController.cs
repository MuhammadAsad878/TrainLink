using Microsoft.AspNetCore.Mvc;
using TrainLink.Dtos;
using TrainLink.Constants;
using TrainLink.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using FluentValidation;

namespace TrainLink.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IValidator<LoginRequest> _loginValidator;
        private readonly IValidator<DtoChangePassword> _changePasswordValidator;
        public AccountController(IAccountService accountService, IValidator<LoginRequest> loginValidator, IValidator<DtoChangePassword> changePasswordValidator )
        {
            _accountService = accountService;
            _loginValidator = loginValidator;
            _changePasswordValidator = changePasswordValidator;
        }

        [HttpPost(ApiRoutes.LOGIN)]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginRequest dtoLogin)
        {
            await _loginValidator.ValidateAndThrowAsync(dtoLogin);
            var response = await _accountService.ValidateLoginAsync(dtoLogin);
            if (response is null) return Unauthorized(new {message= ValidationMessages.INVALID_LOGIN_CREDENTIALS });
            return Ok(response);
        }

        [HttpPost(ApiRoutes.CHANGE_PASSWORD)]
        public async Task<IActionResult> ChangePassword([FromBody] DtoChangePassword dto)
        {
            await _changePasswordValidator.ValidateAndThrowAsync(dto);
            var userName = User.Identity?.Name;
            if (string.IsNullOrEmpty(userName)){
                return Unauthorized(new { message = ValidationMessages.UNAUTHORIZED_USER });
            }
            dto.Username = userName;
            var response = await _accountService.ChangePassword(dto);
            if(response == false)
                return BadRequest(new { message = ValidationMessages.SAME_PASSWORD });
            if (response is null)
                return BadRequest(new { message = ValidationMessages.INVALID_PASSWORD_CREDENTIALS });
            return Ok(new { message = ValidationMessages.PASSWORD_CHANGE_SUCCESS });
        }

        [HttpPost(ApiRoutes.LOGOUT)]
        public IActionResult Logout()
        {
            var authToken = Request.Headers["Authorization"].ToString();
            if (string.IsNullOrEmpty(authToken)) return BadRequest(new { message = ValidationMessages.LOGIN_FIRST });
            return Ok(new { message = ValidationMessages.LOGOUT_SUCCESS });
        }
    }
}
