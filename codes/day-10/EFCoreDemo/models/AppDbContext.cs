using System.Data.Common;
using EFCoreDemo.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

//public class AppDbContext(string connectionString):DbContext
public class AppDbContext : DbContext
{
    //private readonly string connectionString = connectionString;
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }

    //Override this method to configure the database (and other options) to be used for this context. This method is called for each instance of the context that is created. The base implementation does nothing.
    //DbContextOptionsBuilder => Provides a simple API surface for configuring DbContextOptions. Databases (and other extensions) typically define extension methods on this object that allow you to configure the database connection (and other options) to be used for a context.
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //optionsBuilder.UseSqlServer(connectionString);
        optionsBuilder.UseSqlServer(@"server=joydip-pc\sqlexpress;database=appdb;integrated security=true; trust server certificate=true;");
    }

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        EntityTypeBuilder<Category> categoryBuilder = modelBuilder.Entity<Category>();

        categoryBuilder
            .ToTable("categories")
            .HasKey(c => c.CategoryId);

        categoryBuilder
            .Property<int>(c => c.CategoryId)
            .IsRequired()
            .HasColumnName("categoryid")
            .HasColumnType("int")
            .ValueGeneratedOnAdd()
            .UseIdentityColumn(100, 1);

        categoryBuilder
            .Property<string>(c => c.CategoryName)
            .IsRequired()
            .HasColumnName("categoryname")
            .HasColumnType("varchar(50)");

        EntityTypeBuilder<Product> productBuilder =
            modelBuilder.Entity<Product>();

        
        productBuilder
            .ToTable("products")
            .HasKey(p => p.ProductId);

        productBuilder
            .Property<int>(p => p.ProductId)
            .IsRequired()
            .HasColumnName("productid")
            .HasColumnType("int")
            .ValueGeneratedOnAdd()
            .UseIdentityColumn(1, 1);

        productBuilder
            .Property<string>(p => p.ProductName)
            .IsRequired()
            .HasColumnName("productname")
            .HasColumnType("varchar(50)");

        productBuilder
            .Property<decimal?>(p => p.Price)
            .IsRequired(false)
            .HasColumnName("price")
            .HasColumnType("decimal(18,2)");

        productBuilder
            .Property<string?>(p => p.Description)
             .IsRequired(false)
            .HasColumnName("productdesc")
            .HasColumnType("varchar(max)");

        productBuilder
            .HasOne<Category>(p => p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.CategoryId);

        categoryBuilder
            .HasData(
            new Category { CategoryId = -1, CategoryName = "laptop" },
            new Category { CategoryId = -2, CategoryName = "mobile" },
            new Category { CategoryId = -3, CategoryName = "book" }
            );

        productBuilder
            .HasData(
            new Product { ProductId=-1, ProductName = "dell xps", Price = 120000.00M, Description = "new laptop from dell" },
             new Product { ProductId = -2, ProductName = "one plus 13", Price = 56000.00M, Description = "new mobile from one plus" },
              new Product { ProductId = -3, ProductName = "the alchemist", Price = 700.00M, Description = "new book from Paul Cohelo" }
            );
    }
}