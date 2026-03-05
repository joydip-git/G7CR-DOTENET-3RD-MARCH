namespace Records
{

    /*
    //primary constructor
    class CalculationResult(int result, char operatorSymbol, string methodName = null)
    {
        //string methodName;
        //char operatorSymbol;
        //int result;

        //public CalculationResult(int result, char operatorSymbol, string methodName = null)
        //{
        //    this.methodName = methodName;
        //    this.result = result;
        //    this.operatorSymbol = operatorSymbol;
        //}

        //readonly properties
        //public string MethodName => methodName;
        //public int Result => result;
        //public char OpertaorSymbol => operatorSymbol;

        public string MethodName { set => methodName = value; get => methodName; }
        public int Result { set => result = value; get => result; }
        public char OpertaorSymbol { set => operatorSymbol = value; get => operatorSymbol; }
    }
    */


    /*
    record class CalculationResult
    {
        private initonly int backingField_Result;
        private initonly string backingField_MethodName;
        private initonly char backingField_OperatorSymbol;

        public CalculationResult(int backingField_Result,string backingField_MethodName, char backingField_OperatorSymbol)
        {
            this.Result = backingField_Result;
            this.MethodName = backingField_MethodName;
            this.OperatorSymbol = backingField_OperatorSymbol;
        }

        public int Result { get => backingField_Result; private set => backingField_Result=value; }
        public char OperatorSymbol { get => backingField_OperatorSymbol; private set => backingField_OperatorSymbol = value;}
        public string MethodName { get => backingField_MethodName; private set => backingField_MethodName = value; }
    }
    */

    record class CalculationResult(int Result, char OperatorSymbol, string MethodName = null);

    class A { }
    internal class Program
    {
        static void Main(string[] args)
        {
            CalculationResult cr = new CalculationResult(10, '-', "Subtract");
            
            Console.WriteLine(cr);

            CalculationResult another = cr with { Result = 23 };
            Console.WriteLine(another);

            A first = new A();
            A second = first;
        }
    }
}
