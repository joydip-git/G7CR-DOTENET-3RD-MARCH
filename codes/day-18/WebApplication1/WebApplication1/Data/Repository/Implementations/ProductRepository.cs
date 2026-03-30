using AutoMapper;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
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
            this.mapper = mapper;
            var settings = MongoClientSettings.FromConnectionString(dbOptions.Value.MongoDbUrl);
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);

            var mongoClient = new MongoClient(settings);
            var mongoDb = mongoClient.GetDatabase(dbOptions.Value.Database);
            productsCollection = mongoDb.GetCollection<Product>(dbOptions.Value.Collection);
        }

        public async Task<List<ProductDTO>> GetAsync()
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
    }
}
