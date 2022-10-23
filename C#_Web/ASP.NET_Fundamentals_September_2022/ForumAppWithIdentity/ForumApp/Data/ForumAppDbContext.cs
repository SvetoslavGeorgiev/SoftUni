namespace ForumApp.Data
{
    using ForumApp.Data.Entities;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class ForumAppDbContext : IdentityDbContext<User>
    {
        public ForumAppDbContext(DbContextOptions<ForumAppDbContext> options)
            : base(options)
        {
            
        }


        public DbSet<Post> Posts { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Post>()
                .Property(p => p.IsDeleted)
                .HasDefaultValue(false);

            builder.Entity<UserPost>()
                .HasKey(x => new { x.UserId, x.PostId });

            builder.ApplyConfiguration<Post>(new PostConfiguration());


            base.OnModelCreating(builder);
        }
    }
}