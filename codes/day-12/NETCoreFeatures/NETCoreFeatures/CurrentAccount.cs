namespace NETCoreFeatures
{
    public class CurrentAccount : BankAccount
    {
        public override void Withdraw(double amount)
        {
            if (amount <= 0)
                throw new Exception("amount should not be negative or zero");

            CurrentBalance -= amount;
        }
    }
}
