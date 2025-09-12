using TrainLink.Dtos;
using TrainLink.Models;

namespace TrainLink.Repositories.Interfaces
{
    public interface IRoleRepository
    {
        Task<List<Role>> GetAllAsync();
        Task<Role?> CreateAsync(string name);
        Task<Role?> UpdateAsync(Role role);
    }
}
