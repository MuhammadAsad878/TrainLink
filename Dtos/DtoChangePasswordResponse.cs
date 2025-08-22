namespace TrainLink.Dtos
{
    public class DtoChangePasswordResponse
    {
        public string? Username { get; set; } = string.Empty;
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;      
    }
}
