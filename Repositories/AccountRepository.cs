using Dapper;
using TrainLink.DataAccess;
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
        
    }
}
