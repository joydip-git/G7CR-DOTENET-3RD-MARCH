using WebApplication1.Data.Entities;

namespace WebApplication1.Data.Repository.Abstractions
{
    public interface IRepository<T>
    {
        Task<List<T>> GetAsync();
    }
}