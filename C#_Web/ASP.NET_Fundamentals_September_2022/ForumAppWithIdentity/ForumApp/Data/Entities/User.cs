namespace ForumApp.Data.Entities
{
    using Microsoft.AspNetCore.Identity;

    public class User : IdentityUser
    {


        public List<UserPost> UsersPosts { get; set; } = new List<UserPost>();


    }
}
