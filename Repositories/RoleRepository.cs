using TrainLink.Dtos;
using TrainLink.Models;
using TrainLink.Repositories.Interfaces;

namespace TrainLink.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        public RoleRepository()
        {
            
        }
        public Task<DtoRoleResponse> CreateAsync(Role role)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Role>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<DtoRoleResponse?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<DtoRoleResponse?> UpdateAsync(Role role)
        {
            throw new NotImplementedException();
        }
    }
}
