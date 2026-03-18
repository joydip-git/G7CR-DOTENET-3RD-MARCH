using System.Text;

namespace DIWithoutKeyedService
{
    public class ConsoleLogger : IExceptionLogger
    {
        public void LogException(Exception e)
        {
            try
            {
                StringBuilder builder = new();
                builder.AppendLine($"Logged at: {DateTime.Now}");
                builder.AppendLine($"Message: {e.Message}");
                builder.AppendLine($"Method: {e.TargetSite}");
                builder.AppendLine($"Source: {e.Source}");
                builder.AppendLine($"Details: {e.StackTrace}");
                Console.WriteLine(builder.ToString());
            }
            catch
            {
                throw;
            }
        }
    }
}
