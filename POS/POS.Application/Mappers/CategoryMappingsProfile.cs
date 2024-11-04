using AutoMapper;
using POS.Application.Dtos.Category.Request;
using POS.Application.Dtos.Category.Response;
using POS.Domain.Entities;
using POS.Infrastructure.Commons.Bases.Response;
using POS.Utilities.Static;

namespace POS.Application.Mappers
{
    public class CategoryMappingsProfile : Profile
    {
        public CategoryMappingsProfile()
        {
            ///CategoryResponseDto lo que finalmente quiero mostrar al cliente
            CreateMap<Category, CategoryResponseDto>()
                .ForMember(x => x.CategoryId, x => x.MapFrom(y => y.Id))
                .ForMember(x => x.StateCategory, x => x.MapFrom(t => t.State.Equals((int)StateTypes.Active) ? "Activo" : "Inactivo"))
                .ReverseMap();

            ///
            CreateMap<BaseEntityResponse<Category>, BaseEntityResponse<CategoryResponseDto>>()
                .ReverseMap();

            //Lo que se necesita a la BD CategoryRequestDto=> Category
            CreateMap<CategoryRequestDto, Category>()
                .ReverseMap();

            CreateMap<Category, CategorySelectResponseDto>()
                 .ForMember(x => x.CategoryId, x => x.MapFrom(y => y.Id)) //categoryid va a serigual al que hemos configurado ID
                .ReverseMap();
        }
    }
}
