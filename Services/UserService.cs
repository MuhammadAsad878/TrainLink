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

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<DtoUserResponse>> GetAllUsersAsync(int? id)
        {
            return await _userRepository.GetAllAsync(id);
        }

        public async Task<DtoUserResponse?> CreateUserAsync(User user)
        {
            user.PasswordHash = PasswordHelper.HashPassword(user.PasswordHash);
            return  await _userRepository.CreateAsync(user);            
        }

        public async Task<DtoUserResponse?> UpdateUserAsync(User user)
        {
            var existingUsers = await _userRepository.GetAllAsync(user.Id);
            var existingUser = existingUsers.FirstOrDefault();
            if (existingUser == null) return null;
            user.PasswordHash = PasswordHelper.HashPassword(user.PasswordHash);
            return await _userRepository.UpdateAsync(user);
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
