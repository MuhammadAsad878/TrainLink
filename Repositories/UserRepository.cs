using Dapper;
using System.Data;
using TrainLink.DataAccess;
using TrainLink.Dtos;
using TrainLink.Models;
using TrainLink.Repositories.Interfaces;

namespace TrainLink.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DapperContext _dapper;

        public UserRepository(DapperContext dapper)
        {
            _dapper = dapper;
        }

        public async Task<List<DtoUserResponse>> GetAllAsync(int? id)
        {
            using var connection = _dapper.CreateConnection();
            if (id.HasValue)
            {
                var user = await connection.QueryFirstOrDefaultAsync<DtoUserResponse>(
                    "GetUserById",
                    new { Id = id.Value },
                    commandType: CommandType.StoredProcedure
                );
                if (user == null)
                {
                    return new List<DtoUserResponse>();
                }
                return new List<DtoUserResponse> { user };
            }
            else
            {
                var users = await connection.QueryAsync<DtoUserResponse>(
                    "GetAllUsers",
                    commandType: CommandType.StoredProcedure
                );
                return users.ToList();
            }
        }

        public async Task<DtoUserResponse?> CreateAsync(User user)
        {
            using var connection = _dapper.CreateConnection();
            var createdUser = await connection.QueryFirstOrDefaultAsync<DtoUserResponse>(
                "CreateUser",
                new
                {
                    user.Username,
                    user.PasswordHash,
                    user.Name,
                    user.Mobile,
                    user.RoleId,
                    user.MembershipExpiry,
                    user.CreatedBy
                },
                commandType: CommandType.StoredProcedure
            );
            return createdUser;
        }

        public async Task<DtoUserResponse?> UpdateAsync(User user)
        {
            using var connection = _dapper.CreateConnection();
            var updatedUser = await connection.QueryFirstOrDefaultAsync<DtoUserResponse>(
                "UpdateUser",
                new
                {
                    user.Id,
                    user.Username,
                    user.PasswordHash,
                    user.Name,
                    user.Mobile,
                    user.RoleId,
                    user.MembershipExpiry,
                    user.UpdatedBy
                },
                commandType: CommandType.StoredProcedure
            );
            return updatedUser;
        }

        public async Task<bool> DeleteAsync(User user)
        {
            using var connection = _dapper.CreateConnection();
            var affectedRows = await connection.QueryFirstOrDefaultAsync<int>(
                "DeleteUser",
                new { user.Id, user.UpdatedBy },
                commandType: CommandType.StoredProcedure
            );
            return affectedRows > 0;
        }
    }
}
