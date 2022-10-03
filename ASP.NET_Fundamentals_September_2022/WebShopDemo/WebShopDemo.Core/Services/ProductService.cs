namespace WebShopDemo.Core.Services
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using WebShopDemo.Core.Contracts;
    using WebShopDemo.Core.Models;
    using WebShopDemo.Data;
    using WebShopDemo.Data.Models;


    /// <summary>
    /// Manipulating product data
    /// </summary>
    public class ProductService : IProductService
    {
        //private readonly IConfiguration config;
        private readonly ApplicationDbContext dbContext;


        /// <summary>
        /// IoC
        /// </summary>
        /// <param name="_config"></param>
        /// <param name="_dbContext"></param>
        //public ProductService(IConfiguration _config, ApplicationDbContext _dbContext)
        public ProductService(ApplicationDbContext _dbContext)
        {
            //this.config = _config;
            this.dbContext = _dbContext;
        }

        public async Task Add(ProductDto productDto)
        {
            var product = new Product()
            {
                Name = productDto.Name,
                Price = productDto.Price,
                Quantity = productDto.Quantity,
            };


            await dbContext.Products.AddAsync(product);
            await dbContext.SaveChangesAsync();


        }

        public async Task Delete(Guid id)
        {
            var product = await dbContext
                .Products
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();

            if (product != null)
            {
                product.IsActive = false;

                await dbContext.SaveChangesAsync();
            }

        }




        /// <summary>
        /// Gets all products
        /// </summary>
        /// <returns>List of products</returns>
        public async Task<IEnumerable<ProductDto>> GetAll()
        {

            return await dbContext
                .Products
                .Where(p => p.IsActive)
                .Select(p => new ProductDto()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Quantity = p.Quantity,
                })
                .ToListAsync();
        }
    }
}
