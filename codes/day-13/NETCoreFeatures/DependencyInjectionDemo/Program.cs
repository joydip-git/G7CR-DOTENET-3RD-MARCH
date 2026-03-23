// See https://aka.ms/new-console-template for more information
using DependencyInjectionDemo;
using DependencyInjectionDemo.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

IConfigurationBuilder configBuilder = new ConfigurationBuilder();
IConfigurationRoot configurationProvider =
       configBuilder
       .SetBasePath(Directory.GetCurrentDirectory())
       .AddJsonFile(@"appsettings.json", false, true)
       .Build();

IServiceCollection serviceRegistry = new ServiceCollection();
ServiceDescriptor serviceDescriptor = new(
    serviceType: typeof(IMessenger),
    implementationType: typeof(Messenger),
    lifetime: ServiceLifetime.Transient
    );
serviceRegistry.Add(serviceDescriptor);

Action<DbContextOptionsBuilder> action = (optionsBuilder) => optionsBuilder.UseSqlServer(configurationProvider.GetConnectionString("ProductDbConStr"));
serviceRegistry
    .AddDbContext<ProductDbContext>(action, contextLifetime: ServiceLifetime.Scoped);

IServiceProvider provider = serviceRegistry.BuildServiceProvider();
using (var context = provider.GetRequiredService<ProductDbContext>())
{
    context.Products.ToList().ForEach(p => Console.WriteLine(p.Name));
}

//Manual creation of DbContext type
/*
DbContextOptionsBuilder<ProductDbContext> optionsBuilder = new();
optionsBuilder.UseSqlServer(@"server=.\sqlexpress; database=productdb; integrated security=true;trust server certificate=true;");
DbContextOptions<ProductDbContext> options = optionsBuilder.Options;

using var context = new ProductDbContext(options);
context.Products.ToList().ForEach(p => Console.WriteLine(p.Name));
*/


//UseScopeAndObjects(provider);
//UseScopeAndObjects(provider);
static void UseScopeAndObjects(IServiceProvider serviceProvider)
{
    using (IServiceScope scope = serviceProvider.CreateScope())
    {
        IServiceProvider scopedProvider = scope.ServiceProvider;
        //Console.WriteLine("\n1st object creation attempt\n");

        //IMessenger messenger1 = scopedProvider.GetRequiredService<IMessenger>();
        //string message1 = messenger1.GetMessage("joydip");
        //Console.WriteLine(message1);
        //string greeting1 = messenger1.Greet("joydip");
        //Console.WriteLine(greeting1);

        //Console.WriteLine("-----------------------------------");

        //Console.WriteLine("2nd object creation attempt\n");
        //IMessenger messenger2 = scopedProvider.GetRequiredService<IMessenger>();
        //string message2 = messenger2.GetMessage("joydip");
        //Console.WriteLine(message2);
        //string greeting2 = messenger2.Greet("joydip");
        //Console.WriteLine(greeting2);

        //using var context = scopedProvider.GetRequiredService<ProductDbContext>();
        //context.Products.ToList().ForEach(p => Console.WriteLine(p.Name));
    }
}