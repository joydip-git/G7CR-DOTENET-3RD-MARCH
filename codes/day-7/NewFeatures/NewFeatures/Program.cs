namespace NewFeatures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //implicitly typed local variable

            //int x = 10;
            //using 'type inference' C# understands the data type of x from the value assigned, which is 'int' in the following case
            //you can't assign some other value to it
            //in JS var keyword is used to declare loosely typed variable
            //in C# var keyword is used to declare implicitly typed variable
            //value must be assigned to implicitly typed variable
            //var keyword IS NOT A DATA TYPE: don't use it as data type of
            // - method's arguments
            // - method's return type
            // - class fields
            var x = 10;
            Console.WriteLine(x);

            List<int> numbers = [1, 2, 3, 4];
            foreach (var item in numbers)
            {
                //code
            }

            //implicitly typed array variable
            var arr = new[] { 1, 2, 3, 4 };

            //object obj = Create();
            //Console.WriteLine(obj.);

        }
        static Object Create()
        {
            var anilPerson = new { FirstName = "anil", LastName = "K" };
            var sunilPerson = anilPerson;
            var joydipPerson = new { sunilPerson.FirstName, sunilPerson.LastName };

            //anilPerson.FirstName = "joy";
            return anilPerson;
        }
        public static int Calculate(int choice)
        {

            //int res = choice switch
            //{
            //    1 => 12 + 3,
            //    2 => 12 - 3,
            //    _ => -1
            //};
            //return res;

            return choice switch
            {
                1 => 12 + 3,
                2 => 12 - 3,
                _ => -1
            };
        }

    }
}
