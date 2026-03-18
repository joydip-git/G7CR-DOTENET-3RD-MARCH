namespace DIWithoutKeyedService
{
    public class Calculator<T>(ICalculator<T> calculator)
    {
        private readonly ICalculator<T> calculator = calculator;

        public T Calculate(T x, T y)
        {
            try
            {
                return calculator.Add(x, y);
            }
            catch
            {

                throw;
            }
        }
    }
}
