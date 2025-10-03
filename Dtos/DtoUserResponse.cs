namespace TrainLink.Dtos
{
    public class DtoUserResponse
    {
        public long Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Mobile { get; set; } = string.Empty;
        public int RoleId { get; set; }
        public string RoleName { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
    }
}
