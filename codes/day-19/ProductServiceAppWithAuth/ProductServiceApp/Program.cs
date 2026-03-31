using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProductServiceApp.DTOs;
using ProductServiceApp.Mapper;
using ProductServiceApp.Models.Context;
using ProductServiceApp.Models.Repository.Abstractions;
using ProductServiceApp.Models.Repository.Implementation;
using System.Text;

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
    .WithHeaders("*")
    .WithMethods("*")    
    );
builder.Services.AddCors(setupAction);
builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(bearerOptions =>
    {
        bearerOptions.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = true,
            ValidateIssuer = true,
            
            ValidateIssuerSigningKey = true,

            ValidIssuer = builder.Configuration["Jwt:Issuer"] ?? "http://localhost:5151",
            ValidAudience = builder.Configuration["Jwt:Audience"] ?? "http://localhost:5151",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"]?? "apiy1Wx2Pe5oFkrs68y0iTyUTGFNxwvdY8eekFfYXCm4lm4iwgF2FoogxAjeF3PTH4FNEMw5YXwTHetcJCXTOQuWiiiIUR30wPBJR0L0oC5wBzhZ35LpmlWTPcIyURXl"))
        };
    });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.UseSwagger();
    app.UseSwaggerUI();
}



//app.UseHttpsRedirection();
app.UseCors();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
