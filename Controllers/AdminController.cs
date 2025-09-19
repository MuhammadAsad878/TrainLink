using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
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
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;

        public AdminController(IUserService userService, IRoleService roleService)
        {
            _userService = userService;
            _roleService = roleService;
        }
        // ------------------ USERS ------------------
        [HttpGet(ApiRoutes.GET_USERS)]
        public async Task<IActionResult> GetUsers([FromRoute] int? id)
        {
            var result = await _userService.GetAllUsersAsync(id);
            if (result == null || result.Count == 0)
                return NotFound(new { message = ValidationMessages.USER_NOT_FOUND });
            return Ok(result);
        }

        [HttpPost(ApiRoutes.POST_USER)]
        public async Task<IActionResult> CreateUser([FromBody] DtoCreateUser dto)
        {
            var createdBy = User.Identity?.Name;
            if (createdBy == null) return Unauthorized(new { message = ValidationMessages.UNAUTHORIZED_USER });
            var newUser = new User
            {
                Name = dto.Name,
                Username = dto.Username,
                Mobile = dto.Mobile,
                RoleId = dto.RoleId,
                PasswordHash = dto.Password,
                CreatedBy = createdBy
            };
            var result = await _userService.CreateUserAsync(newUser);
            if (result == null) return BadRequest(new { message = ValidationMessages.USERNAME_ALREADY_EXISTS });
            return Ok(result);
        }

        [HttpPut(ApiRoutes.PUT_USER)]
        public async Task<IActionResult> UpdateUser([FromBody] DtoUpdateUser dto, [FromRoute] int id)
        {
            var updatedBy = User.Identity?.Name;
            if (updatedBy == null) return Unauthorized(new { message= ValidationMessages.UNAUTHORIZED_USER });
            var result = await _userService.UpdateUserAsync(id, dto, updatedBy);
            if (updatedBy == null) return NotFound(new { message = ValidationMessages.USER_NOT_FOUND });
            return Ok(result);
        }


        [HttpDelete(ApiRoutes.DELETE_USER)]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            if (id <= 0) return BadRequest(new { message= ValidationMessages.INVALID_USER_ID });
            var updatedBy = User.Identity?.Name;
            if (updatedBy == null) return Unauthorized(new { message = ValidationMessages.UNAUTHORIZED_USER });
            var user = new User { UpdatedBy = updatedBy, Id = id };
            var result = await _userService.DeleteUserAsync(user);
            if (result == false)
                return NotFound(new { message = ValidationMessages.USER_NOT_FOUND });
            return Ok(new { message = ValidationMessages.USER_DELETED_SUCCESSFULLY });
        }

        // ------------------ ROLES ------------------

        [HttpGet(ApiRoutes.GET_ROLES)]
        public async Task<IActionResult> GetRoles()
        {
            var result = await _roleService.GetAllRolesAsync();
            return Ok(result);
        }

        [HttpPost(ApiRoutes.POST_ROLE)]
        public async Task<IActionResult> CreateRole([FromBody] DtoRole dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Name))
                return BadRequest(new {message= ValidationMessages.ROLE_REQUIRED });
            var result = await _roleService.CreateRoleAsync(dto.Name);
            if (result == null) return BadRequest(new { message = ValidationMessages.ROLE_CREATION_FAILED });
            return Ok(result);
        }

        [HttpPut(ApiRoutes.PUT_ROLE)]
        public async Task<IActionResult> UpdateRole([FromBody] DtoRole dto, [FromRoute] int id)
        {
            if (string.IsNullOrWhiteSpace(dto.Name))
                return BadRequest(new {message= ValidationMessages.ROLE_REQUIRED });
            var role = new Role { Id = id, Name = dto.Name };
            var result = await _roleService.UpdateRoleAsync(role);
            if (result == null) return NotFound(new { message = ValidationMessages.ROLE_NOT_FOUND });
            return Ok(result);
        }
    }
}
