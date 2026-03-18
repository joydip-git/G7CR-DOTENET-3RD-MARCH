namespace DIWithoutKeyedService
{
    public interface ICalculationContract<T>
    {
        T Calculate(T x, T y);
    }
}