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
    var hostBuilder = new HostApplicationBuilder();
    //HostApplicationBuilder when created, automatically instances of IServiceCollection (ServiceCollection) and IConfigurationBuilder (ConfigurationManager) are created
    //use HostApplicationBuilder.Configuration poperty to get the IConfigurationBuilder [ConfigurationManager]
    //use HostApplicationBuilder.Services poperty to get the IServiceCollection

    IConfigurationManager configurationManager = hostBuilder.Configuration;
    configurationManager
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", false, true);

    var loggerBuilder = hostBuilder.Logging;
    loggerBuilder
        .AddSimpleConsole(
        logOptions => logOptions.ColorBehavior = LoggerColorBehavior.Enabled);

    var registry = hostBuilder.Services;
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


    host.Run();
}
catch (Exception e)
{
    Console.WriteLine(e);
}