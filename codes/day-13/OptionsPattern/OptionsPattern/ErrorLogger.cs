
using Microsoft.Extensions.Options;
using OptionsPattern.Repository;
using System.Text;

namespace OptionsPattern
{
    public class ErrorLogger : IErrorLogger
    {
        private readonly IOptions<LoggerSettings> options;
        private readonly ErrorLoggerDbContext context;
        private readonly string? path;

        public ErrorLogger(IOptions<LoggerSettings> options, ErrorLoggerDbContext context)
        {
            this.context = context;
            this.options = options;
            LoggerSettings loggerSetting = this.options.Value;
            if (loggerSetting != null)
            {
                this.path = loggerSetting.FilePath;
            }
        }

        //[Obsolete("this version of the method logs error in file. use the other version which logs error in database")]
        public void LogError(Exception e)
        {
            /*
            if (path != null && File.Exists(path))
            {
                using var writer = new StreamWriter(path, true);
                StringBuilder builder = new();
                builder.AppendLine($"Logged at: {DateTime.Now}");
                builder.AppendLine($"Message: {e.Message}");
                builder.AppendLine($"Method: {e.TargetSite}");
                builder.AppendLine($"Source: {e.Source}");
                builder.AppendLine($"Details: {e.StackTrace}");
                writer.WriteLine(builder.ToString());
            }
            else
                throw new FileNotFoundException($"{path} does not exist");
            */
            context.ErrorLogs.Add(new Models.ErrorLog { Application = e.Source ?? "NA", LoggedAt = DateTime.Now, Message = e.Message, Method = e.TargetSite?.Name ?? "NA", Details = e.StackTrace });
            context.SaveChanges();
        }
    }
}
