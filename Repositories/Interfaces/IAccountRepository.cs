using TrainLink.Dtos;
using TrainLink.Models;

namespace TrainLink.Repositories.Interfaces
{
    public interface IAccountRepository
    {
        Task<User?> GetByUsernameAsync(string username);
        Task<bool?> UpdatePassword(DtoChangePassword dtoChangePassword);
        bool? LogoutUser(string token);
    }
}
