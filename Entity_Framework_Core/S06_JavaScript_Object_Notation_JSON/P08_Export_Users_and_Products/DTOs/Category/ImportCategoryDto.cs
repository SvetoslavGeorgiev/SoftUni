namespace ProductShop.DTOs.Category
{
    using Newtonsoft.Json;
    using ProductShop.Models;
    using System.Collections.Generic;

    [JsonObject]
    public class ImportCategoryDto
    {


        //public Category()
        //{
        //    this.CategoryProducts = new List<CategoryProduct>();
        //}

        //public int Id { get; set; }

        //public string Name { get; set; }

        //public ICollection<CategoryProduct> CategoryProducts { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }



    }
}
