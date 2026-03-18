using Microsoft.Extensions.DependencyInjection;

namespace DIWithoutKeyedService
{
    //Inject a logger and a calculator intance here in UserInterface
    public class UserInterface(ICalculationContract<int> calculator, IExceptionLogger logger)
    {
        private readonly ICalculationContract<int> calc = calculator;
        private readonly IExceptionLogger logger = logger;

        public void Run(params object[] args)
        {
            try
            {
                var res = calc.Calculate((int)args[0], (int)args[1]);
                Console.WriteLine(res);
            }
            catch (Exception e)
            {
                logger.LogException(e);
            }
        }
    }
}
