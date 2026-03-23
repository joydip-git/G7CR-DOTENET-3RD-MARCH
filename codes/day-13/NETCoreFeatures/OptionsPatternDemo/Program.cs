using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using OptionsPatternDemo;

try
{
    IConfigurationBuilder configBuilder = new ConfigurationBuilder();
    IConfigurationRoot configurationProvider =
        configBuilder
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile(@"appsettings.json", false, true)
        .Build();

    //var path = configurationProvider["fileOptions:filePath"];
    //FileSettingOptions? options = configurationProvider.GetRequiredSection("fileOptions").Get<FileSettingOptions>();

    IServiceCollection serviceRegistry = new ServiceCollection();
    IServiceProvider serviceProvider = serviceRegistry
        .Configure<FileSettingOptions>(configurationProvider.GetRequiredSection(nameof(FileSettingOptions)))
        .AddSingleton<IFileOperations, FileOperations>()
        .BuildServiceProvider();

    var options = serviceProvider.GetRequiredService<IOptions<FileSettingOptions>>();
    Console.WriteLine(options.Value.FilePath);

    var fileOperations = serviceProvider.GetRequiredService<IFileOperations>();
    var data = fileOperations.GetData();
    Console.WriteLine(data);
}
catch(Exception e)
{
    Console.WriteLine(e);
}


