using TrainLink.Models;
namespace TrainLink.Dtos
{
    public class DtoLoginResponse
    {
        public string Username { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;

        public DtoLoginResponse(string username,string token)
        {
            Username = username;
            Token = token;
        }
    }
}
