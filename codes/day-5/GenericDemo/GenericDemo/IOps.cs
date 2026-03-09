namespace GenericDemo
{
    internal interface IOps<T>
    {
        T[] FilterValues(T[] elements);
    }
}
