namespace SchoolMealsOrderingSystem.Tests.Services
{
    
    [TestFixture]
    public class ChildServicesTests
    {

        [Test]
        public async Task AddChildAsyncShouldAddChildToDatabasa()
        {

            using var data = DatabaseMock.Instance;

            await data.ParentUsers.AddAsync(new ParentUser
            {
                Id = "hgagfjsdhjdghfdshf",
                ParentsChildren = new List<ParentChild>(),
                Email = "test@test.bg",
                UserName = "Pesho",
                FirstName = "Pesho",
                LastName = "Goshov"
            });


            var child = new AddChildViewModel
            {

                FirstName = "Pesho",
                LastName = "Goshov",
                SchoolUserId = "khgdfhjadssa",
                Birthday = DateTime.Today.Date,
                YearInSchool = "3b",
                RelationToChild = "Father"
            };

            await data.SaveChangesAsync();

            var childServices = new ChildServices(data);

            await childServices.AddChildAsync(child, "hgagfjsdhjdghfdshf", "\thttps://dummy.restapiexample.com");


            Assert.That(data.Children.Count(), Is.EqualTo(1));


        }

        [Test]
        public async Task AddChildAsyncShouldThrowArgumentExceptionInvalidParentUserIdIfWrongId()
        {

            using var data = DatabaseMock.Instance;

            await data.ParentUsers.AddAsync(new ParentUser
            {
                Id = "hgagfjsdhjdghfdshf",
                ParentsChildren = new List<ParentChild>(),
                Email = "test@test.bg",
                UserName = "Pesho",
                FirstName = "Pesho",
                LastName = "Goshov"
            });


            var child = new AddChildViewModel
            {

                FirstName = "Pesho",
                LastName = "Goshov",
                SchoolUserId = "khgdfhjadssa",
                Birthday = DateTime.Today.Date,
                YearInSchool = "3b",
                RelationToChild = "Father"
            };

            await data.SaveChangesAsync();

            var childServices = new ChildServices(data);

            Assert.ThrowsAsync<ArgumentException>(async () => await childServices.AddChildAsync(child, "dsgfdsgfd", "\thttps://dummy.restapiexample.com"), InvalidParentUserId);


        }

        [Test]
        public async Task DeleteChildAsyncShouldMakeFlagIsDeletedToTrue()
        {

            using var data = DatabaseMock.Instance;

            var id = "042ada31-e666-41b6-a7ea-543d7372cf32";

            await data.Children.AddAsync(new Child
            {
                Id = Guid.Parse(id),
                FirstName = "Pesho",
                LastName = "Goshov",
                SchoolUserId = "khgdfhjadssa",
                Birthday = DateTime.Today.Date,
                ImageUrl = "\thttps://dummy.restapiexample.com",
                YearInSchool = "3b",
                ParentChildRelation = "Father"
            }); 

            await data.SaveChangesAsync();

            var childServices = new ChildServices(data);

            await childServices.DeleteChildAsync(Guid.Parse(id));

            var child = await data.Children.FirstOrDefaultAsync();

            Assert.That(child?.IsDeleted, Is.EqualTo(true));


        }

        [Test]
        public async Task EditChildAsyncShouldReturnCorectData()
        {
            using var data = DatabaseMock.Instance;

            var id = "042ada31-e666-41b6-a7ea-543d7372cf32";

            await data.Children.AddAsync(new Child
            {
                Id = Guid.Parse(id),
                FirstName = "Pesho",
                LastName = "Goshov",
                SchoolUserId = "khgdfhjadssa",
                ImageUrl = "\thttps://dummy.restapiexample.com",
                Birthday = DateTime.Today.Date,
                YearInSchool = "3b",
                ParentChildRelation = "Father"
            }); 

            await data.SaveChangesAsync();

            var childServices = new ChildServices(data);

            var model = new EditChildViewModel()
            {
                Id = Guid.Parse(id),
                FirstName = "Gosho",
                LastName = "Peshov",
                SchoolUserId = "jdkhsgfjksdhf",
                Birthday = DateTime.Today.AddDays(1).Date,
                YearInSchool = "5a",
                RelationToChild = "Mother"
            };

            await childServices.EditChildAsync(model);

            var child = await data.Children.FirstOrDefaultAsync();
            Assert.Multiple(() =>
            {
                Assert.That(child?.IsDeleted, Is.EqualTo(false));
                Assert.That(child?.Id.ToString(), Is.EqualTo(id));
                Assert.That(child?.FirstName, Is.EqualTo("Gosho"));
                Assert.That(child?.LastName, Is.EqualTo("Peshov"));
                Assert.That(child?.IsDeleted, Is.False);
                Assert.That(child?.ImageUrl, Is.EqualTo("\thttps://dummy.restapiexample.com"));
                Assert.That(child?.Birthday, Is.EqualTo(DateTime.Today.AddDays(1).Date));
                Assert.That(child?.YearInSchool, Is.EqualTo("5a"));
                Assert.That(child?.ParentChildRelation, Is.EqualTo("Mother"));
            });
        }

        [Test]
        public async Task GetAllMyChildrenAsyncShouldTakeAllChildrenForCurentUserIfChildNotDeleted()
        {

            using var data = DatabaseMock.Instance;

            await data.ParentUsers.AddRangeAsync(new List<ParentUser>()
            {
                new ParentUser()
                {
                    Id = "hgagfjsdhjdghfdshf",
                    ParentsChildren = new List<ParentChild>(),
                    Email = "test@test.bg",
                    UserName = "Pesho",
                    FirstName = "Pesho",
                    LastName = "Goshov"
                },
                new ParentUser()
                {
                    Id = "thryry",
                    ParentsChildren = new List<ParentChild>(),
                    Email = "test@abv.bg",
                    UserName = "Evlogia",
                    FirstName = "Evlogia",
                    LastName = "Goshova"
                }
            });

            await data.SchoolUsers.AddRangeAsync(new List<SchoolUser>()
            {
                new SchoolUser()
                {
                    Id = "fdsfdsf",
                    Email = "test@test.bg",
                    SchoolName = "Ima",
                    UserName = "test@test.bg"

                },
            });


            await data.Children.AddRangeAsync(new List<Child>()
            {
                new Child()
                {
                    Id = Guid.Parse("a58ec3e3998541eaa545949b804af7a9"),
                    FirstName = "dsfg",
                    LastName = "Goshov",
                    SchoolUserId = "fdsfdsf",
                    ImageUrl = "\thttps://dummy.restapiexample.com",
                    Birthday = DateTime.Today.Date,
                    YearInSchool = "3b",
                    ParentChildRelation = "Father",
                    ParentsChildren = new List<ParentChild>()
                    {
                        new ParentChild()
                        {
                            ParentUserId = "hgagfjsdhjdghfdshf",
                            ChildId = Guid.Parse("a58ec3e3998541eaa545949b804af7a9")
                        }
                    }

                },
                new Child()
                {
                    Id = Guid.Parse("bea7544c3e1c4811a9987355cf75bb72"),
                    FirstName = "Pesho",
                    LastName = "Goshfdov",
                    SchoolUserId = "fdsfdsf",
                    ImageUrl = "\thttps://dummy.restapiexample.com",
                    Birthday = DateTime.Today.Date,
                    YearInSchool = "1b",
                    ParentChildRelation = "Father",
                    ParentsChildren = new List<ParentChild>()
                    {
                        new ParentChild()
                        {
                            ParentUserId = "hgagfjsdhjdghfdshf",
                            ChildId = Guid.Parse("bea7544c3e1c4811a9987355cf75bb72")
                        }
                    }
                },
                new Child()
                {
                    Id = Guid.Parse("3f1d0fab607f4e2fad226b75d2e7e4e7"),
                    FirstName = "Pesho",
                    LastName = "Goshfdsov",
                    SchoolUserId = "fdsfdsf",
                    ImageUrl = "\thttps://dummy.restapiexample.com",
                    Birthday = DateTime.Today.Date,
                    YearInSchool = "4b",
                    ParentChildRelation = "Father",
                    ParentsChildren = new List<ParentChild>()
                    {
                        new ParentChild()
                        {
                            ParentUserId = "thryry",
                            ChildId = Guid.Parse("3f1d0fab607f4e2fad226b75d2e7e4e7")
                        }
                    }
                }
            });


            //var child = new AddChildViewModel
            //{

            //    FirstName = "dsfg",
            //    LastName = "Goshov",
            //    SchoolUserId = "fdsfdsf",
            //    Birthday = DateTime.Today.Date,
            //    YearInSchool = "3b",
            //    RelationToChild = "Father"
            //};
            //var child2 = new AddChildViewModel
            //{

            //    FirstName = "Pesho",
            //    LastName = "Goshfdsov",
            //    SchoolUserId = "fdsfdsf",
            //    Birthday = DateTime.Today.Date,
            //    YearInSchool = "4b",
            //    RelationToChild = "Father"
            //};
            //var child3 = new AddChildViewModel
            //{

            //    FirstName = "Pesho",
            //    LastName = "Goshfdov",
            //    SchoolUserId = "fdsfdsf",
            //    Birthday = DateTime.Today.Date,
            //    YearInSchool = "1b",
            //    RelationToChild = "Father"
            //};

            await data.SaveChangesAsync();

            var childServices = new ChildServices(data);


            
            //await childServices.AddChildAsync(child, "hgagfjsdhjdghfdshf");
            //await childServices.AddChildAsync(child2, "hgagfjsdhjdghfdshf");
            //await childServices.AddChildAsync(child3, "thryry");

            Assert.That(data.Children.Count(), Is.EqualTo(3));
            Assert.That(data.ParentUsers.Count(), Is.EqualTo(2));



            var children = await childServices.GetAllMyChildrenAsync("hgagfjsdhjdghfdshf");
            var children1 = await childServices.GetAllMyChildrenAsync("thryry");

            Assert.That(children.Count(), Is.EqualTo(2));
            Assert.That(children1.Count(), Is.EqualTo(1));



        }

        [Test]
        public async Task GetChildModelForEditAsyncShouldReturnCorrectViewModel()
        {

            using var data = DatabaseMock.Instance;

            var id = "042ada31-e666-41b6-a7ea-543d7372cf32";

            await data.Children.AddAsync(new Child
            {
                Id = Guid.Parse(id),
                FirstName = "Pesho",
                LastName = "Goshov",
                SchoolUser = new SchoolUser()
                {
                    Id = "khgdfhjadssa",
                    Email = "test@test.bg",
                    SchoolName = "Ima",
                    UserName = "test@test.bg"

                },
                Birthday = DateTime.Today.Date,
                ImageUrl = "\thttps://dummy.restapiexample.com",
                YearInSchool = "3b",
                ParentChildRelation = "Father"
            });

            await data.SaveChangesAsync();

            var childServices = new ChildServices(data);

            var child = await childServices.GetChildModelForEditAsync(Guid.Parse(id));


            Assert.Multiple(() =>
            {
                Assert.IsNotNull(child);
                Assert.That(child?.Id.ToString(), Is.EqualTo(id));
                Assert.That(child?.FirstName, Is.EqualTo("Pesho"));
                Assert.That(child?.LastName, Is.EqualTo("Goshov"));
                Assert.That(child?.Birthday, Is.EqualTo(DateTime.Today));
                Assert.That(child?.YearInSchool, Is.EqualTo("3b"));
                Assert.That(child?.RelationToChild, Is.EqualTo("Father"));
            });


        }

        [Test]
        public async Task GetChildModelForEditAsyncShouldThrowArgumentExceptionIfIdChildIsNull()
        {

            using var data = DatabaseMock.Instance;

            var id = "042ada31-e666-41b6-a7ea-543d7372cf32";
            await data.Children.AddAsync(new Child
            {
                Id = Guid.Parse(id),
                FirstName = "Pesho",
                LastName = "Goshov",
                SchoolUser = new SchoolUser()
                {
                    Id = "khgdfhjadssa",
                    Email = "test@test.bg",
                    SchoolName = "Ima",
                    UserName = "test@test.bg"

                },
                Birthday = DateTime.Today.Date,
                ImageUrl = "\thttps://dummy.restapiexample.com",
                YearInSchool = "3b",
                ParentChildRelation = "Father"
            });

            await data.SaveChangesAsync();

            var childServices = new ChildServices(data);

            Assert.ThrowsAsync<ArgumentException>(async () => await childServices.GetChildModelForEditAsync(Guid.Parse("3f1d0fab607f4e2fad226b75d2e7e4e7")), InvalidChildUserId);
        }
    }
}