// See https://aka.ms/new-console-template for more information
using DIWithoutKeyedService;
using Microsoft.Extensions.DependencyInjection;


IServiceCollection serviceRegistry = new ServiceCollection();
IServiceProvider container = serviceRegistry
    .AddSingleton<ICalculator<int>, IntCalculator>()
    .AddSingleton<ICalculator<double>, DoubleCalculator>()
    .AddSingleton<Calculator<int>>()
    .BuildServiceProvider();

//Calculator<int> intCalc = container.GetRequiredService<Calculator<int>>();

UserInterface userInterface = new();
userInterface.Run();




