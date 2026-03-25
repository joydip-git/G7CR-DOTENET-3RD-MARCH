namespace ProductServiceApp.Models.Repository.Abstractions
{
    public interface IRepository<T, TPKey> where T : class
    {
        IEnumerable<T>? GetAll();
        T? Get(TPKey id);
        T Add(T data);
        T Update(TPKey id, T data);
        T Delete(TPKey id);
    }
}
