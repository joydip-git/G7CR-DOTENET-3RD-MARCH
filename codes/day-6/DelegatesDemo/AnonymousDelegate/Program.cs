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
            int c = 30;
            CalDel subDel = (int a, int b) => { return a - b; };

            //you can access or "capture" the local or instance data from surrounding scope in the lamda expression -> this feature is known as "closure"
            CalDel multiDel = (a, b) => a * b * c;

            //but, in the following lamda outer parameter c can not be used as the anonymous method has been declared with "static" keyword. this is done to prevent using instance data from the surrounding scope.
            //CalDel divDel = static (a, b) => (a / b) / c;

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
