namespace TrainLink.Dtos
{
    public class DtoCreateUser
    {
            public string Username { get; set; } = string.Empty;
            public string Password { get; set; } = string.Empty; 
            public string Name { get; set; } = string.Empty;
            public string Mobile { get; set; } = string.Empty;
            public int RoleId { get; set; }
            public DateTime? MembershipExpiry { get; set; }
    }
}
