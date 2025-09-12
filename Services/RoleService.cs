using TrainLink.Dtos;
using TrainLink.Models;
using TrainLink.Repositories.Interfaces;
using TrainLink.Services.Interfaces;

namespace TrainLink.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _repo;
        public RoleService(IRoleRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<Role>> GetAllRolesAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<Role?> CreateRoleAsync(string role)
        {
            return await _repo.CreateAsync(role);
        }

        public async Task<Role?> UpdateRoleAsync(Role role)
        {
            return await _repo.UpdateAsync(role);
        }
    }
}
