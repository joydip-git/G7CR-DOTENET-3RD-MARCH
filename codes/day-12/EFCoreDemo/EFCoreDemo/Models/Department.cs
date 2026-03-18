namespace EFCoreDemo.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public required string DepartmentName { get; set; }       
        public int EmployeeCount { get; set; }

        public virtual ICollection<Employee> Employees { get; set; } = [];

        public override string ToString()
        {
            return $"Name={DepartmentName}, Id={DepartmentId}";
        }
    }
}
