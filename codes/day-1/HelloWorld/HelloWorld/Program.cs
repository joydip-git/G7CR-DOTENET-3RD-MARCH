using MessengerLibrary;

namespace HelloWorld
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Messenger messenger = new Messenger();
            string message = messenger.Greet("Joydip");
            Console.WriteLine(message);
            Console.ReadLine();
        }
    }
}
