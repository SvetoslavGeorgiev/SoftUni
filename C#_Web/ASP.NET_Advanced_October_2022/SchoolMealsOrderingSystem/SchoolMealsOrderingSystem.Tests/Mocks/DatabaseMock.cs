namespace SchoolMealsOrderingSystem.Tests.Mocks
{
    using Microsoft.EntityFrameworkCore;
    using SchoolMealsOrderingSystem.Data;

    public static class DatabaseMock
    {
        public static SchoolMealsOrderingSystemDbContext Instance
        {
            get
            {
                var dbContextOptions = new DbContextOptionsBuilder<SchoolMealsOrderingSystemDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString())
                    .Options;

                return new SchoolMealsOrderingSystemDbContext(dbContextOptions);
            }
        }

    }
}
