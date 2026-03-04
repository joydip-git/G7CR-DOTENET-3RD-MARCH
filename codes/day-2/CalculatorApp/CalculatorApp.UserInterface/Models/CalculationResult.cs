namespace CalculatorApp.UserInterface.Models
{
    /*
    class CalculationResult
    {
        string methodName;
        string operatorSymbol;
        int result;

        public CalculationResult(int result, string operatorSymbol, string methodName = null)
        {
            this.methodName = methodName;
            this.result = result;
            this.operatorSymbol = operatorSymbol;
        }

        public string GetMethodName() => methodName;
        public int GetResult() => result;
        public string GetOpertaorSymbol() => operatorSymbol;
    }
    */
    record CalculationResult(int Result, string OperatorSymbol, string MethodName = null);
}
