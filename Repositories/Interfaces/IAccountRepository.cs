using TrainLink.Dtos;
using TrainLink.Models;

namespace TrainLink.Repositories.Interfaces
{
    public interface IAccountRepository
    {
        Task<User?> GetByUsernameAsync(string username);
        Task<DtoChangePasswordResponse?> UpdatePassword(DtoChangePassword dtoChangePassword);
        void LogoutUser(string token);

    }
}
