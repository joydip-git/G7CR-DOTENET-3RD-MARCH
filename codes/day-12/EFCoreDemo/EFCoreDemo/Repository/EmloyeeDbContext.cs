using EFCoreDemo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreDemo.Repository
{
    public class EmloyeeDbContext : DbContext
    {
        public EmloyeeDbContext(DbContextOptions<EmloyeeDbContext> options):base(options)
        {
            
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Department> Departments { get; set; }

        //use this method during development time to create database and tables
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"server=.\sqlexpress; database=employeedb;integrated security=true; trust server certificate=true;pooling=true");
        //}

        //this method is called on every instance of this context class and t is required NOT ONLY during development time but also everytime you run the application as this method contains the mapping information between the class and table as well as the properties of the class the table columns
        //do not use this method if the mapping is done through data annotation
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //department mapping
            EntityTypeBuilder<Department> departmentBuilder = modelBuilder.Entity<Department>();

            departmentBuilder
                .ToTable("departments")
                .HasKey(d => d.DepartmentId);

            departmentBuilder
                .Property<int>(d => d.DepartmentId)
                .HasColumnName("dept_id")
                .HasColumnType("int")
                .IsRequired()
                .ValueGeneratedOnAdd()
                .UseIdentityColumn(100, 1);

            departmentBuilder
                .Property<string>(d => d.DepartmentName)
                .HasColumnType("varchar(20)")
                .HasColumnName("dept_name")
                .IsRequired();

            departmentBuilder
                .Property<int>(d => d.EmployeeCount)
                .HasColumnName("emp_count")
                .HasColumnType("int")
                .HasDefaultValue(0);

            //employee mapping

            EntityTypeBuilder<Employee> employeeBuilder = modelBuilder.Entity<Employee>();

            employeeBuilder
               .ToTable("employees")
               .HasKey(e => e.Id);

            employeeBuilder
                .Property<int>(e => e.Id)
                .HasColumnName("emp_id")
                .HasColumnType("int")
                .IsRequired()
                .ValueGeneratedOnAdd()
                .UseIdentityColumn(1, 1);

            employeeBuilder
                .Property<string>(e => e.Name)
                .HasColumnType("varchar(50)")
                .HasColumnName("emp_name")
                .IsRequired();

            employeeBuilder
                .Property<decimal?>(e => e.Salary)
                .HasColumnType("decimal(18,2)")
                .HasColumnName("emp_salary")
                .IsRequired(false);

            employeeBuilder
                .Property<long>(e => e.Mobile)
                .HasColumnType("bigint")
                .HasColumnName("emp_mobile")
                .IsRequired();

            employeeBuilder
                  .Property<string>(e => e.Email)
                  .HasColumnType("varchar(50)")
                  .HasColumnName("emp_email")
                  .IsRequired();

            employeeBuilder
                .Property<int?>(e => e.DeptId)
                .HasColumnType("int")
                .HasColumnName("emp_dept_id")
                .IsRequired(false);

            employeeBuilder
                .HasOne(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DeptId);
        }
    }
}
