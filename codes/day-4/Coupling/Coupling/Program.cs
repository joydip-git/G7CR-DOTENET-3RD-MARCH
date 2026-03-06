namespace Coupling
{   
    internal class Program
    {
        static void Main(string[] args)
        {
            BankOperations operationsBackend = Factory.CreateBackend();
            BankManager manager = new(operationsBackend);
            manager.ProvideAssitance(choice: 1, name: "joydip");
        }
    }
}
