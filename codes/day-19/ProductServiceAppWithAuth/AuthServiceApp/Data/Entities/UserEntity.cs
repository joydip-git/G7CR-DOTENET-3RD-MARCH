namespace AuthServiceApp.Data.Entities
{
    public class UserEntity
    {
        public required string Email { get; set; }
        public required string UserName { get; set; }
        public required string Password { get; set; }
        public required int RoleId { get; set; }
        public RoleEntity Role { get; set; }
    }
}
