using System.Text;

namespace DIWithoutKeyedService
{
    public class FileLogger : IExceptionLogger
    {
        public void LogException(Exception e)
        {
            string path = @"E:\trainings\G7CR-DOTENET-3RD-MARCH\codes\day-12\NETCoreFeatures\DIWithoutKeyedService\logs.txt";
            try
            {
                if (File.Exists(path))
                {
                    using var writer = new StreamWriter(path, true);
                    StringBuilder builder = new();
                    builder.AppendLine($"Logged at: {DateTime.Now}");
                    builder.AppendLine($"Message: {e.Message}");
                    builder.AppendLine($"Method: {e.TargetSite}");
                    builder.AppendLine($"Source: {e.Source}");
                    builder.AppendLine($"Details: {e.StackTrace}");
                    writer.WriteLine(builder.ToString());
                    writer.Flush();
                    writer.Close();
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
