namespace InheritanceDemo
{
    class Device //:Object
    {
        string modelName;
        string typeOfDevice;

        public Device()
        {
            //this.modelName = null;
            //this.typeOfDevice = null;
            Console.WriteLine($"default ctor of {nameof(Device)}");
        }

        public Device(string name)
        {
            this.modelName = name;
        }

        public Device(string modelName, string typeOfDevice) : this("abcd")
        {
            this.modelName = modelName;
            this.typeOfDevice = typeOfDevice;
            Console.WriteLine($"parameterized ctor of {nameof(Device)}");
        }

        public string ModelName { get => modelName; set => modelName = value; }
        public string TypeOfDevice { get => typeOfDevice; set => typeOfDevice = value; }
    }
    class Laptop : Device
    {
        int numberOfRAMs;

        public Laptop()
        {
            Console.WriteLine($"default ctor of {nameof(Laptop)}");
        }
        public Laptop(string name, string type, int rams) : base(modelName: name, typeOfDevice: type)
        {
            //this.modelName = name;
            //this.typeOfDevice = type;
            this.numberOfRAMs = rams;
            Console.WriteLine($"parameterized ctor of {nameof(Laptop)}");
        }

        public int NumberOfRAMs { get => numberOfRAMs; set => numberOfRAMs = value; }

        public string GetInfo() => $"{ModelName},{TypeOfDevice}, {numberOfRAMs} ";
    }
    internal class Program
    {
        //static void Main(){return;}
        //static void Main(string[] args){return;}
        //static int Main(){return 0;}
        //static int Main(string[] args){return 0;}
        static void Main()
        {
            Laptop dell = null;
            dell = new Laptop("dell xps", "laptop", 2);
            Console.WriteLine(dell.GetInfo());
        }
    }
}
