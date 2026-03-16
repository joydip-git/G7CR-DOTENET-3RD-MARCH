using System.Data.Common;
using Microsoft.EntityFrameworkCore;

public class AppDbContext(string connectionString):DbContext
{
    private readonly string connectionString = connectionString;
    public DbSet<Product> Products { get; set; }

    //Override this method to configure the database (and other options) to be used for this context. This method is called for each instance of the context that is created. The base implementation does nothing.
    //DbContextOptionsBuilder => Provides a simple API surface for configuring DbContextOptions. Databases (and other extensions) typically define extension methods on this object that allow you to configure the database connection (and other options) to be used for a context.
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(connectionString);
    }
}