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
            return result;
        }

        public async Task<bool> UpdatePassword(DtoChangePassword dto)
        {
            using var conn = _context.CreateConnection();
            var result = await conn.ExecuteAsync(
                "UpdatePassword",
                new { Username = dto.Username, NewPassword = dto.NewPassword },
                commandType: CommandType.StoredProcedure
                        );
            return result > 0;
        }
        
        public bool? LogoutUser(string token)
        {
            return token != null;
        }
    }
}
