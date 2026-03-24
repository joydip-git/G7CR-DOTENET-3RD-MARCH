using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

IHouseBuilder houseBuilder = new DefaultHouseBuilder();
House house = houseBuilder.BuildHouse();

Console.WriteLine(house.SwimmingPool != null ? "Pool is there" : "NA");
house = houseBuilder
    .AddSwimmingPool()
    .AddGarden()
    .AddTennisLawn()
    .BuildHouse();
Console.WriteLine(house.SwimmingPool != null ? "Pool is there" : "NA");

//IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
//IConfigurationRoot configuration = configurationBuilder
//    .SetBasePath(Directory.GetCurrentDirectory())
//    .AddJsonFile(@"", false, true)
//    .AddInMemoryCollection()
//    .Build();


//IServiceCollection registry = new ServiceCollection();
//IServiceProvider provider = registry
//    .Configure<string>(configuration.GetRequiredSection(""))
//    .Add(new(null, null))
//    .AddSingleton()
//    .BuildServiceProvider();




class Door { }
class Window { }
class Ceiling { }
class Wall { }
class SwimmingPool { }
class Garden { }
class TennisLawn { }
class House
{
    public required ICollection<Door> Doors { get; set; }
    public required ICollection<Window> Windows { get; set; }
    public required ICollection<Wall> Walls { get; set; }
    public required Ceiling Ceiling { get; set; }
    public SwimmingPool? SwimmingPool { get; set; }
    public Garden? Garden { get; set; }
    public TennisLawn? TennisLawn { get; set; }
}

interface IHouseBuilder
{
    DefaultHouseBuilder AddGarden();
    DefaultHouseBuilder AddSwimmingPool();
    House BuildHouse();
    House House { get; }
}

class DefaultHouseBuilder : IHouseBuilder
{
    private House house;
    public DefaultHouseBuilder()
    {
        house = new()
        {
            Doors = [new(), new()],
            Walls = [new(), new(), new(), new()],
            Ceiling = new(),
            Windows = [new(), new(), new(), new()]
        };
    }
    public House House => house;

    public DefaultHouseBuilder AddSwimmingPool()
    {
        house.SwimmingPool = new();
        return this;
    }
    public DefaultHouseBuilder AddGarden()
    {
        house.Garden = new();
        return this;
    }
    public House BuildHouse() => house;
}

static class HouseBuilderExtensions
{
    public static IHouseBuilder AddTennisLawn(this IHouseBuilder builder)
    {
        var house = builder.House;
        house.TennisLawn = new();
        return builder;
    }
}


