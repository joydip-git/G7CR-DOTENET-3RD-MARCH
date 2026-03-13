namespace DataAccessLayer
{
    public interface IRepository<T, TPKey> where T : class
    {
        IEnumerable<T>? GetAll();
        T? Get(TPKey id);
    }
}
