using System.Threading.Tasks;

namespace WebApplication1.Data.Repository.Abstractions
{
    public interface IRepository<T>
    {
        Task<List<T>> GetAsync();
        Task<T?> GetByIdAsync(int id);
        Task<T> UpdateAsync(int id, T updatedData);
        Task<T> CreateAsync(T newData);
        Task<T?> DeleteAsync(int id);
    }
}