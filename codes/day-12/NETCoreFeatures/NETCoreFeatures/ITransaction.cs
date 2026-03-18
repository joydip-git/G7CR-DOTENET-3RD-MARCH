namespace NETCoreFeatures
{
    public interface ITransaction
    {
        IAccount BankAccount { get; }

        bool DoTransaction(TransactionType transactionType, double amount);
    }
}