namespace Coupling
{
    public class BankManager
    {
        private readonly BankOperations operations;
        public BankManager(BankOperations operations)
        {
            this.operations = operations;
        }
        public void ProvideAssitance(int choice, string name = null, int accNo = 0)
        {
            switch (choice)
            {
                case 1:
                    Console.WriteLine(operations.OpenAccount(name));
                    break;

                case 2:
                    Console.WriteLine(operations.CloseAccount(accNo));
                    break;

                default:
                    Console.WriteLine("incorrect choice...");
                    break;
            }
        }
    }
}
