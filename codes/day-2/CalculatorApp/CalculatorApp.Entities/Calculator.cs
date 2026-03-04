namespace CalculatorApp.Entities
{    
    /// <summary>
    /// Provides basic arithmetic operations, including addition, subtraction, multiplication, and division.
    /// </summary>
    /// <remarks>This class is designed for simple integer arithmetic. It supports operations such as
    /// addition, subtraction,  multiplication, and division. Division by zero is not allowed and will result in a <see
    /// cref="DivideByZeroException"/>.</remarks>
    public class Calculator
    {
        /// <summary>
        /// Adds two integers and returns the result.
        /// </summary>
        /// <param name="a">The first integer to add.</param>
        /// <param name="b">The second integer to add.</param>
        /// <returns>The sum of <paramref name="a"/> and <paramref name="b"/>.</returns>
        public int Add(int a, int b) => a + b;

        /// <summary>
        /// Subtracts the second integer from the first integer.
        /// </summary>
        /// <param name="a">The minuend, which is the number to be subtracted from.</param>
        /// <param name="b">The subtrahend, which is the number to subtract.</param>
        /// <returns>The result of subtracting <paramref name="b"/> from <paramref name="a"/>.</returns>
        public int Subtract(int a, int b) => a - b;

        /// <summary>
        /// Multiplies two integers and returns the result.
        /// </summary>
        /// <param name="a">The first integer to multiply.</param>
        /// <param name="b">The second integer to multiply.</param>
        /// <returns>The product of <paramref name="a"/> and <paramref name="b"/>.</returns>
        public int Multiply(int a, int b) => a * b;

        /// <summary>
        /// Divides one integer by another and returns the result.
        /// </summary>
        /// <param name="a">The dividend.</param>
        /// <param name="b">The divisor. Must not be zero.</param>
        /// <returns>The quotient of the division.</returns>
        /// <exception cref="DivideByZeroException">Thrown when <paramref name="b"/> is zero.</exception>
        public int Divide(int a, int b)
        {
            if (b == 0)
                throw new DivideByZeroException("Cannot divide by zero.");
            return a / b;
        }
    }
}
