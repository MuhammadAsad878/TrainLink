using Dapper;
using System.Data;
using TrainLink.Constants;
using TrainLink.DataAccess;
using TrainLink.Dtos;
using TrainLink.Models;
using TrainLink.Repositories.Interfaces;

namespace TrainLink.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly DapperContext _context;

        public AccountRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<User?> GetByUsernameAsync(string username)
        {
            using var conn = _context.CreateConnection();
            var result = await conn.QuerySingleOrDefaultAsync<User>(
                "GetUserByUsername",
                new { Username = username },
                commandType: CommandType.StoredProcedure
                );
            if (result is null) return null;           
            return result;
        }

        public void LogoutUser(string token)
        {
            throw new NotImplementedException();
        }

        public async Task<DtoChangePasswordResponse?> UpdatePassword(DtoChangePassword dto)
        {
            using var conn = _context.CreateConnection();
            var result = await conn.QuerySingleOrDefaultAsync<int>(
                "UpdatePassword",
                commandType: CommandType.StoredProcedure,
                param: new { UserName = dto.Username, NewPassword = dto.NewPassword });
            if (result > 0)
            {
                return new DtoChangePasswordResponse { Username = dto.Username, Success = true, Message = ValidationMessages.PASSWORD_CHANGE_SUCCESS };
            }
            return new DtoChangePasswordResponse { Username = dto.Username, Success = false, Message = ValidationMessages.PASSWORD_CHANGE_FAILED };
        }
    }
}
