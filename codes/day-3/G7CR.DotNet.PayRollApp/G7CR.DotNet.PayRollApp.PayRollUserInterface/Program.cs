using G7CR.DotNet.PayRollApp.Models;
//using G7CR.DotNet.PayRollApp.PayRollUserInterface.Utility;

//static import: possible if the class is static class
using static G7CR.DotNet.PayRollApp.PayRollUserInterface.Utility.EmployeeUtility;

namespace G7CR.DotNet.PayRollApp.PayRollUserInterface
{    
    internal class Program
    {
        static void Main(string[] args)
        {
            //A objA = new A("joy");
            //B objB = new B("joy", "trainer");
            //A obj = new B("joy", "Trainer");
           
            
            //1. print a menu for choice
            ShowMenu();

            //2. accept a choice from user
            int choice = GetChoice();

            //1. ask user for values
            //2. create an instance of Employee and pass the those values to the parameterized constructor
            //Employee employee = EmployeeUtility.CreateEmployee();
            Employee employee = CreateEmployee(choice);

            //3. calculate the total salary by calling the CalculateSalary method on the instance
            //4. print the name and the total salary of an employee using its "Name" and "TotalPayment" property
            //EmployeeUtility.PrintSalary(employee);
            PrintSalary(employee);

            // instance of static class can't be created
            // EmployeeUtility utility = new EmployeeUtility();
           
        }
    }
}
