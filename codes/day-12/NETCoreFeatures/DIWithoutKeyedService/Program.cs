// See https://aka.ms/new-console-template for more information
using DIWithoutKeyedService;
using Microsoft.Extensions.DependencyInjection;


IServiceCollection serviceRegistry = new ServiceCollection();
IServiceProvider container = serviceRegistry
    .AddSingleton<ICalculator<int>, IntCalculator>()
    .AddSingleton<ICalculator<double>, DoubleCalculator>()
    .AddSingleton<ICalculationContract<int>, Calculator<int>>()
    .AddKeyedSingleton<IExceptionLogger, FileLogger>(LoggerType.FileLogger)
    .AddKeyedSingleton<IExceptionLogger, ConsoleLogger>(LoggerType.ConsoleLogger)
    .BuildServiceProvider();

ICalculationContract<int> intCalc = container.GetRequiredService<ICalculationContract<int>>();
IExceptionLogger logger = container.GetRequiredKeyedService<IExceptionLogger>(LoggerType.FileLogger);

UserInterface userInterface = new(intCalc, logger);
userInterface.Run(12, 0);

enum LoggerType
{
    FileLogger,
    ConsoleLogger
}




