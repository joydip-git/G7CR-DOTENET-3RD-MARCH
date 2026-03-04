using CalculatorApp.Entities;
using CalculatorApp.UserInterface.Models;

namespace CalculatorApp.UserInterface.Utility
{
    internal class UiUtility
    {
        public static void PrintMenu() =>
            Console.WriteLine("1. Add\n2. Subtract\n3. Multiply\n4. Divide\n5. Exit");

        public static int GetUserChoice()
        {
            Console.Write("Enter your choice: ");
            return int.Parse(Console.ReadLine());
            //bool isValidChoice = int.TryParse(Console.ReadLine(), out int choice);
            //if (isValidChoice && (choice >= 1 && choice <= 5))
            //{
            //    return choice;
            //}
            //else
            //    throw new InvalidOperationException("Invalid input. Please enter a number between 1 and 5.");
        }

        public static int GetUserInput(string message)
        {
            Console.Write(message);
            return int.Parse(Console.ReadLine());

            /*
             * bool isValidInput = int.TryParse(Console.ReadLine(), out int input);
            if (isValidInput)
            {
                return input;
            }
            else
                throw new InvalidOperationException("Invalid input. Please enter a valid integer.");
            */
        }

        public static CalculationResult Calculate(int choice, int first, int second)
        {
            Calculator calculator = new();
            int result;
            //string resultMessage = null;
            string nameOfMethod;
            string symbol;
            switch (choice)
            {
                case 1:
                    result = calculator.Add(first, second);
                    nameOfMethod = nameof(calculator.Add);
                    symbol = "+";
                    break;

                case 2:
                    result = calculator.Subtract(first, second);
                    nameOfMethod = nameof(calculator.Subtract);
                    symbol = "-";
                    break;

                case 3:
                    result = calculator.Multiply(first, second);
                    nameOfMethod = nameof(calculator.Multiply);
                    symbol = "*";
                    break;

                case 4:
                    result = calculator.Divide(first, second);
                    nameOfMethod = nameof(calculator.Divide);
                    symbol = "/";
                    break;

                default:
                    result = 0;
                    nameOfMethod = null;
                    symbol = null;
                    break;
            }
            return new CalculationResult(result, symbol, nameOfMethod);
        }
    }
}
