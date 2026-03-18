using Microsoft.Extensions.DependencyInjection;

namespace DIWithoutKeyedService
{
    //Inject a logger and a calculator intance here in UserInterface
    public class UserInterface
    {
        public void Run()
        {
            try
            {                
                Console.WriteLine(calc.Calculate(10, 20));
            }
            catch (Exception e)
            {
                //log the exception
            }
        }
    }
}
