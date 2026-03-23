using Microsoft.EntityFrameworkCore;
using OptionsPattern.Models;

namespace OptionsPattern.Repository
{
    public class ErrorLoggerDbContext : DbContext
    {
        public ErrorLoggerDbContext(DbContextOptions<ErrorLoggerDbContext> options) : base(options)
        {

        }
        public DbSet<ErrorLog> ErrorLogs { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"server=.\sqlexpress; database=logdb;integrated security=true;trust server certificate=true");
        //}
    }
}
