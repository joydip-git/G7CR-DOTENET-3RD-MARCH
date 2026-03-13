namespace BusinessLayer
{
    public interface IManager<T, TId> where T : class
    {
        IEnumerable<T>? FetchAll(int sortChoice = 1);
        T? Fetch(TId id);
        bool Insert(T data);
        bool Modify(TId id, T data);
        bool Remove(TId id);
        IEnumerable<T>? FilterRecords(string value);
    }
}
