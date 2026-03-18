namespace NETCoreFeatures
{
    public class SavingsAccount : BankAccount
    {
        public SavingsAccount()
        {
            Console.WriteLine("savings account created");
        }
        public override void Withdraw(double amount)
        {
            if (amount <= 0)
                throw new Exception("amount should not be negative or zero");

            if (CurrentBalance - amount < 0)
                throw new Exception("not enough balance");

            CurrentBalance -= amount;

        }
    }
}
