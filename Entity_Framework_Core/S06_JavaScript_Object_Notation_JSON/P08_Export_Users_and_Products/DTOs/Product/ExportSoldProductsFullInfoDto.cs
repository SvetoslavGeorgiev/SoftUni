namespace ProductShop.DTOs.Product
{
    using Newtonsoft.Json;
    using System.Linq;

    [JsonObject]
    public class ExportSoldProductsFullInfoDto
    {
        [JsonProperty("count")]
        public int Count => this.Products.Any() ? this.Products.Length : 0;

        [JsonProperty("products")]
        public ExportProductDto[] Products { get; set; }
    }
}
