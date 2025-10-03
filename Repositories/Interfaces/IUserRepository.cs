using TrainLink.Dtos;
using TrainLink.Models;

namespace TrainLink.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<DtoUserResponse>> GetAllAsync(int? id);
        Task<DtoUserResponse?>  CreateAsync(User user);
        Task<DtoUserResponse?> UpdateAsync(DtoUserResponse user, string UpdatedBy);
        Task<bool>  DeleteAsync(User user); 
    }
}
