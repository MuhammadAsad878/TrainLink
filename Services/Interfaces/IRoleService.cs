using TrainLink.Dtos;
using TrainLink.Models;

namespace TrainLink.Services.Interfaces
{
    public interface IRoleService
    {
        Task<List<Role>> GetAllRolesAsync();
        Task<Role?> CreateRoleAsync(DtoRole role);
        Task<Role?> UpdateRoleAsync(DtoRole role);
        Task<bool> DeleteRoleAsync(int roleId);
    }
}
