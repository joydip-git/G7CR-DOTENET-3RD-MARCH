using BusinessEntities;

namespace DataAccessLayer
{
    public class ProductRepository : IRepository<Product>
    {
        public IEnumerable<Product> GetAll()
        {
            return [];
        }
    }
}
