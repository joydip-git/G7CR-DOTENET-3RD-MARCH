using AutoMapper;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using WebApplication1.Data.Entities;
using WebApplication1.Data.Repository.Abstractions;
using WebApplication1.Models;

namespace WebApplication1.Data.Repository.Implementations
{
    public class ProductRepository : IRepository<ProductDTO>
    {
        private readonly IMongoCollection<Product> productsCollection;
        private readonly IMapper mapper;

        public ProductRepository(IOptions<ProductDatabaseOptions> dbOptions, IMapper mapper)
        {
            try
            {
                this.mapper = mapper;

                MongoClientSettings? settings = MongoClientSettings.FromConnectionString(dbOptions.Value.MongoDbUrl);
                settings.ServerApi = new ServerApi(ServerApiVersion.V1);

                var mongoClient = new MongoClient(settings);
                var mongoDb = mongoClient.GetDatabase(dbOptions.Value.Database);
                productsCollection = mongoDb.GetCollection<Product>(dbOptions.Value.Collection);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ProductDTO> CreateAsync(ProductDTO newData)
        {
            try
            {
                var entity = mapper.Map<Product>(newData);
                await productsCollection.InsertOneAsync(entity);
                return newData;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ProductDTO?> DeleteAsync(int id)
        {
            try
            {
                IAsyncCursor<Product> result = await productsCollection.FindAsync(p => p.ProductId == id);
                var foundEntity = await result.SingleAsync();
                if (foundEntity != null)
                {
                    DeleteResult? deleteResult = await productsCollection.DeleteOneAsync(p => p.ProductId == id);
                    return deleteResult.IsAcknowledged ? mapper.Map<ProductDTO>(foundEntity) : throw new Exception("product not deleted");
                }
                else
                    throw new Exception("product not found...");

                //Product deleteResult = await productsCollection.FindOneAndDeleteAsync(p => p.ProductId == id);
                //var dto = mapper.Map<ProductDTO>(deleteResult);
                //return dto;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<ProductDTO>> GetAsync()
        {
            try
            {
                var products = await productsCollection.Find(_ => true).ToListAsync();
                var productList = new List<ProductDTO>();
                products.ForEach(p =>
                {
                    var productDTO = mapper.Map<ProductDTO>(p);
                    productList.Add(productDTO);
                });
                return productList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ProductDTO?> GetByIdAsync(int id)
        {
            try
            {
                IAsyncCursor<Product> result = await productsCollection.FindAsync(p => p.ProductId == id);
                Product? entity = await result.SingleAsync();
                return mapper.Map<ProductDTO>(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ProductDTO> UpdateAsync(int id, ProductDTO updatedData)
        {
            try
            {
                var result = await productsCollection.FindAsync(p => p.ProductId == id);
                var foundEntity = await result.SingleAsync();
                if (foundEntity != null)
                {
                    updatedData.ProductId = id;
                    Product entity = mapper.Map<Product>(updatedData);
                    ReplaceOneResult? updateResult = await productsCollection.ReplaceOneAsync(x => x.ProductId == id, entity);
                    return updateResult.ModifiedCount > 0 ? updatedData : throw new Exception("could not update");
                }
                else
                    throw new Exception("product not found...");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
