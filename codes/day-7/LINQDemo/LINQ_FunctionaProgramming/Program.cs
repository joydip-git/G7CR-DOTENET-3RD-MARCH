namespace LINQ_FunctionaProgramming
{
    internal class Program
    {
        static IEnumerable<T> SortValues<T>(IEnumerable<T> values, Comparison<T> compareLogic)
        {
            List<T> copy = [];
            copy.AddRange(values);

            //apply the logic
            copy.Sort(compareLogic);

            return copy;
        }

        static IEnumerable<T> FilterValues<T>(IEnumerable<T> values, Predicate<T> filterLogic)
        {
            List<T> result = [];
            foreach (T item in values)
            {
                //apply the logic
                bool isTrue = filterLogic(item);
                if (isTrue)
                    result.Add(item);
            }
            return result;
        }

        static IEnumerable<TResult> Transform<TInput, TResult>(IEnumerable<TInput> values, Func<TInput, TResult> transformLogic)
        {
            List<TResult> result = [];
            foreach (TInput item in values)
            {
                //apply logic
                TResult value = transformLogic(item);
                result.Add(value);
            }
            return result;
        }

        static void Main(string[] args)
        {
            List<int> numbers = [1, 3, 2, 7, 4, 8, 5, 0, 6, 9];
            //1. sort the values in descending order
            //2. pick up ony even numbers
            //3. multiply those even numbers by 3
            //4. print the final output

            /*
            Comparison<int> compareLogic = (a, b) => b - a;
            List<int> sortedNumbers = SortValues(numbers,compareLogic );

            Predicate<int> isEven = num => num % 2 == 0;
            List<int> filteredNumbers = FilterValues(sortedNumbers, isEven);

            Func<int, string> multiplyLogic = num => $"Value: {num * 3}";
            List<string> transformedNumbers = Transform(filteredNumbers, multiplyLogic);

            foreach (string item in transformedNumbers)
            {
                Console.WriteLine(item);
            }

            */

            //OrderBy()/OrderByDescending()
            //Where()
            //Select()

            IEnumerable<int> sortedNumbers = SortValues(numbers, (a, b) => a - b);
            PrintNumebrs(sortedNumbers);


            IEnumerable<int> filteredNumbers = FilterValues(sortedNumbers, (num) => num % 2 != 0);
            PrintNumebrs(filteredNumbers);


            IEnumerable<int> transformedNumbers = Transform(filteredNumbers, (num) => num * 4);
            PrintNumebrs(transformedNumbers);

            static void PrintNumebrs<T>(IEnumerable<T> collection)
            {
                foreach (var item in collection)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("\n\n");
            }
        }
    }
}
