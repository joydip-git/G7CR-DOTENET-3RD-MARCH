namespace Coupling
{
    public class Factory
    {
        public static BankOperations CreateBackend()
        {
            return new BankingServices();
        }
    }
}
