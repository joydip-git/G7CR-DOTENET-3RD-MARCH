namespace CalculationLibrary
{
    public class Calculation
    {
        public int Add(int x, int y) => x + y;

        public int Divide(int x, int y)
        {
            try
            {
                if (y == 0)
                    throw new DivideByZeroException("divisor should not be zero");
                return x / y;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
