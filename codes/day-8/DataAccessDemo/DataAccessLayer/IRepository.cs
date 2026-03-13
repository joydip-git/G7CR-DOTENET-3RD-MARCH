namespace DataAccessLayer
{
    public interface IRepository<T, TPKey> where T : class
    {
        IEnumerable<T>? GetAll();
        T? Get(TPKey id);
        bool Add(T data);
        bool Update(TPKey id, T data);
        bool Delete(TPKey id);
    }
}
