namespace PersonLibrary
{
    public class Person
    {
        //data members
        //public string name;
        //private int age;
        //public static string location;
        //protected string gender;
        //protected internal string occupation;
        //internal string hobby;

        string name;
        int age;
        static string location = "NA";

        //const -> static literal value
        //there is no memory allocated for const data members, they are replaced by their literal value at compile time
        public const string country = "India";

        //this constructor is used to initialize the static data members ONLY ONCE when the class is loaded into memory
        static Person()
        {
            Console.WriteLine("static ctor: " + location);
            location = "Bangalore";
            Console.WriteLine("loc reasigned: " + location);
        }

        public static string GetLocation()
        {
            return location;
        }

        public Person()
        {
            Console.WriteLine("default ctor");
        }

        public Person(string name, int age)
        {
            Console.WriteLine("overloaded ctor");
            this.name = name;
            this.age = age;
        }      
        public string Print()
        {
            return $"Name: {name}, Age: {age}";
        }
    }
}
