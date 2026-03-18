namespace EFCoreDemo.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public decimal? Salary { get; set; }
        public required long Mobile { get; set; }
        public required string Email { get; set; }

        public int? DeptId { get; set; }
        public virtual Department? Department { get; set; }

        public override string ToString()
        {
            return $"Name={Name}, Id={Id}, Salary={Salary}, Mobile={Mobile}, Email={Email}, Dept ID ={DeptId}";
        }
    }
}
