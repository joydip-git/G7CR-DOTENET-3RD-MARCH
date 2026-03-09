namespace BasicsApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("enter a value: ");
            //int value = int.TryParse(Console.ReadLine());
            //bool possible = TryToParseIntoInt(Console.ReadLine(), out int x);
            bool possible = int.TryParse(Console.ReadLine(), out int x);
            Console.WriteLine(possible ? $"x: {x}" : "not possible");

            Console.Write("enter a sentence: ");
            string sentence = Console.ReadLine();
            string[] words = sentence.Split(' ', '.', ',', '!', ';');

            //Array
            int[] numbers = new int[] { 31, 12, 23, 43 };
            ChangeArray(numbers);
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine(numbers[i]);
            }
        }
        static void ChangeArray(int[] values)
        {
            Array.Sort(values);
        }
        static bool TryToParseIntoInt(string data, out int value)
        {
            bool possible = false;
            try
            {
                value = int.Parse(data);
                possible = true;
            }
            catch
            {
                value = int.MinValue;
            }
            return possible;
        }
    }
}
