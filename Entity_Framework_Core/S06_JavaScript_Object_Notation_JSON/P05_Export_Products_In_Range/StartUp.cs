using AutoMapper;
using AutoMapper.QueryableExtensions;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.DTOs.Category;
using ProductShop.DTOs.CategoryProduct;
using ProductShop.DTOs.Product;
using ProductShop.DTOs.User;
using ProductShop.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ProductShop
{
    public class StartUp
    {
        

        public static void Main(string[] args)
        {
            Mapper.Initialize(cfg => cfg.AddProfile(typeof(ProductShopProfile)));

            using ProductShopContext dBcontext = new ProductShopContext();

            //string inputJson = File.ReadAllText("../../../categories-products.json");

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "../../../Results/products-in-range.json");


            //dBcontext.Database.EnsureDeleted();
            //dBcontext.Database.EnsureCreated();

            var result = GetProductsInRange(dBcontext);

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
                .ProjectTo<ExportProductsInRange>()
                .ToList();


            var json = JsonConvert.SerializeObject(products,  Formatting.Indented);

            return json;
        }

    }
}