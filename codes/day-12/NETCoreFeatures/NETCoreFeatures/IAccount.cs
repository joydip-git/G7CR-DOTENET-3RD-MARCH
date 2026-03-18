namespace NETCoreFeatures
{
    public interface IAccount
    {
        double CurrentBalance { set; get; }
        void Deposit(double amount);
        void Withdraw(double amount);
    }
}
