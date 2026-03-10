namespace DelegateImplementation
{
    internal class Program
    {
        static List<int> Filter(List<int> input)
        {
            return [];
        }
        static void Main(string[] args)
        {
            List<int> numbers = [1, 4, 6, 2, 5, 4, 9, 7, 0, 8];
            List<int> output = Filter(numbers);
            foreach (int item in output)
            {
                Console.WriteLine(item);
            }
        }
    }
}
