namespace GenericCollectionsDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //List<int> numbers = new List<int>();
            List<int> numbers = [];
            numbers.Add(12); //0
            numbers.Add(2);  //2
            numbers.Add(21); //3
            numbers.Add(34); //4 //3

            numbers.Add(45); //5  //4

            //the index pos should be less tha or equal to the number of elements
            numbers.Insert(5, 100); //6  //5
            numbers.Insert(1, 200); //1

            numbers.Remove(21);
            numbers.RemoveAt(3);

            Console.WriteLine($"number of elements: {numbers.Count}");
            Console.WriteLine($"capacity of the list: {numbers.Capacity}");

            Console.WriteLine("\n");
            //1. for loop
            for (int i = 0; i < numbers.Count; i++)
            {
                Console.WriteLine($"value at {nameof(numbers)}[{i}]: {numbers[i]}");
            }
            //2. foreach loop
            Console.WriteLine("\n");
            foreach (int item in numbers)
            {
                Console.WriteLine(item);
            }
            //3. enumerator
            Console.WriteLine("\n");
            IEnumerator<int> enumerator = numbers.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }

            //for (int i = 0; i < 2; i++)
            //{
            //    return i;
            //}

            MyList<int> items = [];
            items.Add(12);
            items.Add(1);
            items.Add(2);
            items.Add(21);
            items.Add(34);

            foreach (int item in items)
            {
                Console.WriteLine(item);
            }
        }
    }
}
