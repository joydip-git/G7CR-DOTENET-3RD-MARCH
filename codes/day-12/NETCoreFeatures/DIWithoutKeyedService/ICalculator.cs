namespace DIWithoutKeyedService
{
    public interface ICalculator<T>
    {
        T Add(T a, T b);
    }
}
