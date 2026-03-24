using FirstAspNetCoreApp;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

//builder
//    .Services
//    .AddRouting()
//    .AddAuthorization();

WebApplication host = builder.Build();

Console.WriteLine("web host is starting....");

//host.UseRouting();
//host.UseAuthorization();
host.UseLogger();
//endpoint
host.MapGet("/welcome", () => "Welcome to ASP.Net Core");
host.MapGet("/hello", () => "Hello...this is ASP.Net Core");

host.Run();
