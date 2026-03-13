using BusinessEntities;
using DataAccessLayer;

namespace BusinessLayer
{
    public class ProductManager : IManager<ProductDTO, int>
    {
        private readonly IRepository<ProductDTO, int> _repository;
        public ProductManager() => _repository = new ProductRepository();

        public ProductDTO? Fetch(int id)
        {
            try
            {
                if (id < 0)
                    throw new ArgumentException($"{id} should NOT be negative");

                return _repository.Get(id);
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<ProductDTO>? FetchAll(int sortChoice = 1)
        {
            try
            {
                var all = _repository.GetAll();
                if (all != null && all.Count() > 0)
                {
                    return sortChoice switch
                    {
                        1 => all.OrderBy(p => p.Id),
                        2 => all.OrderBy(p => p.Name),
                        3 => all.OrderBy(p => p.Price),
                        _ => all.OrderBy(p => p.Id)
                    };
                }
                else
                    throw new Exception("no records....");
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<ProductDTO>? FilterRecords(string value)
        {
            try
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException($"{nameof(value)} is either null or empty");

               var all = _repository.GetAll();
                return all?.Where(p => p.Name.ToLower().Contains(value.ToLower()));
            }
            catch
            {
                throw;
            }
        }

        public bool Insert(ProductDTO data)
        {
            try
            {
                int id = 100;
                data.Id = id;
                return false;
            }
            catch
            {
                throw;
            }
        }

        public bool Modify(int id, ProductDTO data)
        {
            try
            {
                return false;
            }
            catch
            {
                throw;
            }
        }

        public bool Remove(int id)
        {
            try
            {
                return false;
            }
            catch
            {
                throw;
            }
        }
    }
}
