namespace GenericDemo
{
    interface IOperations<TInput, TResult> //where TInput : struct where TResult : struct
    {
        TResult Add(TInput x, TInput y);
        TResult Subtract(TInput x, TInput y);
        //void Add(int x, int y);
        //void Add<TInput1, TInput2>(TInput1 x, TInput2 y) where TInput1 : struct where TInput2 : struct;
    }
    class Operations<TInput, TResult> : IOperations<TInput, TResult> where TInput : struct where TResult : struct
    {
        public TResult Add(TInput x, TInput y)
        {
            throw new NotImplementedException();
        }

        public TResult Subtract(TInput x, TInput y)
        {
            throw new NotImplementedException();
        }
    }
    class SecondOperations<TInput, TResult> : IOperations<TInput, TResult> where TInput : class where TResult : class, new()
    {
        public TResult Add(TInput x, TInput y)
        {
            throw new NotImplementedException();
        }

        public TResult Subtract(TInput x, TInput y)
        {
            throw new NotImplementedException();
        }
    }
    //class Operations : IOperations<int, int>
    //{
    //    public int Add(int x, int y)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public int Subtract(int x, int y)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
    internal class Program
    {

        //static void Add(int x, int y)
        //{
        //    Console.WriteLine(x + y);
        //}
        //static void Add(double x, double y)
        //{
        //    Console.WriteLine(x + y);
        //}

        //T -> type parameter
        static void Add<TInput>(TInput x, TInput y) where TInput : struct
        {

        }
        static void Add<TInput1, TInput2>(TInput1 x, TInput2 y) where TInput1 : struct where TInput2 : struct
        {

        }
        static void Main(string[] args)
        {
            IOperations<int, int> ops = new Operations<int, int>();
            ops.Add(12, 13);
            ops.Subtract(12, 3);
            //1st overloaded method
            Add<int>(12, 13);

            //2nd overloaded method
            Add<int, long>(12, 13452678456);
            Add<int, int>(34, 21);

            //Add<string>("anil", "k"); <- not possible as string is reference type
            int[] numbers = [1, 2, 3, 4];
            numbers.ToList<int>();
        }
    }
}
