namespace SchoolMealsOrderingSystem.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using SchoolMealsOrderingSystem.Data.Entities;

    public class SchoolMealsOrderingSystemDbContext : IdentityDbContext<ApplicationUser>
    {
        public SchoolMealsOrderingSystemDbContext(DbContextOptions<SchoolMealsOrderingSystemDbContext> options)
            : base(options)
        {
        }

        DbSet<Child> Children { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {


            builder.Entity<ParentChild>()
                .HasKey(x => new { x.ParentUserId, x.ChildId });

            builder.Entity<ApplicationUser>()
                .Property(u => u.UserName)
                .HasMaxLength(20)
                .IsRequired();

            builder.Entity<ApplicationUser>()
                .Property(u => u.Email)
                .HasMaxLength(60)
                .IsRequired();



           // builder
           //    .Entity<Book>()
           //    .HasData(new Book()
           //    {
           //        Id = 5,
           //        Title = "Lorem Ipsum",
           //        Author = "Dolor Sit",
           //        ImageUrl = "https://img.freepik.com/free-psd/book-cover-mock-up-arrangement_23-2148622888.jpg?w=826&t=st=1666106877~exp=1666107477~hmac=5dea3e5634804683bccfebeffdbde98371db37bc2d1a208f074292c862775e1b",
           //        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
           //        CategoryId = 1,
           //        Rating = 9.5m
           //    });

           // builder
           //.Entity<Category>()
           //.HasData(new Category()
           //{
           //    Id = 1,
           //    Name = "Action"
           //},
           //new Category()
           //{
           //    Id = 2,
           //    Name = "Biography"
           //},
           //new Category()
           //{
           //    Id = 3,
           //    Name = "Children"
           //},
           //new Category()
           //{
           //    Id = 4,
           //    Name = "Crime"
           //},
           //new Category()
           //{
           //    Id = 5,
           //    Name = "Fantasy"
           //});


            base.OnModelCreating(builder);
        }
    }
}