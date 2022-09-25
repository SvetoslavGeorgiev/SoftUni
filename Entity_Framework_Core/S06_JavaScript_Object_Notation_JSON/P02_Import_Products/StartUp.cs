using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.DTOs.Products;
using ProductShop.DTOs.Users;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        

        public static void Main(string[] args)
        {
            Mapper.Initialize(cfg => cfg.AddProfile(typeof(ProductShopProfile)));

            using ProductShopContext dBcontext = new ProductShopContext();

            string inputJson = File.ReadAllText("../../../Datasets/products.json");

            //dBcontext.Database.EnsureDeleted();
            //dBcontext.Database.EnsureCreated();

            var result = ImportProducts(dBcontext, inputJson);

            Console.WriteLine(result);

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

    }
}