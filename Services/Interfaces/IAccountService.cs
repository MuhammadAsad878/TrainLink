using TrainLink.Dtos;
using TrainLink.Models;

namespace TrainLink.Services.Interfaces
{
    public interface IAccountService
    {
        Task<DtoLoginResponse?> ValidateLoginAsync(DtoLogin dtoLogin);

    }
}
