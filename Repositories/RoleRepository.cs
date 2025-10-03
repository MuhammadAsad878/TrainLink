using Dapper;
using TrainLink.DataAccess;
using System.Data;
using TrainLink.Models;
using TrainLink.Repositories.Interfaces;

namespace TrainLink.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly DapperContext _dapper;
        public RoleRepository(DapperContext context)
        {
            _dapper = context;
        }

        public async Task<List<Role>> GetAllAsync()
        {
            using var conn = _dapper.CreateConnection();
            var result = await conn.QueryAsync<Role>(
                "GetAllRoles",
                commandType: CommandType.StoredProcedure
                );
            return result.ToList();
            
        }

        public async Task<Role?> CreateAsync(string name)
        {
            using var conn = _dapper.CreateConnection();
            var result = await conn.QuerySingleOrDefaultAsync<Role>(
                "CreateRole",
                new { Name = name },
                commandType: CommandType.StoredProcedure
                );
            return result;
        }

        
        public async Task<Role?> UpdateAsync(Role role)
        {
            using var conn = _dapper.CreateConnection();
            var result = await conn.QuerySingleOrDefaultAsync<Role>(
                "UpdateRole",
                new { role.Id, role.Name },
                commandType: CommandType.StoredProcedure
                );
            return result;
        }
    }
}
