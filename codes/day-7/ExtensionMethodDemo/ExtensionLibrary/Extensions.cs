using CalculationLibrary;

namespace ExtensionLibrary
{
    public static class Extensions
    {
        //public static int Multiply(this SimpleCalculator calculation, int a, int b)
        //{
        //    return a * b;
        //}
        //public static int Multiply(this ScientificCalculator calculation, int a, int b)
        //{
        //    return a * b;
        //}

        //extend every type that implements/inherits ICalculator, by adding Multiply method
        public static int Multiply(this ICalculator calculation, int a, int b)
        {
            return a * b;
        }

        //extend every type that implements/inherits IEnumerable<T>, by adding Filter<T> method
        public static IEnumerable<T> Filter<T>(this IEnumerable<T> collection,Predicate<T> filterLogic)
        {
            List<T> result = [];
            foreach (var item in collection)
            {
                if (filterLogic(item))
                    result.Add(item);
            }
            return result;
        }
    }
}
