using System.Security.Principal;

namespace InterfaceDemo
{
    interface IAddition
    {
        int Add(int x, int y);
        int Add(int x, int y, int z);
    }
    record Account(string Name, int AccountNumber);

    interface IAccountOperations
    {
        Account OpenAccount(string name);
        string CloseAccount(int accNo);
    }
    interface ITransactionOperations
    {
        double CreditAmount(double amount);
        double DeditAmount(double amount);
    }

    class BankingSupport { }
    //abstract class BankingService : IAccountOperations, ITransactionOperations
    class BankingService : BankingSupport, IAccountOperations, ITransactionOperations
    {
        //public abstract string CloseAccount(int accNo);
        public string CloseAccount(int accNo)
        {
            return $"account with number: {accNo} is closed";
        }

        public double CreditAmount(double amount)
        {
            return 1000;
        }

        public double DeditAmount(double amount)
        {
            return 500;
        }

        public Account OpenAccount(string name)
        {
            return new(Name: name, AccountNumber: new Random().Next(10, 1000));
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            BankingService bankingService = new();

            //implicitly calling interface members
            Console.WriteLine(bankingService.OpenAccount("joydip"));
            Console.WriteLine(bankingService.CreditAmount(500));
            Console.WriteLine(bankingService.DeditAmount(500));
            Console.WriteLine(bankingService.CloseAccount(1000));

            //upcasting
            IAccountOperations accountOperations = bankingService;
            ITransactionOperations transactionOperations = bankingService;

            //explicitly calling interface members
            Console.WriteLine(accountOperations.OpenAccount("joydip"));
            Console.WriteLine(accountOperations.CloseAccount(1000));

            Console.WriteLine(transactionOperations.CreditAmount(500));
            Console.WriteLine(transactionOperations.DeditAmount(500));
        }
    }
}
