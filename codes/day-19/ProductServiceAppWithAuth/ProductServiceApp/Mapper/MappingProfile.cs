using AutoMapper;
using ProductServiceApp.DTOs;
using ProductServiceApp.Models.Entities;

namespace ProductServiceApp.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            IMappingExpression<ProductDTO, ProductEntity> mapping = this
                 .CreateMap<ProductDTO, ProductEntity>();

            mapping
                .ForMember<int>(
                    entity => entity.Id,
                    config => config.MapFrom<int>(dto => dto.Id))
                .ForMember<string>(
                    entity => entity.Name,
                    config => config.MapFrom<string>(dto => dto.Name))
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
