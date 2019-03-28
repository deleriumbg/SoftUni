using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ProductShop.Dto;
using ProductShop.Models;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            //Query 8. Export Users and Products
            CreateMap<User, UserDto>()
                .ForMember(x => x.SoldProducts, y => y.MapFrom(obj => obj));

            CreateMap<User, SoldProducts>()
                .ForMember(x => x.Products, y => y.MapFrom(obj => obj.ProductsSold.Where(x => x.Buyer != null)));

            CreateMap<Product, ProductsDto>();

            CreateMap<List<UserDto>, UsersAndProductsDto>()
                .ForMember(x => x.Users, y => y.MapFrom(obj => obj));
        }
    }
}
