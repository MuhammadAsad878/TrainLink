using TrainLink.Dtos;
using TrainLink.Helpers;
using TrainLink.Models;
using TrainLink.Repositories.Interfaces;
using TrainLink.Services.Interfaces;

namespace TrainLink.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IAccountRepository _accountRepository;

        public UserService(IUserRepository userRepository, IAccountRepository accountRepository)
        {
            _userRepository = userRepository;
            _accountRepository = accountRepository;
        }

        public async Task<List<DtoUserResponse>> GetAllUsersAsync(int? id)
        {
            return await _userRepository.GetAllAsync(id);
        }

        public async Task<DtoUserResponse?> CreateUserAsync(User user)
        {
            var IsUser = await _accountRepository.GetByUsernameAsync(user.Username);
            if (IsUser != null) return null;
            user.PasswordHash = PasswordHelper.HashPassword(user.PasswordHash);
            return  await _userRepository.CreateAsync(user);            
        }

        public async Task<DtoUserResponse?> UpdateUserAsync(int id, DtoUpdateUser dto, string updatedBy)
        {
            var existingUsers = await _userRepository.GetAllAsync(id);
            var user = existingUsers.FirstOrDefault();
            if (user == null) return null;
            user.Name = !string.IsNullOrWhiteSpace(dto.Name) ? dto.Name : user.Name;
            user.Mobile = !string.IsNullOrWhiteSpace(dto.Mobile) ? dto.Mobile : user.Mobile;
            user.RoleId = dto.RoleId.HasValue ? dto.RoleId.Value : user.RoleId;
            user.PasswordHash = !string.IsNullOrWhiteSpace(dto.Password)
                ? PasswordHelper.HashPassword(dto.Password)
                : user.PasswordHash;
            return await _userRepository.UpdateAsync(user, updatedBy);
        }


        public async Task<bool> DeleteUserAsync(User user)
        {
            var existingUsers = await _userRepository.GetAllAsync(user.Id);
            var existingUser = existingUsers.FirstOrDefault();
            if (existingUser == null) return false;
            return await _userRepository.DeleteAsync(user);
        }

             

      
    }
}
