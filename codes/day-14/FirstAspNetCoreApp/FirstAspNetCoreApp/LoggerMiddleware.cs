namespace FirstAspNetCoreApp
{
    public class LoggerMiddleware
    {
        private readonly RequestDelegate requestDelegate;
        private readonly ILogger<LoggerMiddleware> logger;
        private readonly ISampleService sampleService;

        public LoggerMiddleware(RequestDelegate requestDelegate, ILogger<LoggerMiddleware> logger, ISampleService sample)
        {
            this.sampleService = sample;
            this.requestDelegate = requestDelegate;
            this.logger = logger;
            logger.LogInformation($"{nameof(LoggerMiddleware)} created");
        }

        public async Task Invoke(HttpContext httpContext)
        {
            logger.LogInformation($"Logged At: {DateTime.Now}");
            logger.LogInformation(httpContext.Request.Path);
            logger.LogInformation(sampleService.SayHello());
            await requestDelegate(context: httpContext);
        }
    }

    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseLogger(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LoggerMiddleware>();
        }
    }
}
