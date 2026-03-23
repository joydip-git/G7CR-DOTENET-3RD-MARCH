namespace DependencyInjectionDemo
{
    public class Messenger : IMessenger
    {
        public Messenger()
        {
            Console.WriteLine("messenger created...");
        }
        public string GetMessage(string name) => $"Welcome {name}";

        public string Greet(string name) => $"Greetings {name}";
    }
}
