namespace G7CR.DotNet.PayRollApp.Models
{
    public class Employee
    {
        #region Data Members
        readonly int id;
        string name = string.Empty;
        decimal basicPayment;
        decimal daPayment;
        decimal hraPyament;
        decimal totalPayment;
        #endregion

        #region Constructors
        public Employee()
        {

        }
        public Employee(int id)
        {
            this.id = id;
        }
        public Employee(int id, string name, decimal basicPayment, decimal daPayment, decimal hraPyament) : this(id)
        {
            //this.id = id;
            this.name = name;
            this.basicPayment = basicPayment;
            this.daPayment = daPayment;
            this.hraPyament = hraPyament;
        }
        #endregion

        #region Properties
        //public int Id { get => id; }
        public int Id => id;

        public string Name { get => name; set => name = value; }
        public decimal BasicPayment 
        { 
            get => basicPayment; 
            set => basicPayment = value; 
        }
        public decimal DaPayment 
        { 
            get => daPayment; set => daPayment = value; 
        }
        public decimal HraPyament 
        { 
            get => hraPyament; 
            set => hraPyament = value; 
        }
        public decimal TotalPayment
        {
            get => totalPayment;
            protected set => this.totalPayment = value;
        }
        #endregion

        #region Methods
        public virtual void CalculateSalary() => totalPayment = basicPayment + daPayment + hraPyament;
        #endregion
    }
}
