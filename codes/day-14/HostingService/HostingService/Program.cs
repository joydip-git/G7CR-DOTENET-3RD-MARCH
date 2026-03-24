using HostingService.DataAccessLayer;
using HostingService.DTOs;
using HostingService.OptionsEntities;
using HostingService.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Options;

try
{
    //IServiceCollection serviceRegistry = new ServiceCollection();
    //IConfigurationManager configurationBuilder = new ConfigurationManager();
    
    HostApplicationBuilder hostBuilder = new HostApplicationBuilder();

    //HostApplicationBuilder when created, automatically instances of
    //1. IServiceCollection (ServiceCollection)
    //2. IConfigurationBuilder and IConfiguration (ConfigurationManager) 
    //3. ILoggingBuilder
    //are created

    //use HostApplicationBuilder.Configuration poperty to get the IConfigurationBuilder and IConfiguration [ConfigurationManager]
    //use HostApplicationBuilder.Services poperty to get the IServiceCollection
    //use HostApplicationBuilder.Logging property get the ILoggingBuilder

    IConfigurationManager configurationManager = hostBuilder.Configuration;

    //congigure configuration builder
    configurationManager
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", false, true);

    ILoggingBuilder loggerBuilder = hostBuilder.Logging;

    //configure logging service
    loggerBuilder
        .AddSimpleConsole(
        logOptions => logOptions.ColorBehavior = LoggerColorBehavior.Enabled);

    IServiceCollection registry = hostBuilder.Services;
    
    //register services
    registry
        .Configure<LoggerSettings>(configurationManager.GetRequiredSection("loggerSettings"))
        .AddDbContext<ProductDbContext>(optionsBuilder => optionsBuilder.UseSqlServer(configurationManager.GetConnectionString("productDbConStr")))
        .AddSingleton<IRepository<ProductDTO, int>, ProductRepository>();

    IHost host = hostBuilder.Build();

    //IHost.Services will return the IServiceProvider
    IServiceProvider provider = host.Services;

    Console.WriteLine("instantiating IOptions<LoggerSettings>");
    var options = provider.GetRequiredService<IOptions<LoggerSettings>>();
    Console.WriteLine(options.Value.DbPath + "\n" + options.Value.FilePath);

    Console.WriteLine("instantiating ILogger<Program>");
    var logger = provider.GetRequiredService<ILogger<Program>>();
    logger.LogInformation("this is logger object");

    Console.WriteLine("instantiating IConfiguration");
    var configProvider = provider.GetRequiredService<IConfiguration>();
    var filePath = configProvider["loggerSettings:filePath"];
    //var filePath = configurationManager["loggerSettings:filePath"];
    Console.WriteLine(filePath ?? "NA");

    Console.WriteLine("instantiating IRepository");
    var repo = provider.GetRequiredService<IRepository<ProductDTO, int>>();
    repo.GetAll()?.ToList().ForEach(p => Console.WriteLine(p));

    //var context = provider.GetRequiredService<ProductDbContext>();
    host.Run();
}
catch (Exception e)
{
    Console.WriteLine(e);
}