using AuthServiceApp.Data.Entities;
using AuthServiceApp.DTOs;
using AutoMapper;

namespace AuthServiceApp.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            IMappingExpression<UserDTO, UserEntity> mapping =
                 CreateMap<UserDTO, UserEntity>();
            mapping.ReverseMap();

            //mapping
            //    .ForMember<int>(
            //        entity => entity.Id,
            //        config => config.MapFrom<int>(dto => dto.Id))
            //    .ForMember<string>(
            //        entity => entity.Name,
            //        config => config.MapFrom<string>(dto => dto.Name))
            //    .ForMember<decimal?>(
            //        entity => entity.Price,
            //        config => config.MapFrom<decimal?>(dto => dto.Price))
            //    .ForMember<string?>(
            //        entity => entity.Description,
            //        config => config.MapFrom<string?>(dto => dto.Description))
            //    .ReverseMap();            
        }
    }
}
