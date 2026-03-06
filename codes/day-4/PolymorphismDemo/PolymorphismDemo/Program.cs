namespace PolymorphismDemo
{
    class Person
    {
        string name = string.Empty;
        string location = string.Empty;
        double salary;

        public string Name { get => name; set => name = value; }
        public string Location { get => location; set => location = value; }
        public double Salary { get => salary; set => salary = value; }

        public static bool operator >(Person p1, Person p2)
        {
            return p1.salary > p2.salary;
        }
        public static bool operator <(Person p1, Person p2)
        {
            return !(p1.salary > p2.salary);
        }
        public static double operator +(Person p1, Person p2)
        {
            return p1.salary + p2.salary;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int res = Calculation.Add(12, 13);
            Console.WriteLine(res);

            //object initializer
            //Person anilPerson = new Person() { Name = "anil", Location = "Bengaluru" };
            Person anilPerson = new() { Name = "anil", Location = "Bengaluru", Salary = 1000 };
            Person sunilPerson = new() { Name = "sunil", Location = "Bengaluru", Salary = 2000 };

            if (anilPerson > sunilPerson)
            {
                Console.WriteLine($"{anilPerson.Name} is greater than {sunilPerson.Name}");
            }
            else
                Console.WriteLine($"{sunilPerson.Name} is greater than {anilPerson.Name}");

            Console.WriteLine(anilPerson + sunilPerson);

        }
    }
    class Calculation
    {
        public static int Add(int x, int y)
        {
            return x + y;
        }
        public static int Add(int x, int y, int z)
        {
            return x + y + z;
        }
        public static int Add(int x, int y, short z)
        {
            return x + y + z;
        }
        public static int Add(int x, short y, int z)
        {
            return x + y + z;
        }
    }

}
