using TrainLink.Dtos;
using TrainLink.Models;
using TrainLink.Services.Interfaces;

namespace TrainLink.Services
{
    public class RoleService : IRoleService
    {
        public Task<Role?> CreateRoleAsync(DtoRole role)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteRoleAsync(int roleId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Role>> GetAllRolesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Role?> UpdateRoleAsync(DtoRole role)
        {
            throw new NotImplementedException();
        }
    }
}
