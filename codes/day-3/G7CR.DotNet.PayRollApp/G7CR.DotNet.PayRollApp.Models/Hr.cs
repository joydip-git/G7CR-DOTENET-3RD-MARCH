namespace G7CR.DotNet.PayRollApp.Models
{
    public class Hr : Employee
    {
        decimal gratuityPayment;

        public Hr()
        {
        }

        public Hr(int id) : base(id)
        {
        }

        public Hr(int id, string name, decimal basicPayment, decimal daPayment, decimal hraPyament, decimal gratuityPayment) : base(id, name, basicPayment, daPayment, hraPyament)
        {
            this.gratuityPayment = gratuityPayment;
        }

        public decimal GratuityPayment 
        { 
            get => gratuityPayment; set => gratuityPayment = value; 
        }

        //public void CalculateHrSalary()
        //{
        //    base.CalculateSalary();
        //    this.TotalPayment += this.gratuityPayment;
        //}

        public override void CalculateSalary()
        {
            base.CalculateSalary();
            this.TotalPayment += this.gratuityPayment;
        }
    }
}
