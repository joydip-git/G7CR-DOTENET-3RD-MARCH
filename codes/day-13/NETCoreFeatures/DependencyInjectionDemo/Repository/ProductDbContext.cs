using DependencyInjectionDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace DependencyInjectionDemo.Repository
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {
            Console.WriteLine("db context created..");
        }
        public DbSet<ProductModel> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var productBuilder = modelBuilder.Entity<ProductModel>();
            productBuilder.ToTable("products").HasKey(p => p.Id);
            productBuilder.Property<int>(p => p.Id)
                .HasColumnName("product_id")
                .HasColumnType("int")
                .ValueGeneratedOnAdd()
                .UseIdentityColumn(100, 1)
                .IsRequired();

            productBuilder.Property<string>(p => p.Name)
                .HasColumnType("varchar(50)")
                .HasColumnName("product_name")
                .IsRequired();

            productBuilder.Property<decimal?>(p => p.Price)
                .HasColumnName("product_pricee")
                .HasColumnType("decimal(18,2)")
                .IsRequired(false);

            productBuilder.Property<string?>(p => p.Description)
                .HasColumnType("varchar(max)")
                .HasColumnName("product_desc")
                .IsRequired(false);
        }
    }
}
