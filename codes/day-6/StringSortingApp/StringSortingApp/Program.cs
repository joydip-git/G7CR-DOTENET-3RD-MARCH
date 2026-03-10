namespace StringSortingApp
{    
    internal class Program
    {
        static void Main()
        {
            List<string> strings = ["hello", "welcome", "g7cr", "bangalore"];
            strings.Sort();
            foreach (string item in strings)
            {
                Console.WriteLine(item);
            }
        }
    }
}
