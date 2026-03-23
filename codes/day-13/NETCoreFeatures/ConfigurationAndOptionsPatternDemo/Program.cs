using ConfigurationAndOptionsPatternDemo;
using Microsoft.Extensions.Configuration;

Dictionary<string, string?> collection = new Dictionary<string, string?>()
{
    ["key2"] = "value2"
};
IConfigurationBuilder configBuilder = new ConfigurationBuilder();
configBuilder
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddInMemoryCollection(collection)
    .AddJsonFile(@"appsettings.json", false, true);

IConfigurationRoot configProvider = configBuilder.Build();
//var data = configProvider["key1"];
var data = configProvider.GetSection("key1").Value;
var data2 = configProvider["key2"];
Console.WriteLine(data2);
//var server = configProvider.GetSection("productDbConStr").GetSection("server").Value;
var server = configProvider.GetSection("productDbConStr:server").Value;
Console.WriteLine(data);
Console.WriteLine(server);

//var productDbConStr = new ProductDbConStr();
//configProvider
//    .GetRequiredSection("productDbConStr")
//    .Bind(productDbConStr);

Action<BinderOptions> action = options =>
{
    options.ErrorOnUnknownConfiguration = true;
    options.BindNonPublicProperties = true;    
};
var productDbConStr = configProvider
    .GetRequiredSection("productDbConStr")
    .Get<ProductDbConStr>(action);

Console.WriteLine(productDbConStr);



