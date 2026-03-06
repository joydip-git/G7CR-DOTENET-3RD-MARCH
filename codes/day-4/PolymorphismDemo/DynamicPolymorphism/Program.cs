using System.Xml.Linq;

namespace DynamicPolymorphism
{
    class Person
    {
        string name = string.Empty;
        string location = string.Empty;

        public string Name { get => name; set => name = value; }
        public string Location { get => location; set => location = value; }

        public virtual string PrintInfo() => $"{name}, {location}";
    }
    class Trainer : Person
    {
        string subject = string.Empty;

        public string Subject
        {
            get => subject; set => subject = value;
        }
        //public string PrintTrainerInfo() => $"{Name}, {Location}, {subject}";
        public override string PrintInfo() => $"{base.PrintInfo()}, {subject}";
    }
    class Trainee : Person
    {
        string depratment = string.Empty;

        public string Department
        {
            get => depratment; set => depratment = value;
        }
        //public string PrintTraineeInfo() => $"{Name}, {Location}, {Department}";

        public override string PrintInfo() => $"{base.PrintInfo()}, {depratment}";
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Trainee reshma = new() { Name = "Reshma", Location = "Bangalore", Department = "ABCD" };
            Trainer joydip = new() { Name = "joy", Location = "Bangalore", Subject = ".NET" };
            Show(reshma);
            Show(joydip);
        }
        static void Show(Person person)
        {
            //Console.WriteLine(person.PrintInfo());
            if (person is Trainer trainer)
                //Console.WriteLine(trainer.PrintTrainerInfo());
                Console.WriteLine(trainer.PrintInfo());
            else if (person is Trainee trainee)
                //Console.WriteLine(trainee.PrintTraineeInfo());
                Console.WriteLine(trainee.PrintInfo());
        }
        /*
        static void Show(Trainer trainer)
        {
            //Console.WriteLine(trainer.PrintInfo());
            Console.WriteLine(trainer.PrintTrainerInfo());
        }
        static void Show(Trainee trainee)
        {
            //Console.WriteLine(trainee.PrintInfo());
            Console.WriteLine(trainee.PrintTraineeInfo());
        }
        */
    }
}
