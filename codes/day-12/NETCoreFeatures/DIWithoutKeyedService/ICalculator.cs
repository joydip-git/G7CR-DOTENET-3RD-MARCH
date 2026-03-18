namespace DIWithoutKeyedService
{
    public interface ICalculator<T>
    {
        T Add(T a, T b);
        T Divide(T a, T b);
    }
}
