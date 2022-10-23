namespace ForumApp.Data
{
    using ForumApp.Data.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            List<Post> posts = GetPosts();
            builder.HasData(posts);
        }

        private List<Post> GetPosts()
        {
            return new List<Post>()
            {
                new Post
                {
                Id = 1,
                Title = "My first post",
                Content = "My first post will be about performing CRUD operations in MVC. It's so much fun!"
                },
                new Post
                {
                Id = 2,
                Title = "My second post",
                Content = "This is my second post. CRUD operations in MVC are getting more and more interesting!"
                },
                new Post
                {
                Id = 3,
                Title = "My third post",
                Content = "Hello there! I'm getting better and better with the CRUD operations in MVC. Stay tuned!"
                }
            };

        }
    }
}