using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;

namespace Fridge.API.AutoMapperProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Entities.Models.Fridge, FridgeDto>();
            CreateMap<FridgeModel, FridgeModelDto>();
            CreateMap<Product, ProductDto>();
            CreateMap<FridgeProduct, FridgeProductDto>()
                .ForMember(f => f.Name,
                opt => opt.MapFrom(src => src.Fridge.Name));
        }
    }
}
