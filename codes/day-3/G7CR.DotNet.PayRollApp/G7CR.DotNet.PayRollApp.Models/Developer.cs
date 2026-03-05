namespace G7CR.DotNet.PayRollApp.Models
{
    public class Developer : Employee
    {
        decimal incentivePayment;

        public Developer() { }

        public Developer(int id) : base(id)
        {
        }

        public Developer(int id, string name, decimal basicPayment, decimal daPayment, decimal hraPyament, decimal incentivePayment) : base(id, name, basicPayment, daPayment, hraPyament)
        {
            this.incentivePayment = incentivePayment;
        }

        public decimal IncentivePayment
        {
            get => incentivePayment;
            set => incentivePayment = value;
        }

        public override void CalculateSalary()
        {
            base.CalculateSalary();
            this.TotalPayment += this.incentivePayment;
        }

        // public void CalculateSalary() => totalPayment = basicPayment + daPayment + hraPyament;

        //public void CalculateDeveloperSalary()
        //{
        //    base.CalculateSalary();
        //    this.TotalPayment += this.incentivePayment;
        //}

    }
}
