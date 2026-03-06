namespace Coupling
{
    public abstract class BankOperations
    {
        public abstract Account OpenAccount(string name);
        public abstract string CloseAccount(int accNo);
    }
}
