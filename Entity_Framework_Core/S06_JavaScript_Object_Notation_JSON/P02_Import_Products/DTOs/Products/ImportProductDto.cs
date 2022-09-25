namespace ProductShop.DTOs.Products
{
    using Newtonsoft.Json;
    using ProductShop.Models;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.Json.Serialization;

    public class ImportProductDto
    {

        //public Product()
        //{
        //    this.CategoryProducts = new List<CategoryProduct>();
        //}

        //public int Id { get; set; }

        //public string Name { get; set; }

        //public decimal Price { get; set; }

        //public int SellerId { get; set; }
        //public User Seller { get; set; }

        //public int? BuyerId { get; set; }
        //public User Buyer { get; set; }

        //public ICollection<CategoryProduct> CategoryProducts { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }


        [JsonProperty("Price")]
        public decimal Price { get; set; }

        [JsonProperty("SellerId")]
        public int SellerId { get; set; }

        [JsonProperty("BuyerId")]
        public int? BuyerId { get; set; }

    }
}
