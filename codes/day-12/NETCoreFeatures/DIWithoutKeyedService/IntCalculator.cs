namespace DIWithoutKeyedService
{
    public class IntCalculator : ICalculator<int>
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public int Divide(int a, int b)
        {
            if (b <= 0)
                throw new ArgumentException($"denominator: {nameof(b)} should NOT be zero or negative");
            return a / b;
        }
    }
}
