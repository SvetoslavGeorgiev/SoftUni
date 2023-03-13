using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.DTOs.Users;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        

        public static void Main(string[] args)
        {
            

            using ProductShopContext dBcontext = new ProductShopContext();

            string inputJson = File.ReadAllText("../../../Datasets/users.json");

            dBcontext.Database.EnsureDeleted();
            dBcontext.Database.EnsureCreated();

            var result = ImportUsers(dBcontext, inputJson);

            Console.WriteLine(result);

        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {

            var mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            }));

            ImportUserDto[] userDtos = JsonConvert.DeserializeObject<ImportUserDto[]>(inputJson);

            ICollection<User> users = new List<User>();

            foreach (var dto in userDtos)
            {
                users.Add(mapper.Map<User>(dto));
            }


            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }

    }
}