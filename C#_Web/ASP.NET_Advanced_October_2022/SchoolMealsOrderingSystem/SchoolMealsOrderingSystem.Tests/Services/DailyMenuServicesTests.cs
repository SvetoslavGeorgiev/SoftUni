namespace SchoolMealsOrderingSystem.Tests.Services
{
    
    

    [TestFixture]
    public class DailyMenuServicesTests
    {
        [Test]
        public async Task AddDailyMenuAsyncShouldAddDailyMenuToDatabase()
        {

            using var data = DatabaseMock.Instance;

            await data.Children.AddAsync(new Child()
            {
                Id = Guid.Parse("a58ec3e3998541eaa545949b804af7a9"),
                FirstName = "dsfg",
                LastName = "Goshov",
                SchoolUserId = "fdsfdsf",
                Birthday = DateTime.Today.Date,
                YearInSchool = "3b",
                ParentChildRelation = "Father",
                ParentsChildren = new List<ParentChild>()
            });

            var menu = new MealsForParentToChooseViewModel()
            {
                ChildId = Guid.Parse("a58ec3e3998541eaa545949b804af7a9"),
                DayOfTheWeek = DayOfWeek.Monday,
                SoupId = Guid.Parse("14b909a2431f499a80bfb446427b376d"),
                MainDishId = Guid.Parse("ea8dae10761e4549b8a6e08d717abc69"),
                DessertsId = Guid.Parse("a668d112dac4416a849c4c4a6ddccbe4"),
                SchoolId = "dufgitiuaodisa"
            };

            await data.SaveChangesAsync();

            var dailyManuServices = new DailyManuServices(data);

            await dailyManuServices.AddDailyMenuAsync(menu);


            Assert.That(data.DailyMenus.Count(), Is.EqualTo(1));


        }

        [Test]
        public async Task AddDailyMenuAsyncShouldThrowArgumentExceptionIfIdChildIsNull()
        {

            using var data = DatabaseMock.Instance;

            await data.Children.AddAsync(new Child()
            {
                Id = Guid.Parse("a58ec3e3998541eaa545949b804af7a9"),
                FirstName = "dsfg",
                LastName = "Goshov",
                SchoolUserId = "fdsfdsf",
                Birthday = DateTime.Today.Date,
                YearInSchool = "3b",
                ParentChildRelation = "Father",
                ParentsChildren = new List<ParentChild>()
            });

            var menu = new MealsForParentToChooseViewModel()
            {
                ChildId = Guid.Parse("3365fdc1d3ae4654873c7eba757eb66a"),
                DayOfTheWeek = DayOfWeek.Monday,
                SoupId = Guid.Parse("14b909a2431f499a80bfb446427b376d"),
                MainDishId = Guid.Parse("ea8dae10761e4549b8a6e08d717abc69"),
                DessertsId = Guid.Parse("a668d112dac4416a849c4c4a6ddccbe4"),
                SchoolId = "dufgitiuaodisa"
            };

            await data.SaveChangesAsync();

            var dailyManuServices = new DailyManuServices(data);

            Assert.ThrowsAsync<ArgumentException>(async () => await dailyManuServices.AddDailyMenuAsync(menu), InvalidChildUserId);


        }

        [Test]
        public async Task AddDailyMenuAsyncShouldThrowArgumentExceptionIfMenuWithSameDayIsAlreadyInDatabase()
        {

            using var data = DatabaseMock.Instance;

            await data.Children.AddAsync(new Child()
            {
                Id = Guid.Parse("a58ec3e3998541eaa545949b804af7a9"),
                FirstName = "dsfg",
                LastName = "Goshov",
                SchoolUserId = "fdsfdsf",
                Birthday = DateTime.Today.Date,
                YearInSchool = "3b",
                ParentChildRelation = "Father",
                ParentsChildren = new List<ParentChild>()
            });

            var menu = new MealsForParentToChooseViewModel()
            {
                ChildId = Guid.Parse("a58ec3e3998541eaa545949b804af7a9"),
                DayOfTheWeek = DayOfWeek.Monday,
                SoupId = Guid.Parse("14b909a2431f499a80bfb446427b376d"),
                MainDishId = Guid.Parse("ea8dae10761e4549b8a6e08d717abc69"),
                DessertsId = Guid.Parse("a668d112dac4416a849c4c4a6ddccbe4"),
                SchoolId = "dufgitiuaodisa"
            };

            var newMenu = new MealsForParentToChooseViewModel()
            {
                ChildId = Guid.Parse("a58ec3e3998541eaa545949b804af7a9"),
                DayOfTheWeek = DayOfWeek.Monday,
                SoupId = Guid.Parse("14b909a2431f499a80bfb446427b376d"),
                MainDishId = Guid.Parse("ea8dae10761e4549b8a6e08d717abc69"),
                DessertsId = Guid.Parse("a668d112dac4416a849c4c4a6ddccbe4"),
                SchoolId = "dufgitiuaodisa"
            };


            await data.SaveChangesAsync();

            var dailyManuServices = new DailyManuServices(data);

            await dailyManuServices.AddDailyMenuAsync(menu);

            Assert.ThrowsAsync<ArgumentException>(async () => await dailyManuServices.AddDailyMenuAsync(newMenu), "Меню за този ден вече съществива");


        }

        [Test]
        public async Task DeleteDailyMenuAsyncShouldDeleteDailyMenuFromDatabase()
        {

            using var data = DatabaseMock.Instance;

            await data.Children.AddAsync(new Child()
            {
                Id = Guid.Parse("a58ec3e3998541eaa545949b804af7a9"),
                FirstName = "dsfg",
                LastName = "Goshov",
                SchoolUserId = "fdsfdsf",
                Birthday = DateTime.Today.Date,
                YearInSchool = "3b",
                ParentChildRelation = "Father",
                ParentsChildren = new List<ParentChild>()
            });

            await data.AddAsync(new DailyMenu()
            {
                Id = Guid.Parse("2066101b5b734ca9aa8c63e2c6f429e1"),
                ChildId = Guid.Parse("a58ec3e3998541eaa545949b804af7a9"),
                Name = DayOfWeek.Monday,
                SoupId = Guid.Parse("14b909a2431f499a80bfb446427b376d"),
                MainDishId = Guid.Parse("ea8dae10761e4549b8a6e08d717abc69"),
                DessertId = Guid.Parse("a668d112dac4416a849c4c4a6ddccbe4"),
                CreatedOn = DateTime.Now,

            });

            await data.SaveChangesAsync();

            var dailyManuServices = new DailyManuServices(data);


            Assert.That(data.DailyMenus.Count(), Is.EqualTo(1));

            await dailyManuServices.DeleteDailyMenuAsync(Guid.Parse("2066101b5b734ca9aa8c63e2c6f429e1"));

            Assert.That(data.DailyMenus.Count(), Is.EqualTo(0));




        }

        [Test]
        public async Task GetAllDailyMenusAsyncShouldGetAllDailyMenusFromDatabasaForCurrentChild()
        {

            using var data = DatabaseMock.Instance;

            await data.Children.AddAsync(new Child()
            {
                Id = Guid.Parse("a58ec3e3998541eaa545949b804af7a9"),
                FirstName = "dsfg",
                LastName = "Goshov",
                SchoolUserId = "fdsfdsf",
                Birthday = DateTime.Today.Date,
                YearInSchool = "3b",
                ParentChildRelation = "Father",
                ParentsChildren = new List<ParentChild>()
            });

            await data.AddRangeAsync(new List<DailyMenu>()
            {
                new DailyMenu()
                {
                    Id = Guid.Parse("14b909a2431f499a80bfb446427b376d"),
                    ChildId = Guid.Parse("a58ec3e3998541eaa545949b804af7a9"),
                    Name = DayOfWeek.Monday,
                    SoupId = Guid.Parse("14b909a2431f499a80bfb446427b376d"),
                    MainDishId = Guid.Parse("ea8dae10761e4549b8a6e08d717abc69"),
                    DessertId = Guid.Parse("a668d112dac4416a849c4c4a6ddccbe4"),
                    CreatedOn = DateTime.Now,
                },
                new DailyMenu()
                {
                    Id = Guid.Parse("2066101b5b734ca9aa8c63e2c6f429e1"),
                    ChildId = Guid.Parse("a58ec3e3998541eaa545949b804af7a9"),
                    Name = DayOfWeek.Monday,
                    SoupId = Guid.Parse("14b909a2431f499a80bfb446427b376d"),
                    MainDishId = Guid.Parse("ea8dae10761e4549b8a6e08d717abc69"),
                    DessertId = Guid.Parse("a668d112dac4416a849c4c4a6ddccbe4"),
                    CreatedOn = DateTime.Now,
                },
                new DailyMenu()
                {
                    Id = Guid.Parse("a668d112dac4416a849c4c4a6ddccbe4"),
                    ChildId = Guid.Parse("14b909a2431f499a80bfb446427b376d"),
                    Name = DayOfWeek.Monday,
                    SoupId = Guid.Parse("14b909a2431f499a80bfb446427b376d"),
                    MainDishId = Guid.Parse("ea8dae10761e4549b8a6e08d717abc69"),
                    DessertId = Guid.Parse("a668d112dac4416a849c4c4a6ddccbe4"),
                    CreatedOn = DateTime.Now,
                }
            });

            await data.SaveChangesAsync();

            var dailyManuServices = new DailyManuServices(data);


            Assert.That(data.DailyMenus.Count(), Is.EqualTo(3));

            var menus = await dailyManuServices.GetAllDailyMenusAsync(Guid.Parse("a58ec3e3998541eaa545949b804af7a9"));

            Assert.That(menus.Count(), Is.EqualTo(2));


        }

        [Test]
        public async Task GetAllDailyMenusAsyncShouldThrowArgumentExceptionIfChildIdIsInvalid()
        {

            using var data = DatabaseMock.Instance;

            await data.Children.AddAsync(new Child()
            {
                Id = Guid.Parse("a58ec3e3998541eaa545949b804af7a9"),
                FirstName = "dsfg",
                LastName = "Goshov",
                SchoolUserId = "fdsfdsf",
                Birthday = DateTime.Today.Date,
                YearInSchool = "3b",
                ParentChildRelation = "Father",
                ParentsChildren = new List<ParentChild>()
            });

            await data.AddRangeAsync(new List<DailyMenu>()
            {
                new DailyMenu()
                {
                    Id = Guid.Parse("14b909a2431f499a80bfb446427b376d"),
                    ChildId = Guid.Parse("a58ec3e3998541eaa545949b804af7a9"),
                    Name = DayOfWeek.Monday,
                    SoupId = Guid.Parse("14b909a2431f499a80bfb446427b376d"),
                    MainDishId = Guid.Parse("ea8dae10761e4549b8a6e08d717abc69"),
                    DessertId = Guid.Parse("a668d112dac4416a849c4c4a6ddccbe4"),
                    CreatedOn = DateTime.Now,
                },
                new DailyMenu()
                {
                    Id = Guid.Parse("2066101b5b734ca9aa8c63e2c6f429e1"),
                    ChildId = Guid.Parse("a58ec3e3998541eaa545949b804af7a9"),
                    Name = DayOfWeek.Monday,
                    SoupId = Guid.Parse("14b909a2431f499a80bfb446427b376d"),
                    MainDishId = Guid.Parse("ea8dae10761e4549b8a6e08d717abc69"),
                    DessertId = Guid.Parse("a668d112dac4416a849c4c4a6ddccbe4"),
                    CreatedOn = DateTime.Now,
                },
                new DailyMenu()
                {
                    Id = Guid.Parse("a668d112dac4416a849c4c4a6ddccbe4"),
                    ChildId = Guid.Parse("14b909a2431f499a80bfb446427b376d"),
                    Name = DayOfWeek.Monday,
                    SoupId = Guid.Parse("14b909a2431f499a80bfb446427b376d"),
                    MainDishId = Guid.Parse("ea8dae10761e4549b8a6e08d717abc69"),
                    DessertId = Guid.Parse("a668d112dac4416a849c4c4a6ddccbe4"),
                    CreatedOn = DateTime.Now,
                }
            });

            await data.SaveChangesAsync();

            var dailyManuServices = new DailyManuServices(data);


            Assert.That(data.DailyMenus.Count(), Is.EqualTo(3));

            Assert.ThrowsAsync<ArgumentException>(async () => await dailyManuServices.GetAllDailyMenusAsync(Guid.Parse("a668d112dac4416a849c4c4a6ddccbe4")), InvalidChildUserId);


        }

        [Test]
        public async Task GetMealsForParentsToChooseShouldGetAllSelectedMealsFromSchoolFromDatabaseForCurrentChild()
        {

            using var data = DatabaseMock.Instance;

            await data.Children.AddAsync(new Child()
            {
                Id = Guid.Parse("a58ec3e3998541eaa545949b804af7a9"),
                FirstName = "dsfg",
                LastName = "Goshov",
                SchoolUserId = "fdsfdsf",
                Birthday = DateTime.Today.Date,
                YearInSchool = "3b",
                ParentChildRelation = "Father",
                ParentsChildren = new List<ParentChild>()
            });

            await data.SchoolUsers.AddRangeAsync(new List<SchoolUser>()
            {
                new SchoolUser()
                {
                    Id = "fdsfdsf",
                    Email = "test@test.bg",
                    SchoolName = "Ima",
                    UserName = "test@test.bg",
                    IsSchool = true,
                    Soups = new List<Soup>()
                    {
                        new Soup()
                        {
                            Id = Guid.Parse("14b909a2431f499a80bfb446427b376d"),
                            Ingredients = "dsada",
                            Allergens = "jdhf",
                            Name = "nene",
                            ImageUrl = "juhdsf",
                            IsSelected = true,
                            SchoolUserId = "fdsfdsf"
                        },
                        new Soup()
                        {
                            Id = Guid.Parse("ea8dae10761e4549b8a6e08d717abc69"),
                            Ingredients = "dsada",
                            Allergens = "jdhf",
                            Name = "nene",
                            ImageUrl = "juhdsf",
                            IsSelected = true,
                            SchoolUserId = "fdsfdsf"
                        },
                        new Soup()
                        {
                            Id = Guid.Parse("3365fdc1d3ae4654873c7eba757eb66a"),
                            Ingredients = "dsada",
                            Allergens = "jdhf",
                            Name = "nene",
                            ImageUrl = "juhdsf",
                            IsSelected = false,
                            SchoolUserId = "fdsfdsf"
                        }
                    },
                    MainDishes = new List<MainDish>()
                    {
                        new MainDish()
                        {
                            Id = Guid.Parse("14b909a2431f499a80bfb446427b376d"),
                            Ingredients = "dsada",
                            Allergens = "jdhf",
                            Name = "nene",
                            ImageUrl = "juhdsf",
                            IsSelected = true,
                            SchoolUserId = "fdsfdsf"
                        },
                        new MainDish()
                        {
                            Id = Guid.Parse("ea8dae10761e4549b8a6e08d717abc69"),
                            Ingredients = "dsada",
                            Allergens = "jdhf",
                            Name = "nene",
                            ImageUrl = "juhdsf",
                            IsSelected = false,
                            SchoolUserId = "fdsfdsf"
                        },
                        new MainDish()
                        {
                            Id = Guid.Parse("3365fdc1d3ae4654873c7eba757eb66a"),
                            Ingredients = "dsada",
                            Allergens = "jdhf",
                            Name = "nene",
                            ImageUrl = "juhdsf",
                            IsSelected = false,
                            SchoolUserId = "fdsfdsf"
                        }
                    },
                    Desserts = new List<Dessert>()
                    {
                        new Dessert()
                        {
                            Id = Guid.Parse("14b909a2431f499a80bfb446427b376d"),
                            Ingredients = "dsada",
                            Allergens = "jdhf",
                            Name = "nene",
                            ImageUrl = "juhdsf",
                            IsSelected = true,
                            SchoolUserId = "fdsfdsf"
                        },
                        new Dessert()
                        {
                            Id = Guid.Parse("ea8dae10761e4549b8a6e08d717abc69"),
                            Ingredients = "dsada",
                            Allergens = "jdhf",
                            Name = "nene",
                            ImageUrl = "juhdsf",
                            IsSelected = true,
                            SchoolUserId = "fdsfdsf"
                        },
                        new Dessert()
                        {
                            Id = Guid.Parse("3365fdc1d3ae4654873c7eba757eb66a"),
                            Ingredients = "dsada",
                            Allergens = "jdhf",
                            Name = "nene",
                            ImageUrl = "juhdsf",
                            IsSelected = true,
                            SchoolUserId = "fdsfdsf"
                        }
                    }
                },
                new SchoolUser()
                {
                    Id = "jkdghsafjd",
                    Email = "test@ast.bg",
                    SchoolName = "ok",
                    UserName = "test@ast.bg",
                    Soups = new List<Soup>()
                    {
                        new Soup()
                        {
                            Id = Guid.Parse("47938d43913042d9a6f3223d0915dfa1"),
                            Ingredients = "dsada",
                            Allergens = "jdhf",
                            Name = "nene",
                            ImageUrl = "juhdsf",
                            IsSelected = true,
                            SchoolUserId = "jkdghsafjd"
                        },
                        new Soup()
                        {
                            Id = Guid.Parse("646e575431ab4ed0a8496976772f2dcb"),
                            Ingredients = "dsada",
                            Allergens = "jdhf",
                            Name = "nene",
                            ImageUrl = "juhdsf",
                            IsSelected = true,
                            SchoolUserId = "jkdghsafjd"
                        },
                        new Soup()
                        {
                            Id = Guid.Parse("45145b93b0064424b0f6601b73837184"),
                            Ingredients = "dsada",
                            Allergens = "jdhf",
                            Name = "nene",
                            ImageUrl = "juhdsf",
                            IsSelected = false,
                            SchoolUserId = "jkdghsafjd"
                        }
                    },
                },
            });

            await data.SaveChangesAsync();

            var soups = data.Soups.ToList();
            var mainDishes = data.MainDishes.ToList();
            var desserts = data.Desserts.ToList();

            var dailyManuServices = new DailyManuServices(data);


            Assert.That(data.Children.Count(), Is.EqualTo(1));
            Assert.That(data.Soups.Count(), Is.EqualTo(6));
            Assert.That(data.SchoolUsers.Count(), Is.EqualTo(2));
            Assert.That(data.MainDishes.Count(), Is.EqualTo(3));
            Assert.That(data.Desserts.Count(), Is.EqualTo(3));

            var menuForMarents = await dailyManuServices.GetMealsForParentsToChoose(Guid.Parse("a58ec3e3998541eaa545949b804af7a9"));

            Assert.That(menuForMarents.Soups.Count, Is.EqualTo(2));
            Assert.That(menuForMarents.MainDishes.Count, Is.EqualTo(1));
            Assert.That(menuForMarents.Desserts.Count, Is.EqualTo(3));
            Assert.That(menuForMarents.SchoolId, Is.EqualTo("fdsfdsf"));
            Assert.That(menuForMarents.ChildId, Is.EqualTo(Guid.Parse("a58ec3e3998541eaa545949b804af7a9")));


        }

        [Test]
        public async Task GetMealsForParentsToChooseShouldthrownewArgumentExceptionIfChildIdIsInvalid()
        {

            using var data = DatabaseMock.Instance;

            await data.Children.AddAsync(new Child()
            {
                Id = Guid.Parse("45145b93b0064424b0f6601b73837184"),
                FirstName = "dsfg",
                LastName = "Goshov",
                SchoolUserId = "fdsfdsf",
                Birthday = DateTime.Today.Date,
                YearInSchool = "3b",
                ParentChildRelation = "Father",
                ParentsChildren = new List<ParentChild>()
            });

            await data.SaveChangesAsync();

            var dailyManuServices = new DailyManuServices(data);

            Assert.That(data.Children.Count(), Is.EqualTo(1));

            Assert.ThrowsAsync<ArgumentException>(async () => await dailyManuServices.GetMealsForParentsToChoose(Guid.Parse("a58ec3e3998541eaa545949b804af7a9")), InvalidChildUserId);

        }

        //[Test]
        //public async Task GetMealsForParentsToChooseShouldthrownewArgumentExceptionIfSchoolUserIsNull()
        //{

        //    using var data = DatabaseMock.Instance;

        //    await data.Children.AddAsync(new Child()
        //    {
        //        Id = Guid.Parse("45145b93b0064424b0f6601b73837184"),
        //        FirstName = "dsfg",
        //        LastName = "Goshov",
        //        Birthday = DateTime.Today.Date,
        //        YearInSchool = "3b",
        //        SchoolUserId = "hjgadvfdaf",
        //        ParentChildRelation = "Father",
        //        ParentsChildren = new List<ParentChild>(),
        //    });

        //    await data.SaveChangesAsync();

        //    var dailyManuServices = new DailyManuServices(data);

        //    Assert.That(data.Children.Count(), Is.EqualTo(1));

        //    Assert.ThrowsAsync<ArgumentException>(async () => await dailyManuServices.GetMealsForParentsToChoose(Guid.Parse("45145b93b0064424b0f6601b73837184")), InvalidSchoolUserId);

        //}

    }
}
