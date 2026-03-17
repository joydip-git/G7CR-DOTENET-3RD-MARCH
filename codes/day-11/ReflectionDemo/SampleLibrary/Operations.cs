namespace SampleLibrary
{
    public class Operations : IOperations
    {
        public List<OperationResult> OperationResults { get; private set; } = [];

        public void Add(int x, int y)
        {
            var res = new OperationResult(Result: x + y, OperationName: nameof(Add));
            OperationResults.Add(res);
        }

        public void Subtract(int x, int y)
        {
            var res = new OperationResult(Result: x - y, OperationName: nameof(Subtract));
            OperationResults.Add(res);
        }
    }
}
