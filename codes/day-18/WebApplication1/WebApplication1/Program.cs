using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using WebApplication1.Data.Entities;
using WebApplication1.Data.Repository.Abstractions;
using WebApplication1.Data.Repository.Implementations;
using WebApplication1.Mapper;
using WebApplication1.Models;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);


// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.Configure<ProductDatabaseOptions>(builder.Configuration.GetSection("ProductDatabaseOptions"));
builder.Services.AddAutoMapper(mapper => mapper.AddProfile<MapperProfile>());
builder.Services.AddSingleton<IRepository<ProductDTO>, ProductRepository>();
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
