using FirstAspNetCoreApp;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder
    .Services
    .AddSingleton<ISampleService, SampleService>()
    .AddControllers();
    

WebApplication host = builder.Build();

Console.WriteLine("web host is starting....");

host.UseRouting();
host.UseAuthorization();
host.UseLogger();
host.MapControllers();
//endpoint
//host.MapGet("/welcome", () => "Welcome to ASP.Net Core");
//host.MapGet("/hello", () => "Hello...this is ASP.Net Core");

host.Run();
