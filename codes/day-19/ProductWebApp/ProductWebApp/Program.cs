using ProductWebApp.API;
using ProductWebApp.Interceptors;
using ProductWebApp.Models;
using ProductWebApp.Services;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<TokenInterceptor>();
builder.Services.AddHttpClient("ApiClient").AddHttpMessageHandler<TokenInterceptor>();
builder.Services.AddSingleton<ITokenStorage, TokenStorage>();
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IProductApiRequests, ProductApiRequests>();
builder.Services.AddScoped<IAuthApiRequests, AuthApiRequests>();
builder.Services.Configure<ApiRequestBaseUrls>(builder.Configuration.GetRequiredSection("ApiRequestBaseUrls"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Auth}/{action=Login}/{id?}")
    .WithStaticAssets();


app.Run();
