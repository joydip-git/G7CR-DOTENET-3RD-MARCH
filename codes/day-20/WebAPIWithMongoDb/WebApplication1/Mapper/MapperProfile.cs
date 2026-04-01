using AutoMapper;
using WebApplication1.Data.Entities;
using WebApplication1.Models;

namespace WebApplication1.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            IMappingExpression<ProductDTO, Product> mapping = this
                 .CreateMap<ProductDTO, Product>();

            mapping               
                .ForMember<int>(
                    entity => entity.ProductId,
                    config => config.MapFrom<int>(dto => dto.ProductId))
                .ForMember<string>(
                    entity => entity.ProductName,
                    config => config.MapFrom<string>(dto => dto.ProductName))
                .ForMember<decimal?>(
                    entity => entity.Price,
                    config => config.MapFrom<decimal?>(dto => dto.Price))
                .ForMember<string?>(
                    entity => entity.Description,
                    config => config.MapFrom<string?>(dto => dto.Description))
                .ReverseMap();
        }
    }
}
