namespace DIWithoutKeyedService
{
    public class DoubleCalculator : ICalculator<double>
    {
        public double Add(double a, double b)
        {
            return a + b;
        }
    }
}
