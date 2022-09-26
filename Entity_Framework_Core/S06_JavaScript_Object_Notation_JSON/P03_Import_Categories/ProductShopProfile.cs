using AutoMapper;
using ProductShop.DTOs.Category;
using ProductShop.DTOs.Product;
using ProductShop.DTOs.User;
using ProductShop.Models;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            //user
            this.CreateMap<ImportUserDto, User>();

            //product
            this.CreateMap<ImportProductDto, Product>();

            //category
            this.CreateMap<ImportCategoryDto, Category>();


        }
    }
}
