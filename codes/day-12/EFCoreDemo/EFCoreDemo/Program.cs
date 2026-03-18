using EFCoreDemo.Models;
using EFCoreDemo.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

try
{
    DbContextOptionsBuilder<EmloyeeDbContext> optionsBuilder = new();
    optionsBuilder.UseSqlServer(@"server=.\sqlexpress; database=employeedb;integrated security=true; trust server certificate=true;pooling=true");
    //optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);
    //optionsBuilder.LogTo(Console.WriteLine);
    optionsBuilder.UseLazyLoadingProxies<EmloyeeDbContext>(true);

    DbContextOptions<EmloyeeDbContext> options = optionsBuilder.Options;

    using var context = new EmloyeeDbContext(options);

    /*
    IIncludableQueryable<Department, IEnumerable<Employee>> departments = context
        .Departments
        .Include(d => d.Employees);
    
    //departments.ToList().ForEach(d => Console.WriteLine(d));

    */
    var departments = context.Departments;
    var deptHr = departments.Where(d => d.DepartmentId == 100).First();
    if (deptHr != null)
    {
        Console.WriteLine($"{deptHr.DepartmentName} has {deptHr.EmployeeCount} employees");

        var employees = deptHr.Employees;
        employees?.ToList().ForEach(e => Console.WriteLine(e));
    }
}
catch (Exception e)
{
    Console.WriteLine(e);
}
