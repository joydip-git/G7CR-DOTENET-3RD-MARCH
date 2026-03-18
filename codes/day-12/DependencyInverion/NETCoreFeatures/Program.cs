try
{
    //TransactionType transaction = TransactionType.Credit;
    //Console.WriteLine(Convert.ToInt32(transaction));

    //BankTransaction class object DEPENDS ON an IAccount type object

    //1. creating instane of the DEPENDENCY FACTOR [IAccount type object on which BankTransaction depends]
    IAccount account = new CurrentAccount() { CurrentBalance = 1000 };

    //2.1. INJECTING the DEPENDENCY (IAccount type object) in the DEPENDENT (BankTransaction) through CONSTRUCTOR
    BankTransaction bankTransaction = new(account);

    //2.2. INJECTING the DEPENDENCY (IAccount type object) in the DEPENDENT (BankTransaction) through PROPERTY
    //BankTransaction bankTransaction = new() { BankAccount = account };

    bool status = bankTransaction.DoTransaction(TransactionType.Debit, 2000);
    Console.WriteLine(status ? account.CurrentBalance : "failed");

    Console.WriteLine("press any key to exit..");
    Console.ReadKey();

}
catch (Exception e)
{
    Console.WriteLine(e);
}
interface IAccount
{
    double CurrentBalance { set; get; }
    void Deposit(double amount);
    void Withdraw(double amount);

    //default implementation
    //public double CurrentBalance { set; get; }
    //public void Deposit(double amount) => CurrentBalance += amount;
}
abstract class BankAccount : IAccount
{
    public double CurrentBalance { get; set; }

    public void Deposit(double amount) => CurrentBalance += amount;

    public abstract void Withdraw(double amount);
}
class SavingsAccount : BankAccount //: IAccount 
{   
    public override void Withdraw(double amount)
    {
        if (amount <= 0)
            throw new Exception("amount should not be negative or zero");        

        if (CurrentBalance - amount < 0)
            throw new Exception("not enough balance");

        CurrentBalance -= amount;

    }
}
class CurrentAccount : BankAccount
{
    public override void Withdraw(double amount)
    {
        if (amount <= 0)
            throw new Exception("amount should not be negative or zero");

        CurrentBalance -= amount;
    }
}
//data type of the value of each member can be of following types
//byte, sbyte, short, ushort, int, uint, long, ulong
enum TransactionType : long
{
    Credit,
    Debit
}
class BankTransaction
{
    //private IAccount? bankAccount;
    private readonly IAccount bankAccount;
    //public BankTransaction()
    //{

    //}
    public BankTransaction(IAccount account)
    {
        bankAccount = account;
    }
    //public IAccount? BankAccount { set => bankAccount = value; get => bankAccount; }

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
