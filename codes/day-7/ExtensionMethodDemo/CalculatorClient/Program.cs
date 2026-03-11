using CalculationLibrary;
using ExtensionLibrary;

namespace CalculatorClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SimpleCalculator simpleCalculator = new();
            Console.WriteLine(simpleCalculator.Add(12, 13));
            Console.WriteLine(simpleCalculator.Subtract(12, 3));
            Console.WriteLine(simpleCalculator.Multiply(12, 3));

            ScientificCalculator scientificCalculator = new();
            Console.WriteLine(scientificCalculator.Multiply(12, 3));

            List<int> numbers = [1, 2, 3, 4, 5];
            //var result = numbers.Filter(num => num % 2 == 0);
            var result = numbers.Where(num => num % 2 == 0);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }
}
