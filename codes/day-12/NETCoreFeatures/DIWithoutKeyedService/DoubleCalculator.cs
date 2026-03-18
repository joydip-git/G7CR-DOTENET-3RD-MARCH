namespace DIWithoutKeyedService
{
    public class DoubleCalculator : ICalculator<double>
    {
        public double Add(double a, double b)
        {
            return a + b;
        }

        public double Divide(double a, double b)
        {
            if (b <= 0)
                throw new ArgumentException($"denominator: {nameof(b)} should NOT be zero or negative");
            return a / b;
        }
    }
}
