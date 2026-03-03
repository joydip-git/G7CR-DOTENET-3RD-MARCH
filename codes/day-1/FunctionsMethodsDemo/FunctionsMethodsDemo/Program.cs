namespace FunctionsMethodsDemo
{
    internal class Program
    {
        int data;
        public Program()
        {
            //data=0;
        }
        static void Main(string[] args)
        {
            int x = 10;
            int y = 20;
            //int z;
            //Swipe(x, ref y, out z);
            //or
            //Swipe(x, ref y, out int z);
            Utility.Swipe(b: ref y, c: out int z, a: x);
            Console.WriteLine("original values: x={0}, y={1}, z={2}", x, y, z);

            Utility.CalculateAverage("joydip", 12, 13);
            Utility.CalculateAverage("bankim", 23, 34, 45);

            //not possible
            //params int[] numbers = new int[] { 1, 2, 3 };
        }
    }
}
