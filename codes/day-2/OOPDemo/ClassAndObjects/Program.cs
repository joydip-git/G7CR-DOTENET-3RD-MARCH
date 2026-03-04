using PersonLibrary;

namespace ClassAndObjects
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("in Main....");
            Console.WriteLine(Person.GetLocation());
            Create();

            //Console.WriteLine(joydipPers);
        }
        static void Create()
        {
            Person p = new Person("joydip", 0);
            Person joydipPerson = new("joydip", 0);
            joydipPerson.Age = 30;
            //Console.WriteLine(joydipPerson.Print());
            Console.WriteLine($"{joydipPerson.Name}, {joydipPerson.Age}");

            Person anilPerson = new("NA", 35);
            anilPerson.Name = "Anil";
            Console.WriteLine(anilPerson.Print());
        }
    }
}
