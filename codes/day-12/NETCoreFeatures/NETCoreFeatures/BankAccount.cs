namespace NETCoreFeatures
{
    public abstract class BankAccount : IAccount
    {
        public double CurrentBalance { get; set; }

        public void Deposit(double amount) => CurrentBalance += amount;

        public abstract void Withdraw(double amount);
    }
}
