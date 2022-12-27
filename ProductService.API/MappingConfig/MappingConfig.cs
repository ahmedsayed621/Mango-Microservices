using AutoMapper;
using ProductService.API.Dto;
using ProductService.API.Models;

namespace ProductService.API.MappingConfig
{
    public class MappingConfig 
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config=>
            { config.CreateMap<ProductDto, Product>();
                config.CreateMap<Product, ProductDto>();

            });

            return mappingConfig;
        }
    }
}
