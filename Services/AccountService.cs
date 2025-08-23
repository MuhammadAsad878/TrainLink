using Microsoft.AspNetCore.Components.Forms;
using TrainLink.Constants;
using TrainLink.Dtos;
using TrainLink.Helpers;
using TrainLink.Repositories.Interfaces;
using TrainLink.Services.Interfaces;

namespace TrainLink.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _account;
        private readonly IConfiguration _config;

        public AccountService(IAccountRepository account, IConfiguration config)
        {
            _account = account;
            _config = config;
        }

        public async Task<LoginResponse?> ValidateLoginAsync(LoginRequest dto)
        {
            var user = await _account.GetByUsernameAsync(dto.Username);
            if (user is null) return null;          
            var ok = PasswordHelper.VerifyPassword(dto.Password, user.PasswordHash);
            if(!ok) return null;
            var token = JwtHelper.GenerateJwtToken(user,_config);
            return new LoginResponse { 
                Username=user.Username,
                Token=token
            };               
           
        }

        public async Task<bool?> ChangePassword(DtoChangePassword dto)
        {
            var user = await _account.GetByUsernameAsync(dto.Username);
            if (user == null) return null;
            var isVerified = PasswordHelper.VerifyPassword(dto.OldPassword, user.PasswordHash);
            if (!isVerified) return false;
            dto.NewPassword = PasswordHelper.HashPassword(dto.NewPassword);
            return await _account.UpdatePassword(dto);
        }

        public bool? LogoutUser(string token)
        {
            return null;
        }
    }
}
