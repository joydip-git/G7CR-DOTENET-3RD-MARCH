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
            Person p = new Person("joydip", 30);
            Person joydipPerson = new("joydip", 30);            
            Console.WriteLine(joydipPerson.Print());

            Person anilPerson = new("anil", 35);
            Console.WriteLine(anilPerson.Print());
        }
    }
}
