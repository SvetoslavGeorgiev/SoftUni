namespace ProductShop.DTOs.User
{
    using Newtonsoft.Json;
    using System.Linq;

    [JsonObject]
    public class ExportUsersInfoDto
    {

        [JsonProperty("usersCount")]
        public int UsersCount => this.Users.Any() ? this.Users.Length : 0;

        [JsonProperty("users")]
        public ExportUsersWithFullProductInfo[] Users { get; set; }
    }
}
