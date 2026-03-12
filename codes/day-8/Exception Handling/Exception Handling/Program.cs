namespace Exception_Handling
{
    internal class Program
    {
        static int? Divide(int a, int b)
        {
            int? res = null;
            try
            {
                res = a / b;
                return res;
            }
            catch
            {
                throw;
            }
        }
        static void Main(string[] args)
        {
            try
            {
                int? res = Divide(12, 0);
                Console.WriteLine(res.HasValue ? res.Value : "NA");
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine($"Message: {e.Message}");
                Console.WriteLine($"Source: {e.Source}");
                Console.WriteLine($"Method: {e.TargetSite}");
                Console.WriteLine($"Details: {e.StackTrace}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Message: {e.Message}");
                Console.WriteLine($"Source: {e.Source}");
                Console.WriteLine($"Method: {e.TargetSite}");
                Console.WriteLine($"Details: {e.StackTrace}");
            }
        }
    }
}
