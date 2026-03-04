using G7CR.DotNet.PayRollApp.Models;

namespace G7CR.DotNet.PayRollApp.PayRollUserInterface.Utility
{
    internal static class EmployeeUtility
    {
        public static void PrintSalary(Employee employee)
        {
            employee.CalculateSalary();
            Console.WriteLine($"Salary of {employee.Name} is {employee.TotalPayment}");
        }

        public static Employee CreateEmployee()
        {
            Console.Write("enter id: ");
            int id = int.Parse(Console.ReadLine());

            Employee employee = new Employee(id);

            Console.Write("enter name: ");
            //string name = Console.ReadLine();
            employee.Name = Console.ReadLine();


            Console.Write("enter basic: ");
            //decimal basic = decimal.Parse(Console.ReadLine());
            employee.BasicPayment = decimal.Parse(Console.ReadLine());

            Console.Write("enter da: ");
            //decimal da = decimal.Parse(Console.ReadLine());
            employee.DaPayment = decimal.Parse(Console.ReadLine());

            Console.Write("enter hra: ");
            //decimal hra = decimal.Parse(Console.ReadLine());
            employee.HraPyament = decimal.Parse(Console.ReadLine());

            //Employee employee = new(name: name, basicPayment: basic, id: id, hraPyament: hra, daPayment: da);

            return employee;
        }
    }
}
