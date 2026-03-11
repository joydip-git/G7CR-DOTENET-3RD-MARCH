namespace DelegateImplementation
{
    delegate bool LogicDel(int num);
    class Logic
    {
        //expression bodied method
        public bool IsEven(int num) => num % 2 == 0;
        public static bool IsOdd(int num) => num % 2 != 0;
    }
    internal class Program
    {
        static List<int> Filter(List<int> input, LogicDel fnRef)
        {
            List<int> result = [];
            foreach (int item in input)
            {
                bool isTrue = fnRef(item);
                if (isTrue)
                    result.Add(item);
            }
            return result;
        }
        static void Main(string[] args)
        {
            //source of data
            List<int> numbers = [1, 4, 6, 2, 5, 3, 9, 7, 0, 8];

            //logic to filter
            Logic logic = new();
            LogicDel evenDel = logic.IsEven;

            //pas the source of data and the logic to filter
            //List<int> output = Filter(numbers,evenDel);

            LogicDel oddDel = Logic.IsOdd;
            List<int> output = Filter(numbers, oddDel);
            foreach (int item in output)
            {
                Console.WriteLine(item);
            }
        }
    }
}
