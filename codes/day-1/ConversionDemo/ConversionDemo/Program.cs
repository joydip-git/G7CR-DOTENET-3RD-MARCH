namespace ConversionDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int x = 10;
            long l = x;
            Console.WriteLine(l);

            long longValue= 10000000000;
            //int intValue = checked((int)longValue);
            int intValue = unchecked((int)longValue);

            Console.WriteLine(intValue);

            Console.Write("enter a value: ");
            string input = Console.ReadLine();
            //int value = int.Parse(input);
            int value = Convert.ToInt32(input);

        }
    }
}
