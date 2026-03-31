namespace AuthServiceApp.Data.Entities
{
    public class RoleEntity
    {
        public int RoleId { get; set; }
        public required string RoleName { get; set; }
        public ICollection<UserEntity> Users { get; set; }
    }
}
