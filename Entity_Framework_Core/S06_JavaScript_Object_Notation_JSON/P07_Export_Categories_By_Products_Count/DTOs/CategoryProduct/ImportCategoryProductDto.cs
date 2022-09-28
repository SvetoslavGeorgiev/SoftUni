namespace ProductShop.DTOs.CategoryProduct
{
    using Newtonsoft.Json;

    [JsonObject]
    public class ImportCategoryProductDto
    {


        [JsonProperty("CategoryId")]
        public int CategoryId { get; set; }

        [JsonProperty("ProductId")]
        public int ProductId { get; set; }


        //Json

        //"CategoryId": 11,
        //"ProductId": 6


        //Models

        //public int CategoryId { get; set; }
        //public Category Category { get; set; }

        //public int ProductId { get; set; }
        //public Product Product { get; set; }

    }
}
