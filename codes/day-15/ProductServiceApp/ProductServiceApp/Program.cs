using AutoMapper;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ProductServiceApp.DTOs;
using ProductServiceApp.Mapper;
using ProductServiceApp.Models.Context;
using ProductServiceApp.Models.Repository.Abstractions;
using ProductServiceApp.Models.Repository.Implementation;

var builder = WebApplication.CreateBuilder(args);

Action<IMapperConfigurationExpression> configAction = expressionconfig => expressionconfig.AddProfile<MappingProfile>();

builder
    .Services
    .AddAutoMapper(configAction);

//builder.Services.AddOptions<EntityMapper>("MapperOption");

builder.Services.AddDbContext<ProductDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("ProductDbConStr")));
builder.Services.AddScoped<IRepository<ProductDTO, int>, ProductRepository>();
//builder.Services.Add
builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

Action<CorsOptions> setupAction = options => options.AddPolicy(
    "mypolicy", 
    policyBuilder => policyBuilder
    .WithOrigins("*")
    .AllowAnyHeader()
    .AllowAnyMethod()    
    );
builder.Services.AddCors(setupAction);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.UseSwagger();
    app.UseSwaggerUI();
}



//app.UseHttpsRedirection();
app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
