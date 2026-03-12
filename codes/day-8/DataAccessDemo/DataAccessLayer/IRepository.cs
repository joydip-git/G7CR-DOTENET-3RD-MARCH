namespace DataAccessLayer
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
    }
}
