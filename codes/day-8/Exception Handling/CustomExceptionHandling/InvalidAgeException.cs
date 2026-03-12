namespace CustomExceptionHandling
{
    public class InvalidAgeException : ApplicationException
    {
        private readonly DateTime logTime = DateTime.Now;

        public InvalidAgeException()
            : base("18 is the valid age for DL")
        {

        }

        public InvalidAgeException(string message) : base(message)
        {

        }

        public InvalidAgeException(string message, Exception innerException) : base(message, innerException)
        {
            
        }

        public DateTime LogTime => logTime;

        public override string ToString()
        {
            return $"{base.ToString()}\n Logged at: {LogTime}";
        }
    }
}
