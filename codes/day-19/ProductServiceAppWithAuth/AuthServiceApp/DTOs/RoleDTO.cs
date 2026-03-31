namespace AuthServiceApp.DTOs
{
    public class RoleDTO
    {
        public int RoleId { get; set; }
        public required string RoleName { get; set; }
        public ICollection<UserDTO> Users { get; set; }
    }
}
