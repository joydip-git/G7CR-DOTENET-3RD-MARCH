namespace DelegateImplementation
{
    //delegate bool LogicDel(int num);
    delegate bool LogicDel<in T>(T value);
    class Logic
    {
        //expression bodied method
        public bool IsEven(int num) => num % 2 == 0;
        public static bool IsOdd(int num) => num % 2 != 0;
    }
    internal class Program
    {
        //static List<int> Filter(List<int> input, LogicDel fnRef)
        //static List<int> Filter(List<int> input, LogicDel<int> fnRef)
        //{
        //    List<int> result = [];
        //    foreach (int item in input)
        //    {
        //        bool isTrue = fnRef(item);
        //        if (isTrue)
        //            result.Add(item);
        //    }
        //    return result;
        //}
        static List<T> Filter<T>(List<T> input, LogicDel<T> fnRef)
        {
            List<T> result = [];
            foreach (T item in input)
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
            LogicDel<int> evenDel = logic.IsEven;

            //pas the source of data and the logic to filter
            //List<int> output = Filter<int>(numbers,evenDel);

            LogicDel<int> oddDel = Logic.IsOdd;
            //List<int> output = Filter(numbers, oddDel);

            //anonymous delegate written in classic syntax
            //capturing "outer parameter"
            Console.Write("enter threshold value: ");
            int criteria = int.Parse(Console.ReadLine() ?? "0");
            LogicDel<int> greaterDel = delegate (int num)
            {
                return num > criteria;
            };
            //List<int> output = Filter<int>(numbers, greaterDel);

            //Lambda expression syntax
            LogicDel<int> lesserDel = (num) => num < criteria;
            List<int> output = Filter<int>(numbers, lesserDel);

            foreach (int item in output)
            {
                Console.WriteLine(item);
            }
        }
    }
}
