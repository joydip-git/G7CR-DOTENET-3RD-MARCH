using Microsoft.EntityFrameworkCore;
using ProductServiceApp.DTOs;
using ProductServiceApp.Models.Context;
using ProductServiceApp.Models.Repository.Abstractions;
using ProductServiceApp.Models.Repository.Implementation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ProductDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("ProductDbConStr")));
builder.Services.AddScoped<IRepository<ProductDTO, int>, ProductRepository>();
//builder.Services.Add
builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
