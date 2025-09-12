namespace TrainLink.Dtos
{
    public class DtoUpdateUser
    {
        public class DtoUserUpdate
        {
            public string? Name { get; set; }
            public string? Mobile { get; set; }
            public int? RoleId { get; set; }
            public DateTime? MembershipExpiry { get; set; }
        }
    }
}
