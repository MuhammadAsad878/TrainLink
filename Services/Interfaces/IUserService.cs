using TrainLink.Dtos;
using TrainLink.Models;

namespace TrainLink.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<DtoUserResponse>> GetAllUsersAsync(int? id);
        Task<DtoUserResponse?> CreateUserAsync(User user);
        Task<DtoUserResponse?> UpdateUserAsync(User user);
        Task<bool> DeleteUserAsync(User id);
    }
}
