using TrainLink.Models;
namespace TrainLink.Dtos
{
    public class LoginResponse
    {
        public string Username { get; init; } = string.Empty;
        public string Token { get; init; } = string.Empty;        
    }
}
