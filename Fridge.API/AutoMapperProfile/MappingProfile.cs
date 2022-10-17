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
            CreateMap<FridgeProduct, FridgeProductDto>();

            CreateMap<FridgeForCreationDto, Entities.Models.Fridge>();
            CreateMap<FridgeModelForCreationDto, FridgeModel>();
            CreateMap<ProductForCreationDto, Product>();
            CreateMap<FridgeProductForCreationDto, FridgeProduct>();

            CreateMap<FridgeForUpdateDto, Entities.Models.Fridge>();
            CreateMap<FridgeProductForUpdateDto, FridgeProduct>();
            CreateMap<FridgeModelForUpdateDto, FridgeModel>();
            CreateMap<ProductForUpdateDto, Product>();
        }
    }
}
