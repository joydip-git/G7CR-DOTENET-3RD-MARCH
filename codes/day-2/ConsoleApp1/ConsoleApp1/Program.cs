namespace ConsoleApp1
{
    internal class Program
    {
        static void Main()
        {
            CalculateSalary();
        }
        static void CalculateSalary()
        {
            //decimal[] values = new decimal[6];
            for (int i = 0; i < 2; i++)
            {
                Console.Write("enter basic: ");
                decimal basic = decimal.Parse(Console.ReadLine());
                //basic = 1000.45M;

                Console.Write("enter da: ");
                decimal da = decimal.Parse(Console.ReadLine());

                Console.Write("enter hra: ");
                decimal hra = decimal.Parse(Console.ReadLine());

                //Class1 emp = new Class1(basic, da, hra);
                basic = 1000M;
            }
        }
    }
}
