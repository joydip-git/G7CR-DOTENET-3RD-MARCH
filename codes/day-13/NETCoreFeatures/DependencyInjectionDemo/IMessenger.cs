namespace DependencyInjectionDemo
{
    public interface IMessenger
    {
        string GetMessage(string name);
        string Greet(string name);
    }
}