namespace Coupling
{
    public class BankingServices : BankOperations
    {
        public override Account OpenAccount(string name) => new(name, new Random().Next(0, 100));

        public override string CloseAccount(int accNo) => $"account closed for acc no: {accNo}";
    }
}
