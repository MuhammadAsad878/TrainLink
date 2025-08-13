namespace TrainLink.Dtos
{
    public class DtoChangePasswordResponse
    {
        public string? Username { get; set; } = string.Empty;
        public bool IsPasswordChanged { get; set; }
        public string Message { get; set; } = string.Empty;
        public DtoChangePasswordResponse(string? username, bool isPasswordChanged, string message)
        {
            Username = username;
            IsPasswordChanged = isPasswordChanged;
            Message = message;
        }
    }
}
