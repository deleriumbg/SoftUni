using AutoMapper;
using ProductShop.App.DTO;
using ProductShop.Models;

namespace ProductShop.App
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            CreateMap<UserDto, User>();
            CreateMap<ProductDto, Product>();
            CreateMap<CategoryDto, Category>();
        }
    }
}
