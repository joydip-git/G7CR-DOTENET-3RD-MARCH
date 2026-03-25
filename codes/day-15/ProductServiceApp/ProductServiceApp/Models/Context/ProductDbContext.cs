using ProductServiceApp.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProductServiceApp.Models.Context
{
    public class ProductDbContext(DbContextOptions<ProductDbContext> options) : DbContext(options)
    {
        public DbSet<ProductEntity> ProductEntities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            EntityTypeBuilder<ProductEntity> productBuilder = modelBuilder.Entity<ProductEntity>();

            productBuilder
                .ToTable("products")
                .HasKey(p => p.Id);

            productBuilder
                .Property<int>(p => p.Id)
                .HasColumnName("product_id")
                .HasColumnType("int")
                .ValueGeneratedOnAdd()
                .UseIdentityColumn(100, 1)
                .IsRequired();

            productBuilder
              .Property<string>(p => p.Name)
              .HasColumnName("product_name")
              .HasColumnType("varchar(50)")
              .IsRequired();

            productBuilder
              .Property<string?>(p => p.Description)
              .HasColumnName("product_desc")
              .HasColumnType("varchar(max)")
              .IsRequired(false);

            productBuilder
              .Property<decimal?>(p => p.Price)
              .HasColumnName("product_pricee")
              .HasColumnType("decimal(18,2)")
              .IsRequired(false);
        }
    }
}
