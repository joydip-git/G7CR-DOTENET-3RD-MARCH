using CalculatorApp.Entities;
using CalculatorApp.UserInterface.Models;
using CalculatorApp.UserInterface.Utility;

namespace CalculatorApp.UserInterface
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1. print menu
            UiUtility.PrintMenu();

            //2. get user choice
            int choice = UiUtility.GetUserChoice();

            //3. get user inputs
            int first = UiUtility.GetUserInput("Enter first number: ");
            int second = UiUtility.GetUserInput("Enter second number: ");

            //4. create an instance of Calculator and perform the operation
            CalculationResult res = UiUtility.Calculate(choice, first, second);

            //res.MethodName = res.MethodName ?? "Invalid Choice";

            //5. print the result
            //if (res.GetMethodName() == null)
            if (res.MethodName == null)
            {
                Console.WriteLine("Due to invalid choice no operation was performed...");
            }
            else
                //Console.WriteLine($"{res.GetMethodName()}: {first} {res.GetOpertaorSymbol()} {second} = {res.GetResult()}");
                Console.WriteLine($"{res.MethodName}: {first} {res.OperatorSymbol} {second} = {res.Result}");
        }
    }
}
