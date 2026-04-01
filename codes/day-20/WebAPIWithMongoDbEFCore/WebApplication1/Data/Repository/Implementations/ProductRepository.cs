using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using WebApplication1.Data.Context;
using WebApplication1.Data.Entities;
using WebApplication1.Data.Repository.Abstractions;
using WebApplication1.Models;

namespace WebApplication1.Data.Repository.Implementations
{
    public class ProductRepository : IRepository<ProductDTO>
    {
        private readonly IMapper mapper;
        private readonly ProductDbContext context;

        public ProductRepository(IMapper mapper, ProductDbContext context)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<ProductDTO> CreateAsync(ProductDTO newData)
        {
            try
            {
                var entity = mapper.Map<Product>(newData);
                await context.Products.AddAsync(entity);
                var status = await context.SaveChangesAsync();
                return status > 0 ? newData : throw new Exception("could not add");
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
                Product? result = await context.Products.FindAsync(id);
                if (result != null)
                {
                    context.Products.Remove(result);
                    var status = await context.SaveChangesAsync();
                    return status > 0 ? mapper.Map<ProductDTO>(result) : throw new Exception("product not deleted");
                }
                else
                    throw new Exception("product not found...");
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
                var products = await context.Products.ToListAsync<Product>();
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
                Product? result = await context.Products.FindAsync(id);
                return result != null ? mapper.Map<ProductDTO>(result) : throw new Exception("product not found");
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
                Product? foundEntity = await context.Products.FindAsync(id);
                if (foundEntity != null)
                {
                    updatedData.ProductId = id;
                    Product entity = mapper.Map<Product>(updatedData);
                    context.Products.Update(entity);
                    var status = await context.SaveChangesAsync();
                    return status > 0 ? updatedData : throw new Exception("could not update");
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
