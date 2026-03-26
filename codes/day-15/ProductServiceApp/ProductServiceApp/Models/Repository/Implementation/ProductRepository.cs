using AutoMapper;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Options;
using ProductServiceApp.ApplicationExceptions;
using ProductServiceApp.DTOs;
using ProductServiceApp.Mapper;
using ProductServiceApp.Models.Context;
using ProductServiceApp.Models.Entities;
using ProductServiceApp.Models.Repository.Abstractions;

namespace ProductServiceApp.Models.Repository.Implementation
{
    public class ProductRepository(ProductDbContext db, IMapper mapper) : IRepository<ProductDTO, int>
    {
        private readonly ProductDbContext db = db;

        public ProductDTO Add(ProductDTO data)
        {
            try
            {
                //var entity = new ProductEntity { Name = data.Name, Description = data.Description, Price = data.Price, Id = data.Id };
                var entity = mapper.Map<ProductEntity>(data);
                if (entity != null)
                {
                    var all = db.ProductEntities;
                    EntityEntry<ProductEntity> tracker = all.Add(entity);
                    var res = db.SaveChanges();
                    if (res > 0)
                    {
                        data.Id = tracker.Entity.Id;
                        return data;
                    }
                    else
                        throw new Exception("could not be added");
                }
                else
                    throw new Exception("mapping could not take place");
            }
            catch
            {
                throw;
            }
        }

        public ProductDTO Delete(int id)
        {
            try
            {
                var all = db.ProductEntities;
                var found = all.Find(id);
                if (found != null)
                {
                    all.Remove(found);
                    var res = db.SaveChanges();
                    if (res > 0)
                    {
                        //return new() { Name = found.Name, Description = found.Description, Id = found.Id, Price = found.Price };
                        var dto = mapper.Map<ProductDTO>(found);
                        if (dto != null)
                            return dto;
                        else
                            throw new Exception("mapping could not take place");
                    }
                    else
                        throw new Exception("could not delete");
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
                var entity = db.ProductEntities.Find(id);
                //return entity != null ? new() { Name = entity.Name, Price = entity.Price, Description = entity.Description, Id = entity.Id } : throw new ProductNotFoundException($"product with id: {id} does not exist...");
                if (entity != null)
                {
                    //var dto = mapper.Map<ProductDTO>(entity);
                   
                    var dto = EntityMapper.Map<ProductEntity, ProductDTO>(entity);
                    if (dto != null)
                        return dto;
                    else
                        throw new Exception("mapping could not take place");
                }
                else
                    throw new ProductNotFoundException($"product with id: {id} does not exist...");
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
                var all = db.ProductEntities;
                var dtos = new List<ProductDTO>();
                if (all != null && all.Count() > 0)
                {
                    foreach (var entity in all)
                    {
                        //dtos.Add(
                        //    new()
                        //    {
                        //        Name = entity.Name,
                        //        Price = entity.Price,
                        //        Description = entity.Description,
                        //        Id = entity.Id
                        //    }
                        //);
                        dtos.Add(mapper.Map<ProductDTO>(entity));
                    }
                }
                return dtos;
            }
            catch
            {
                throw;
            }
        }

        public ProductDTO Update(int id, ProductDTO data)
        {
            try
            {
                var entity = db.ProductEntities.Find(id);
                if (entity != null)
                {
                    entity.Name = data.Name;
                    entity.Price = data.Price;
                    entity.Description = data.Description;

                    db.ProductEntities.Update(entity);
                    if (db.SaveChanges() > 0)
                    {
                        data.Id = id;
                        return data;
                    }
                    else
                        throw new Exception("could not update");
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
