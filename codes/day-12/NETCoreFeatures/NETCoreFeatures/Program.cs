using NETCoreFeatures;

try
{
    CurrentAccount account = new() { CurrentBalance = 1000 };
    BankTransaction bankTransaction = new(account);

    bool status = bankTransaction.DoTransaction(TransactionType.Debit, 2000);
    Console.WriteLine(status ? account.CurrentBalance : "failed");
}
catch (Exception e)
{
    Console.WriteLine(e);
}
