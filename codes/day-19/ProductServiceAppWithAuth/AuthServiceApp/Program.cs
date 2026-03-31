using AuthServiceApp.Data.Context;
using AuthServiceApp.Data.Repository.Abstractions;
using AuthServiceApp.Data.Repository.Implementations;
using AuthServiceApp.Mapper;
using AuthServiceApp.OptionsSettings;
using AuthServiceApp.TokenManager;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper((config) => config.AddProfile<MappingProfile>());
builder.Services.AddDbContext<AuthDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("AuthDbConStr")));
builder.Services.AddControllers();
builder.Services.AddSingleton<ITokenManager, JwtTokenManager>();
builder.Services.Configure<Jwt>(builder.Configuration.GetRequiredSection("Jwt"));
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
builder.Services.AddScoped<IAuthRepository, AuthRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();
app.UseAuthorization();
app.MapControllers();

app.Run();
