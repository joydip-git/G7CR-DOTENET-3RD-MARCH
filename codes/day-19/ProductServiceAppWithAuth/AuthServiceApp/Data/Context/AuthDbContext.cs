using AuthServiceApp.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuthServiceApp.Data.Context
{
    public class AuthDbContext : DbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> contextOptions) : base(contextOptions)
        {

        }

        public DbSet<UserEntity> Users { get; set; }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("server=.\\sqlexpress; database=authdb; integrated security=true; trust server certificate=true");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var roleBuilder = modelBuilder.Entity<RoleEntity>();
            roleBuilder.ToTable("users_roles").HasKey(u => u.RoleId);

            roleBuilder
                .Property<int>(r => r.RoleId)
                .HasColumnName("role_id")
                .HasColumnType("int")
                .ValueGeneratedOnAdd()
                .UseIdentityColumn(100, 1)
                .IsRequired();


            roleBuilder
                .Property<string>(u => u.RoleName)
                .HasColumnName("role_name")
                .HasColumnType("varchar(20)")
                .IsRequired();

            var userBuilder = modelBuilder.Entity<UserEntity>();
            userBuilder.ToTable("users").HasKey(u => u.Email);

            userBuilder
                .Property<string>(u => u.Email)
                .HasColumnName("email")
                .HasColumnType("varchar(50)")
                .IsRequired();

            userBuilder
                .Property<string>(u => u.UserName)
                .HasColumnName("username")
                .HasColumnType("varchar(50)")
                .IsRequired();

            userBuilder
                .Property<string>(u => u.Password)
                .HasColumnName("password")
                .HasColumnType("varchar(12)")
                .IsRequired();

            userBuilder
                .Property<int>(u => u.RoleId)
                .HasColumnName("role_id")
                .HasColumnType("int")
                .IsRequired();

            userBuilder
                .HasOne<RoleEntity>(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId);
        }
    }
}
