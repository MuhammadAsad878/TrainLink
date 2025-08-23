using TrainLink.Dtos;
using TrainLink.Models;

namespace TrainLink.Services.Interfaces
{
    public interface IAccountService
    {
        Task<LoginResponse?> ValidateLoginAsync(LoginRequest dtoLogin);
        Task<bool?> ChangePassword(DtoChangePassword dtoChangePassword);
        bool? LogoutUser(string token);        
    }
}
