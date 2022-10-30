namespace SchoolMealsOrderingSystem.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class SchoolMealsOrderingSystemDbContext : IdentityDbContext
    {
        public SchoolMealsOrderingSystemDbContext(DbContextOptions<SchoolMealsOrderingSystemDbContext> options)
            : base(options)
        {
        }
    }
}