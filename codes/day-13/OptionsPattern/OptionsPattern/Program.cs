using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OptionsPattern;
using OptionsPattern.Repository;

var configurationProvider = ConfigureConfigurationProvider();
var serviceProvider = ConfigureServices(configurationProvider);
try
{
    int res = Divide();
    Console.WriteLine(res);
}
catch (Exception e)
{
    var logger = serviceProvider.GetRequiredService<IErrorLogger>();
    logger.LogError(e);
}

static int Divide()
{
    try
    {

        int x = 12;
        int y = 0;
        int res = x / y;
        return res;
    }
    catch
    {
        throw;
    }
}
static IServiceProvider ConfigureServices(IConfigurationRoot configurationProvider)
{
    //var setting = new LoggerSettings();
    //configurationProvider.GetRequiredSection("loggerSettings").Bind(setting);

    //var setting = configurationProvider.GetRequiredSection("loggerSettings").Get<LoggerSettings>();

    IServiceCollection serviceRegistry = new ServiceCollection();
    //configuring/registering the IOptions<T> service (built-in) for LoggerSettings whereas the LoggerSettings instance will be created and will be bound to the "loggerSettings" section
    //this IOptions<LoggerSettings> will be created then and dependency injected in ErrorLogger instance
    IServiceProvider provider = serviceRegistry
        .Configure<LoggerSettings>(configurationProvider.GetRequiredSection("loggerSettings"))
        .AddDbContext<ErrorLoggerDbContext>
        (
            builder => builder.UseSqlServer(
                configurationProvider.GetRequiredSection("loggerSettings:dbPath").Value),
            ServiceLifetime.Singleton
        )
        .AddSingleton<IErrorLogger, ErrorLogger>()
        .BuildServiceProvider();
    return provider;
}
static IConfigurationRoot ConfigureConfigurationProvider()
{
    IConfigurationBuilder builder = new ConfigurationBuilder();
    IConfigurationRoot configurationProvider = builder
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", false, true)
        .Build();
    return configurationProvider;
}

