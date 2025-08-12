namespace TrainLink.Models
{
    public class User
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public int RoleId { get; set; }
        public DateTime? MembershipExpiry { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
