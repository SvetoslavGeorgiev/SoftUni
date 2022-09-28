namespace ProductShop.DTOs.User
{
    using Newtonsoft.Json;
    using ProductShop.DTOs.Product;
    using System.Collections;
    using System.Collections.Generic;

    [JsonObject]
    public class ExportAllUsersWithMinOneSoldItemDto
    {
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("soldProducts")]
        public ExportAllProductsWithMinOneBuyerDto[] SoldProducts { get; set; }


    }
}
