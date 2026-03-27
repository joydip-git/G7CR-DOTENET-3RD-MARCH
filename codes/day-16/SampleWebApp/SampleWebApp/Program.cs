using SampleWebApp.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IPeopleRepository, PeopleRepository>();

var app = builder.Build();


app.UseAuthorization();
app.MapControllerRoute(
    "default",
    "{controller}/{action}"
    );

app.Run();
