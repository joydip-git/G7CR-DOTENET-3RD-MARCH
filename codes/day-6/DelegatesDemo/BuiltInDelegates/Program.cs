namespace BuiltInDelegates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<int> printNum = (num) => Console.WriteLine(num);
            Action<int, int> add = (a, b) => Console.WriteLine(a + b);

            Predicate<int> isEven = num => num % 2 == 0;
            Predicate<string> containsA = name => name.ToUpper().Contains('A');

            Func<int, bool> isOdd = num => num % 2 != 0;
            Func<int, int, bool> isGreater = (a, b) => a > b;
        }
    }
}
