using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductShop.Data;
using ProductShop.DTOs.Category;
using ProductShop.DTOs.CategoryProduct;
using ProductShop.DTOs.Product;
using ProductShop.DTOs.User;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        

        public static void Main(string[] args)
        {
            Mapper.Initialize(cfg => cfg.AddProfile(typeof(ProductShopProfile)));

            using ProductShopContext dBcontext = new ProductShopContext();

            //string inputJson = File.ReadAllText("../../../Datasets/categories-products.json");

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "../../../Results/users-and-products.json");


            //dBcontext.Database.EnsureDeleted();
            //dBcontext.Database.EnsureCreated();

            var result = GetUsersWithProducts(dBcontext);

            

            File.WriteAllText(filePath, result);


        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {

            ImportUserDto[] userDtos = JsonConvert.DeserializeObject<ImportUserDto[]>(inputJson);

            ICollection<User> users = new List<User>();

            foreach (var uDto in userDtos)
            {
                users.Add(Mapper.Map<User>(uDto));
            }


            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {

            var productDtos = JsonConvert.DeserializeObject<ImportProductDto[]>(inputJson);

            ICollection<Product> products = new List<Product>();

            foreach (var pDto in productDtos)
            {

                products.Add(Mapper.Map<Product>(pDto));
            }

            context.Products.AddRange(products);
            context.SaveChanges();


            return $"Successfully imported {products.Count}";



        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {

            var categoryDtos = JsonConvert.DeserializeObject<ImportCategoryDto[]>(inputJson);

            ICollection<Category> categories = new List<Category>();

            foreach (var cDto in categoryDtos)
            {
                if (cDto.Name == null)
                {
                    continue;
                }
                categories.Add(Mapper.Map<Category>(cDto));
            }

            context.Categories.AddRange(categories);
            context.SaveChanges();


            return $"Successfully imported {categories.Count}";
        }


        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {

            ImportCategoryProductDto[] importCategoryProductDtos = JsonConvert.DeserializeObject<ImportCategoryProductDto[]>(inputJson);

            ICollection<CategoryProduct> categoryProducts = new List<CategoryProduct>();

            foreach (var cpDto in importCategoryProductDtos)
            {

                categoryProducts.Add(Mapper.Map<CategoryProduct>(cpDto));


            }

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();


            return $"Successfully imported {categoryProducts.Count}";

        }

        public static string GetProductsInRange(ProductShopContext context)
        {

            var products = context
                .Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .ProjectTo<ExportProductsInRangeDto>()
                .ToList();


            var json = JsonConvert.SerializeObject(products,  Formatting.Indented);

            return json;
        }

        public static string GetSoldProducts(ProductShopContext context)
        {

            var users = context
                .Users
                .Where(u => u.ProductsSold.Any(p => p.BuyerId.HasValue))
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .ProjectTo<ExportAllUsersWithMinOneSoldItemDto>()
                .ToList();

            var json = JsonConvert.SerializeObject(users, Formatting.Indented);

            return json;

        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {

            var categories = context
                .Categories
                .OrderByDescending(c => c.CategoryProducts.Count)
                .ProjectTo<ExportCategoriesByProductsCountDto>()
                .ToArray();


            var json = JsonConvert.SerializeObject(categories, Formatting.Indented);

            return json;
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {

            // with AutoMapper
            //var users = context.Users
            //    .Where(u => u.ProductsSold.Any(p => p.BuyerId.HasValue))
            //    .OrderByDescending(u => u.ProductsSold.Count(p => p.BuyerId.HasValue))
            //    .ProjectTo<ExportUsersWithFullProductInfo>()
            //    .ToArray();

            // with manualMapper
            var users = context
                .Users
                .Where(u => u.ProductsSold.Any(p => p.BuyerId.HasValue))
                .OrderByDescending(u => u.ProductsSold.Count(p => p.BuyerId.HasValue))
                .Select(u => new ExportUsersWithFullProductInfo
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProducts = new ExportSoldProductsFullInfoDto()
                    {
                        Products = u.ProductsSold
                            .Where(p => p.BuyerId.HasValue)
                            .Select(p => new ExportProductDto
                            {
                                Name = p.Name,
                                Price = p.Price,
                            })
                            .ToArray()
                    }
                })
                .ToArray();


            ExportUsersInfoDto setDto = new ExportUsersInfoDto()
            {
                Users = users
            };


            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
            };

            return JsonConvert.SerializeObject(setDto, Formatting.Indented, settings);
        }

    }
}