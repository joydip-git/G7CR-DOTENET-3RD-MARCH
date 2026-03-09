using System.Collections;

namespace Arrays_NullableTypes_Operators
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //UseIntArray();
            //UseStringArray();
            //UseMultiDimensionalArray();
            UseNullableReferenceType();
        }
        static void UseNullableReferenceType()
        {
            //string name = null;
            //if (name != null)
            //   Console.WriteLine(name.ToLower());

            //string? name =null does meant this line
            //Nullable<string> name = null;


            //string name1 = null; 
            //Console.WriteLine(name1);
            
            //nullable reference type
            string? name = null;

           
            //null propagation/conditional or Elvis operator (?.)
            //Console.WriteLine(name != null ? name.ToLower() : "Null");
            Console.WriteLine(name?.ToLower());

            //null coalesce operator (??)
            string? copy = name ?? "NA";
            
            //the above line is equivalent to the following line
            //string? copy = name != null ? name : "NA";

            Console.WriteLine("copy: " + copy);
        }
        static void UseNullableType()
        {
            //Nullable<int> data = null;
            int? data = null;
            data = 100;
            if (data.HasValue)
                Console.WriteLine(data.Value);
            else
                Console.WriteLine("no value available");
        }
        static void UseMultiDimensionalArray()
        {
            int[,] intArr = new int[2, 3];
            Console.WriteLine(intArr.Length);
            Console.WriteLine(intArr.Rank);
            for (int i = 0; i < intArr.GetLength(0); i++)
            {
                for (int j = 0; j < intArr.GetLength(1); j++)
                {
                    Console.Write($"enter value at {nameof(intArr)}[{i},{j}]: ");
                    intArr[i, j] = int.Parse(Console.ReadLine());
                }
            }

            for (int i = 0; i < intArr.GetLength(0); i++)
            {
                for (int j = 0; j < intArr.GetLength(1); j++)
                {
                    Console.WriteLine($"value at {nameof(intArr)}[{i},{j}]: {intArr[i, j]}");
                }
            }
        }
        static void UseStringArray()
        {
            string[] names = ["anil", "sunil", "joydip"];

            //IEnumerator e = names.GetEnumerator();
            //while (e.MoveNext())
            //    Console.WriteLine(e.Current);

            //foreach (string name in names)
            //{
            //    Console.WriteLine(name);
            //}

            for (int i = 0; i < names.Length; i++)
            {
                Console.WriteLine(names[i]);
            }

        }
        static void UseIntArray()
        {
            int[] values = new int[3];
            //int[] values = [1,2,3];

            for (int i = 0; i < values.Length; i++)
            {
                Console.Write($"enter a value at values[{i}]: ");
                values[i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("\n");
            //1. for loop
            //for (int i = 0; i < values.Length; i++)
            //{
            //    Console.WriteLine($"value at values[{i}]: {values[i]}");
            //}

            //2. foreach loop
            //int pos = 0;
            //foreach (int value in values)
            //{
            //    Console.WriteLine($"value at values[{pos}]: {value}");
            //    pos++;
            //}

            //3. enumerator
            IEnumerator enumerator = values.GetEnumerator();
            int pos = 0;
            while (enumerator.MoveNext())
            {
                Console.WriteLine($"value at values[{pos}]: {enumerator.Current}");
            }
        }
    }
}
