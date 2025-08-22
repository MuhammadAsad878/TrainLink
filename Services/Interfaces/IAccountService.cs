using TrainLink.Dtos;
using TrainLink.Models;

namespace TrainLink.Services.Interfaces
{
    public interface IAccountService
    {
        Task<LoginResponse?> ValidateLoginAsync(LoginRequest dtoLogin);
        Task<DtoChangePasswordResponse?> ChangePassword(DtoChangePassword dtoChangePassword);
        void LogoutUser(string token);

    }
}
