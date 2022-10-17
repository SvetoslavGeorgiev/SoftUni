namespace WebShopDemo.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using WebShopDemo.Data.Models;
    using WebShopDemo.Data.Models.Account;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public ApplicationDbContext()
        {

        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);
        }


        public DbSet<Product> Products { get; set; }


    }
}