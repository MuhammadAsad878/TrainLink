using Dapper;
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
            const string sql = @"SELECT TOP 1 Id, Username, PasswordHash, Name, Mobile, RoleId,
                                    MembershipExpiry, CreatedAt, UpdatedAt
                             FROM Users WHERE Username = @Username;";
            using var conn = _context.CreateConnection();
            return await conn.QuerySingleOrDefaultAsync<User>(sql, new { Username = username });
        }

        public void LogoutUser(string token)
        {
            throw new NotImplementedException();
        }

        public async Task<DtoChangePasswordResponse?> UpdatePassword(DtoChangePassword dto)
        {
            const string sql = @"UPDATE Users SET PasswordHash = @NewPassword WHERE Username= @Username";
            using var conn = _context.CreateConnection();
            var res =  await conn.ExecuteAsync(sql, new { NewPassword = dto.NewPassword, Username = dto.Username });
            if (res > 0)
            {
                return new DtoChangePasswordResponse(dto.Username, true, ValidationMessages.PasswordChangeSuccess);
            }
            return new DtoChangePasswordResponse(dto.Username,false,ValidationMessages.PasswordChangeFailed);
        }
    }
}
