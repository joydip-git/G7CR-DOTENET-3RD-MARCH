namespace DIWithoutKeyedService
{
    public class Calculator<T>(ICalculator<T> calculator) : ICalculationContract<T>
    {
        private readonly ICalculator<T> calculator = calculator;

        public T Calculate(T x, T y)
        {
            try
            {
                _ = calculator.Divide(x, y);
                return calculator.Add(x, y);
            }
            catch
            {

                throw;
            }
        }
    }
}
