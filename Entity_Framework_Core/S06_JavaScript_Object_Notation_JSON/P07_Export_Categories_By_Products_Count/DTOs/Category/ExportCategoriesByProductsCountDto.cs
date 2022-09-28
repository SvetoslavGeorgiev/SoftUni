namespace ProductShop.DTOs.Category
{
    using Newtonsoft.Json;

    [JsonObject]
    public class ExportCategoriesByProductsCountDto
    {

        [JsonProperty("category")]
        public string Name { get; set; }


        [JsonProperty("productsCount")]
        public int ProductsCount { get; set; }


        [JsonProperty("averagePrice")]
        public string AvgPrice { get; set; }


        [JsonProperty("totalRevenue")]
        public string TotalPrice { get; set; }


    }
}
