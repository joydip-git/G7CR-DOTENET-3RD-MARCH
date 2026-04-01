using FluentValidation;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using WebApplication1.Data.Context;
using WebApplication1.Data.Repository.Abstractions;
using WebApplication1.Data.Repository.Implementations;
using WebApplication1.Mapper;
using WebApplication1.Models;
using WebApplication1.Models.Validators;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);

var (client, database) = ConfigureMongoDbSetting(builder);
builder.Services.AddDbContext<ProductDbContext>(optionsBuilder => optionsBuilder.UseMongoDB(client, database));

builder.Services.AddAutoMapper(mapper => mapper.AddProfile<MapperProfile>());

builder.Services.AddScoped<IRepository<ProductDTO>, ProductRepository>();

builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped<IValidator<ProductDTO>, ProductDTOValidator>();

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

static (IMongoClient, string) ConfigureMongoDbSetting(WebApplicationBuilder builder)
{
    string conStr = builder.Configuration.GetRequiredSection("ProductDatabaseOptions:MongoDbUrl").Value ?? "mongodb://localhost:27017/";

    MongoClientSettings? settings = MongoClientSettings.FromConnectionString(conStr);
    settings.ServerApi = new ServerApi(ServerApiVersion.V1);

    var mongoClient = new MongoClient(settings);

    string? databaseName = builder.Configuration.GetRequiredSection("ProductDatabaseOptions:Database").Value ?? "productdb";

    return (mongoClient, databaseName);
}
