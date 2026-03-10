namespace DelegatesDemo
{
    delegate void CalDel(int a, int b);

    class Calculation
    {
        public static void Add(int x, int y)
        {
            Console.WriteLine(x + y);
        }
        public void Subtract(int x, int y)
        {
            Console.WriteLine(x - y);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            CalDel addFnRef = new(Calculation.Add);

            Calculation calculation = new();
            CalDel subtractFnRef = calculation.Subtract;

            //addFnRef(12, 14);
            //subtractFnRef.Invoke(12, 3);
            InvokeMethods(addFnRef, 12, 14);
            InvokeMethods(subtractFnRef, 12, 3);
        }
        static void InvokeMethods(CalDel cd, int a, int b)
        {
            cd(a, b);
            //cd.Invoke(a, b);
        }
    }
}
