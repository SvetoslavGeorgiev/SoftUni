using AutoMapper;
using ProductShop.DTOs.Category;
using ProductShop.DTOs.CategoryProduct;
using ProductShop.DTOs.Product;
using ProductShop.DTOs.User;
using ProductShop.Models;
using System;
using System.Linq;

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
            this.CreateMap<Product, ExportProductsInRangeDto>()
                .ForMember(d => d.SellerFullName, mo => mo.MapFrom(s => $"{s.Seller.FirstName} {s.Seller.LastName}"));

            this.CreateMap<Product, ExportAllProductsWithMinOneBuyerDto>()
                .ForMember(d => d.BuyerFirstName, mo => mo.MapFrom(s => s.Buyer.FirstName))
                .ForMember(d => d.BuyerLastName, mo => mo.MapFrom(s => s.Buyer.LastName));
            this.CreateMap<User, ExportAllUsersWithMinOneSoldItemDto>()
                .ForMember(d => d.SoldProducts, mo => mo.MapFrom(s => s.ProductsSold.Where(p => p.BuyerId.HasValue)));

            //category
            this.CreateMap<ImportCategoryDto, Category>();

            


            this.CreateMap<Category, ExportCategoriesByProductsCountDto>()
                .ForMember(d => d.ProductsCount, mo => mo.MapFrom(s => s.CategoriesProducts.Count))
                .ForMember(d => d.AvgPrice, mo => mo.MapFrom(s => Math.Round((double)s.CategoriesProducts.Average(p => p.Product.Price), 2)))
                .ForMember(d => d.TotalPrice, mo => mo.MapFrom(s => Math.Round((double)s.CategoriesProducts.Sum(p => p.Product.Price), 2)));

            //CategoryProduct
            this.CreateMap<ImportCategoryProductDto, CategoryProduct>();


        }
    }
}
