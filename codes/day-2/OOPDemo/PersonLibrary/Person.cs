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

        //public static string GetLocation()
        //{
        //    return location;
        //}
        //public static void SetLocation(string loc)
        //{
        //    location = loc;
        //}

        //read-only property
        //public static string Location
        //{
        //    get { return location; }
        //}

        //expression-bodied member for read-only property
        public static string Location => location; 

        //public string GetName()
        //{
        //    return name;
        //}
        //public void SetName(string name)
        //{
        //    this.name = name;
        //}

        //property
        public string Name
        {
            //public string GetName()
            get
            {
                return name;
            }
            //public void SetName(string value)
            set
            {
                this.name = value; //value is the implicit parameter for set accessor
            }
        }


        //public int GetAge()
        //{
        //    return age;
        //}

        //public void SetAge(int age)
        //{
        //    this.age = age;
        //}

        //public int Age
        //{
        //    set { age = value; }
        //    get { return age; }
        //}

        public int Age
        {
            set => age = value;
            get => age;
        }

        public string Print()
        {
            return $"Name: {name}, Age: {age}, Location:{location}";
        }
    }
}
