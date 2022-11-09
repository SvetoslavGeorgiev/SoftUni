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

        public DbSet<Child> Children { get; set; } = null!;

        public DbSet<SchoolUser> SchoolUsers { get; set; } = null!;

        public DbSet<ParentUser> ParentUsers { get; set; } = null!; 

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


            base.OnModelCreating(builder);
        }
    }
}