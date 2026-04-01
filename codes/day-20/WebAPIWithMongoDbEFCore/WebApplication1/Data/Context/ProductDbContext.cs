using Microsoft.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;
using WebApplication1.Data.Entities;
using MongoDB.Bson;

namespace WebApplication1.Data.Context
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var productBuilder = modelBuilder.Entity<Product>();
            productBuilder
                .ToCollection("products")
                .HasKey(p => p.ProductId);

            productBuilder
                .Property<int>(p => p.ProductId)
                .HasBsonRepresentation(BsonType.Int32)
                .HasElementName("_id")
                .IsRequired();

            productBuilder
               .Property<string>(p => p.ProductName)
               .HasBsonRepresentation(BsonType.String)
               .HasElementName("productname")
               .IsRequired();

            productBuilder
               .Property<decimal?>(p => p.Price)
               .HasBsonRepresentation(BsonType.Decimal128)
               .HasElementName("price")
               .IsRequired();

            productBuilder
               .Property<string?>(p => p.Description)
               .HasBsonRepresentation(BsonType.String)
               .HasElementName("description")
               .IsRequired();
        }
    }
}
