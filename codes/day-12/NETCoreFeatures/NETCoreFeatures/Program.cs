using NETCoreFeatures;
using Microsoft.Extensions.DependencyInjection;

try
{
    //create a registry to register "dependencies" or "services"
    IServiceCollection registry = new ServiceCollection();

    //register services or dependencies
    registry.AddKeyedSingleton<IAccount, SavingsAccount>(AccountType.Savings);
    registry.AddKeyedSingleton<IAccount, CurrentAccount>(AccountType.Current);
    

    IServiceProvider container = registry.BuildServiceProvider();
    IAccount account = container.GetRequiredKeyedService<IAccount>(AccountType.Current);
    account.CurrentBalance = 1000;

    BankTransaction bankTransaction = new(account);

    bool status = bankTransaction.DoTransaction(TransactionType.Debit, 2000);
    Console.WriteLine(status ? $"Balance in {bankTransaction.BankAccount.GetType().Name} is {bankTransaction.BankAccount.CurrentBalance}" : "failed");
}
catch (Exception e)
{
    Console.WriteLine(e);
}

enum AccountType
{
    Savings,
    Current
}
