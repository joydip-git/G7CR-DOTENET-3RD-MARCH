using FiltersDemo.Filters;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Action<MvcOptions> optionsAction = options => options.Filters.Add<CommonExceptionFilter>();

//builder
//    .Services
//    .AddControllers(optionsAction);

builder.Services.AddControllers();

builder.Services
    .AddOpenApi()
    .AddSwaggerGen()
    .AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app
        .UseSwagger()
        .UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
