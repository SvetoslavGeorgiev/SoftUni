namespace SchoolMealsOrderingSystem.Tests.Services
{
    [TestFixture]
    public class SchoolServicesTests
    {

        [Test]
        public async Task GetAllChildrenInSelectedSchoolAsyncShouldReturnCorectData()
        {

            using var data = DatabaseMock.Instance;

            await data.SchoolUsers.AddAsync(new SchoolUser
            {
                Id = "hgagfjsdhjdghfdshf",
                Email = "test@test.bg",
                UserName = "test@test.bg",
                SchoolName = "hdsfhdsfsdf",
                IsSchool = true
            });


            await data.Children.AddAsync(new Child
            {

                FirstName = "Pesho",
                LastName = "Goshov",
                SchoolUserId = "hgagfjsdhjdghfdshf",
                Birthday = DateTime.Today.Date,
                YearInSchool = "3b",
                ParentChildRelation = "Father"
            });

            await data.Children.AddAsync(new Child
            {

                FirstName = "Pesho",
                LastName = "Goshov",
                SchoolUserId = "hgagfjsdhjdghfdshf",
                Birthday = DateTime.Today.Date,
                YearInSchool = "3b",
                ParentChildRelation = "Father"
            });

            await data.Children.AddAsync(new Child
            {

                FirstName = "pesh",
                LastName = "Goshov",
                SchoolUserId = "hgagfjsdhjdghfdshf",
                Birthday = DateTime.Today.Date,
                YearInSchool = "3b",
                ParentChildRelation = "Father"
            });



            await data.Children.AddAsync(new Child
            {

                FirstName = "Pesho",
                LastName = "Goshfdsov",
                SchoolUserId = "fdsfdsf",
                Birthday = DateTime.Today.Date,
                YearInSchool = "4b",
                ParentChildRelation = "Father"
            });

            await data.Children.AddAsync(new Child
            {

                FirstName = "Pesho",
                LastName = "Goshfdov",
                SchoolUserId = "fdsfdsf",
                Birthday = DateTime.Today.Date,
                YearInSchool = "1b",
                ParentChildRelation = "Father"
            });

            await data.SaveChangesAsync();

            var schoolServices = new SchoolServices(data);

            var result = await schoolServices.GetAllChildrenInSelectedSchoolAsync("hgagfjsdhjdghfdshf");


            Assert.That(data.Children.Count(), Is.EqualTo(5));
            Assert.That(result.Count(), Is.EqualTo(3));


        }


        [Test]
        public async Task GetSchoolsAsyncShouldReturnAllNotDeletedSchools()
        {
            using var data = DatabaseMock.Instance;

            await data.SchoolUsers.AddRangeAsync(new List<SchoolUser>
            {
                new SchoolUser()
                {
                    Id = "gdhfgfdhs",
                    Email = "test@test.bg",
                    UserName = "test@test.bg",
                    SchoolName = "hdsfhdsfsdf",
                    IsSchool = true,
                    IsDeleted = true,
                },
                new SchoolUser()
                {
                    Id = "dfgfdgadfg",
                    Email = "test@test.bg",
                    UserName = "test@test.bg",
                    SchoolName = "hdsfhdsfsdf",
                    IsSchool = true,
                    IsDeleted = false,
                },
                new SchoolUser()
                {
                    Id = "hgagfjsdhjfdgdfdgddghfdshf",
                    Email = "test@test.bg",
                    UserName = "test@test.bg",
                    SchoolName = "hdsfhdsfsdf",
                    IsSchool = true,
                    IsDeleted = false,
                    
                }

            });

            await data.SaveChangesAsync();

            var schoolServices = new SchoolServices(data);

            var result = await schoolServices.GetSchoolsAsync();

            Assert.That(result.Count(), Is.EqualTo(2));

        }

    }
}
