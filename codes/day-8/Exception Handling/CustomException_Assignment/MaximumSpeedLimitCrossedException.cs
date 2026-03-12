namespace CustomException_Assignment
{
    public class MaximumSpeedLimitCrossedException : ApplicationException
    {
        private readonly DateTime logTime = DateTime.Now;

        public MaximumSpeedLimitCrossedException()
            : base("18 is the valid age for DL")
        {

        }

        public MaximumSpeedLimitCrossedException(string message) : base(message)
        {

        }

        public MaximumSpeedLimitCrossedException(string message, Exception innerException) : base(message, innerException)
        {

        }

        public DateTime LogTime => logTime;

        public override string ToString() =>
            $"{base.ToString()}\n Logged at: {LogTime}";
    }
}
