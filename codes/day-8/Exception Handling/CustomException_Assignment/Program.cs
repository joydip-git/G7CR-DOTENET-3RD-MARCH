namespace CustomException_Assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Vehicle vehicle = new(10);
                Console.WriteLine($"Current speed:  {vehicle.IncreaseSpeed(20)}");
                Console.WriteLine($"Current speed:  {vehicle.IncreaseSpeed(30)}");
                Console.WriteLine($"Current speed:  {vehicle.IncreaseSpeed(40)}");
                Console.WriteLine($"Current speed:  {vehicle.IncreaseSpeed(20)}");
            }
            catch (MaximumSpeedLimitCrossedException e)
            {
                Console.WriteLine(e);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
