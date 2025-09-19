namespace TrainLink.Dtos
{
    public class DtoUpdateUser
    {
        public int Id { get; set; }
        public string? Name { get; set; } = null;
        public string? Mobile { get; set; } = null;
        public int? RoleId { get; set; } = null;
        public string? Password { get; set; } = null;
    }
}
