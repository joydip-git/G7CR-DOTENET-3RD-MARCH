namespace GenericDelegate
{
    //strongly-typed delegate
    //delegate int CalDel(int a, int b);
    //delegate bool FilterLogicDel(int a);

    delegate TResult CalDel<in TInput, out TResult>(TInput a, TInput b) where TInput : struct where TResult : struct;

    delegate TResult CalDel<in TInput1, in TInput2, out TResult>(TInput1 a, TInput2 b);

    delegate bool FilterLogicDel<in T>(T a);

    internal class Program
    {
        static void Main(string[] args)
        {
            FilterLogicDel<int> isEven = a => a % 2 == 0;
            FilterLogicDel<string> contains = name => name[0] == 'a';

            CalDel<int, int> addDel = (a, b) => a + b;
            CalDel<string, string, string> concatDel = (firstName, lastName) => $"{firstName} {lastName}";
        }
    }
}
