namespace AnonymousDelegate
{
    delegate int CalDel(int a, int b);
    internal class Program
    {
        static void Main(string[] args)
        {
            //C# 2.0 (2005)
            //the method writtem with 'delegate' keyword -> anonymous method (is used always with delegate in a situtaion where no readymade method was available with your logic
            //addDel -> anonymous delegate (the delegate refers an anonymous method)
            CalDel addDel = delegate (int a, int b)
            {
                return a + b;
            };
           
            //C# 3.0 (2007)
            //Lambda expression -> a syntax/expression to write anonymous method
            //(arguments) =>[lambda operator] expression-body
            CalDel subDel = (int a, int b) => { return a - b; };
            CalDel multiDel = (a, b) => a * b;

            Call(addDel, 12, 13);
            Call(subDel, 12, 3);
            Call(multiDel, 12, 3);
        }
        static void Call(CalDel cd, int x, int y)
        {
            Console.WriteLine(cd(x, y));
        }
    }
}
