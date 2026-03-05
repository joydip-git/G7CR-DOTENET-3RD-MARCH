using G7CR.DotNet.PayRollApp.Models;

namespace G7CR.DotNet.PayRollApp.PayRollUserInterface.Utility
{
    internal static class EmployeeUtility
    {
        public static void ShowMenu() => Console.WriteLine("1. developer\n2. hr");

        public static int GetChoice()
        {
            Console.Write("\nEnter Choice[1/2]: ");
            return int.Parse(Console.ReadLine());
        }

        public static void PrintSalary(Employee employee)
        {
            employee.CalculateSalary();
            //if(employee is Developer)
            //{
            //    Developer developer = (Developer)employee;
            //    developer.CalculateDeveloperSalary();
            //}
            //else if(employee is Hr)
            //{
            //    Hr hr = employee as Hr;
            //}
            //else if (employee is Hr hr)
            //{
            //    hr.CalculateHrSalary();
            //}
            Console.WriteLine($"Salary of {employee.Name} is {employee.TotalPayment}");
        }

        public static Employee CreateEmployee(int choice = 1)
        {
            Console.Write("enter id: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("enter name: ");
            string name = Console.ReadLine();

            Console.Write("enter basic: ");
            decimal basic = decimal.Parse(Console.ReadLine());

            Console.Write("enter da: ");
            decimal da = decimal.Parse(Console.ReadLine());

            Console.Write("enter hra: ");
            decimal hra = decimal.Parse(Console.ReadLine());

            Employee employee = null;
            switch (choice)
            {
                case 1:
                    Console.Write("enter incentive: ");
                    decimal incentive = decimal.Parse(Console.ReadLine());
                    employee = new Developer(id, name, basic, da, hra, incentive);
                    break;

                case 2:
                    Console.Write("enter gratuity: ");
                    decimal gratuity = decimal.Parse(Console.ReadLine());
                    employee = new Hr(id, name, basic, da, hra, gratuity);
                    break;
                default:
                    break;
            }

            return employee;
        }
    }
}
