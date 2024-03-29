﻿using System;
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
            //Mapper.Initialize(cfg => cfg.AddProfile(typeof(ProductShopProfile)));

            

            using ProductShopContext dBcontext = new ProductShopContext();

            //string inputJson = File.ReadAllText("../../../Datasets/categories-products.json");

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "../../../Results/categories-by-products.json");


            //dBcontext.Database.EnsureDeleted();
            //dBcontext.Database.EnsureCreated();

            var result = GetCategoriesByProductsCount(dBcontext);

            

            File.WriteAllText(filePath, result);


        }

        //public static string ImportUsers(ProductShopContext context, string inputJson)
        //{

        //    ImportUserDto[] userDtos = JsonConvert.DeserializeObject<ImportUserDto[]>(inputJson);

        //    ICollection<User> users = new List<User>();

        //    foreach (var uDto in userDtos)
        //    {
        //        users.Add(Mapper.Map<User>(uDto));
        //    }


        //    context.Users.AddRange(users);
        //    context.SaveChanges();

        //    return $"Successfully imported {users.Count}";
        //}

        //public static string ImportProducts(ProductShopContext context, string inputJson)
        //{

        //    var productDtos = JsonConvert.DeserializeObject<ImportProductDto[]>(inputJson);

        //    ICollection<Product> products = new List<Product>();

        //    foreach (var pDto in productDtos)
        //    {

        //        products.Add(Mapper.Map<Product>(pDto));
        //    }

        //    context.Products.AddRange(products);
        //    context.SaveChanges();


        //    return $"Successfully imported {products.Count}";



        //}

        //public static string ImportCategories(ProductShopContext context, string inputJson)
        //{

        //    var categoryDtos = JsonConvert.DeserializeObject<ImportCategoryDto[]>(inputJson);

        //    ICollection<Category> categories = new List<Category>();

        //    foreach (var cDto in categoryDtos)
        //    {
        //        if (cDto.Name == null)
        //        {
        //            continue;
        //        }
        //        categories.Add(Mapper.Map<Category>(cDto));
        //    }

        //    context.Categories.AddRange(categories);
        //    context.SaveChanges();


        //    return $"Successfully imported {categories.Count}";
        //}


        //public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        //{

        //    ImportCategoryProductDto[] importCategoryProductDtos = JsonConvert.DeserializeObject<ImportCategoryProductDto[]>(inputJson);

        //    ICollection<CategoryProduct> categoryProducts = new List<CategoryProduct>();

        //    foreach (var cpDto in importCategoryProductDtos)
        //    {

        //        categoryProducts.Add(Mapper.Map<CategoryProduct>(cpDto));


        //    }

        //    context.CategoryProducts.AddRange(categoryProducts);
        //    context.SaveChanges();


        //    return $"Successfully imported {categoryProducts.Count}";

        //}

        //public static string GetProductsInRange(ProductShopContext context)
        //{

        //    var products = context
        //        .Products
        //        .Where(p => p.Price >= 500 && p.Price <= 1000)
        //        .OrderBy(p => p.Price)
        //        .ProjectTo<ExportProductsInRangeDto>()
        //        .ToList();


        //    var json = JsonConvert.SerializeObject(products,  Formatting.Indented);

        //    return json;
        //}

        //public static string GetSoldProducts(ProductShopContext context, MapperConfiguration mapperConfiguration)
        //{

        //    var users = context
        //        .Users
        //        .Where(u => u.ProductsSold.Any(p => p.BuyerId.HasValue))
        //        .OrderBy(u => u.LastName)
        //        .ThenBy(u => u.FirstName)
        //        .ProjectTo<ExportAllUsersWithMinOneSoldItemDto>(mapperConfiguration)
        //        .ToList();

        //    var json = JsonConvert.SerializeObject(users, Formatting.Indented);

        //    return json;

        //}

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {

            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddMaps(typeof(ProductShopProfile).Assembly);
            });

            var categories = context
                .Categories
                .ProjectTo<ExportCategoriesByProductsCountDto>(mapperConfiguration)
                .OrderByDescending(p => p.ProductsCount)
                .ToArray();


            var json = JsonConvert.SerializeObject(categories, Formatting.Indented);

            return json;

            //var categories = context.Categories
            //    .OrderByDescending(c => c.CategoriesProducts.Count)
            //    .Select(c => new
            //    {
            //        category = c.Name,
            //        productsCount = c.CategoriesProducts.Count,
            //        averagePrice = Math.Round((double)c.CategoriesProducts.Average(p => p.Product.Price), 2),
            //        totalRevenue = Math.Round((double)c.CategoriesProducts.Sum(p => p.Product.Price), 2)
            //    })
            //    .ToArray();

            //return JsonConvert.SerializeObject(categories, Formatting.Indented);

        }

    }
}