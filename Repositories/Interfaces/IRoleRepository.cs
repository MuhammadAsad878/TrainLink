using TrainLink.Dtos;
using TrainLink.Models;

namespace TrainLink.Repositories.Interfaces
{
    public interface IRoleRepository
    {
        Task<DtoRoleResponse?> GetByIdAsync(int id);
        Task<List<Role>> GetAllAsync();
        Task<DtoRoleResponse> CreateAsync(Role role);
        Task<DtoRoleResponse?> UpdateAsync(Role role);
        Task<bool> DeleteAsync(int id);
    }
}
