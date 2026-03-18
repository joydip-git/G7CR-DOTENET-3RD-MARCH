namespace NETCoreFeatures
{
    public class BankTransaction(IAccount account) : ITransaction
    {
        private readonly IAccount bankAccount = account;

        public IAccount BankAccount => bankAccount;

        public bool DoTransaction(TransactionType transactionType, double amount)
        {
            bool status = false;
            switch (transactionType)
            {
                case TransactionType.Credit:
                    bankAccount?.Deposit(amount);
                    status = true;
                    break;

                case TransactionType.Debit:
                    bankAccount?.Withdraw(amount);
                    status = true;
                    break;

                default:
                    break;
            }
            return status;
        }
    }
}
