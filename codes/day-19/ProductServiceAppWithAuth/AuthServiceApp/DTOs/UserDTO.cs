namespace AuthServiceApp.DTOs
{
    public class UserDTO
    {
        public required string Email { get; set; }
        public required string UserName { get; set; }
        public required string Password { get; set; }
        public required int RoleId { get; set; }
        public RoleDTO Role { get; set; }
    }
}
