using ApplicationExceptions;
using BusinessEntities;
using DataAccessLayer.Models;
using DataAccessLayer.Repository;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DataAccessLayer
{
    public class ProductRepository : IRepository<ProductDTO, int>
    {

        public bool Add(ProductDTO data)
        {
            try
            {
                using (var db = new ProductDbContext())
                {
                    var all = db.ProductEntities;
                    var entity = new ProductEntity { Name = data.Name, Description = data.Description, Price = data.Price };
                    all.Add(entity);
                    var res = db.SaveChanges();
                    return res > 0;
                }
            }
            catch
            {
                throw;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                using var db = new ProductDbContext();
                var all = db.ProductEntities;
                var found = all.Find(id);
                if (found != null)
                {
                    all.Remove(found);
                    var res = db.SaveChanges();
                    return res > 0;
                }
                else
                    throw new ProductNotFoundException($"product with id: {id} does not exist...");

            }
            catch
            {
                throw;
            }
        }

        public ProductDTO? Get(int id)
        {
            try
            {
                using var context = new ProductDbContext();
                var entity = context.ProductEntities.Find(id);
                return entity != null ? new() { Name = entity.Name, Price = entity.Price, Description = entity.Description, Id = entity.Id } : throw new ProductNotFoundException($"product with id: {id} does not exist...");
            }
            catch
            {

                throw;
            }
        }

        public IEnumerable<ProductDTO>? GetAll()
        {
            try
            {
                using var context = new ProductDbContext();
                var all = context.ProductEntities;
                var dtos = new List<ProductDTO>();
                if (all != null && all.Count() > 0)
                {
                    foreach (var entity in all)
                    {
                        dtos.Add(
                            new()
                            {
                                Name = entity.Name,
                                Price = entity.Price,
                                Description = entity.Description,
                                Id = entity.Id
                            }
                        );
                    }
                }
                return dtos;
            }
            catch
            {
                throw;
            }
        }

        public bool Update(int id, ProductDTO data)
        {
            try
            {
                using var context = new ProductDbContext();
                var entity = context.ProductEntities.Find(id);
                if (entity != null)
                {
                    entity.Name = data.Name;
                    entity.Price = data.Price;
                    entity.Description = data.Description;

                    context.ProductEntities.Update(entity);
                    return context.SaveChanges() > 0;
                }
                else
                    throw new ProductNotFoundException($"product with id: {id} does not exist...");
            }
            catch
            {

                throw;
            }
        }
    }
}
