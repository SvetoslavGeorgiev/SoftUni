using AutoMapper;
using ProductShop.DTOs.Category;
using ProductShop.DTOs.CategoryProduct;
using ProductShop.DTOs.Product;
using ProductShop.DTOs.User;
using ProductShop.Models;
using System.Linq;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            //user
            this.CreateMap<ImportUserDto, User>();
            this.CreateMap<User, ExportAllUsersWithMinOneSoldItem>()
                .ForMember(d => d.SoldProducts, mo => mo.MapFrom(s => s.ProductsSold.Where(p => p.BuyerId.HasValue)));

            //product
            this.CreateMap<ImportProductDto, Product>();
            this.CreateMap<Product, ExportProductsInRange>()
                .ForMember(d => d.SellerFullName, mo => mo.MapFrom(s => $"{s.Seller.FirstName} {s.Seller.LastName}"));

            this.CreateMap<Product, ExportAllProductsWithMinOneBuyer>()
                .ForMember(d => d.BuyerFirstName, mo => mo.MapFrom(s => s.Buyer.FirstName))
                .ForMember(d => d.BuyerLastName, mo => mo.MapFrom(s => s.Buyer.LastName));

            //category
            this.CreateMap<ImportCategoryDto, Category>();

            //CategoryProduct
            this.CreateMap<ImportCategoryProductDto, CategoryProduct>();


        }
    }
}
