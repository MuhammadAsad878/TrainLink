using TrainLink.Dtos;
using TrainLink.Models;

namespace TrainLink.Services.Interfaces
{
    public interface IRoleService
    {
        Task<List<Role>> GetAllRolesAsync();
        Task<Role?> CreateRoleAsync(string role);
        Task<Role?> UpdateRoleAsync(Role role);
    }
}
