namespace FunctionsMethodsDemo
{
    class Utility
    {
        public static void Swipe(int a, ref int b, out int c, int d = 0)
        {
            c = 31;
            Console.WriteLine("before swiping: a={0}, b={1}, c={2}", a, b, c);
            a = 11;
            b = 21;
            Console.WriteLine("after swiping: a={0}, b={1}, c={2}", a, b, c);
        }
        public static double CalculateAverage(string name, params double[] marks)
        {
            double sum = 0;
            for (int index = 0; index < marks.Length; index++)
            {
                sum += marks[index];
            }
            return sum / marks.Length;
        }
        //static void CalculateAreaOfShape(int x, int y = 0, int z = 0, int m = 0, int n = 0)
        //{

        //}
        public static int Add(int a, int b) => a + b;
        public static void Subtract(int a, int b) => Console.WriteLine(a > b ? a - b : b - a);
    }
}
