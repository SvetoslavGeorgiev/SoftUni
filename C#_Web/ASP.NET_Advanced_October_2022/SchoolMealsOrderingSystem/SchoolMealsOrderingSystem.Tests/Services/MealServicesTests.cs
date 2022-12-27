namespace SchoolMealsOrderingSystem.Tests.Services
{
    using Moq;
    using SchoolMealsOrderingSystem.Core.Services;
    using SchoolMealsOrderingSystem.Data.Entities;
    using SchoolMealsOrderingSystem.Data.Entities.Meals;

    [TestFixture]
    public class MealServicesTests
    {
        [Test]
        public async Task GetSoupsAsyncShouldGetAllSoupsIfNotDeleted()
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

            await data.Soups.AddRangeAsync(new List<Soup>()
            {
                new Soup()
                {
                    Name = "Foo",
                    Allergens = "dfasugdgf",
                    Ingredients = "juhdsfhfdfdsf",
                    ImageUrl = "jhdsfjhdsf",
                    IsDeleted = true,
                    SchoolUserId = "gdhfgfdhs"
                },
                new Soup()
                {
                    Name = "Foo2",
                    Allergens = "dfasugdgf",
                    Ingredients = "juhdsfhfdfdsf",
                    ImageUrl = "jhdsfjhdsf",
                    IsDeleted = false,
                    SchoolUserId = "gdhfgfdhs"
                },
                new Soup()
                {
                    Name = "Foo1",
                    Allergens = "dfasugdgf",
                    Ingredients = "juhdsfhfdfdsf",
                    ImageUrl = "jhdsfjhdsf",
                    IsDeleted = false,
                    SchoolUserId = "gdhfgfdhs"
                },
                new Soup()
                {
                    Name = "Foo",
                    Allergens = "dfasugdgf",
                    Ingredients = "juhdsfhfdfdsf",
                    ImageUrl = "jhdsfjhdsf",
                    IsDeleted = false,
                    SchoolUserId = "dfgfdgadfg"
                }
            });

            await data.SaveChangesAsync();

            var mealServices = new MealServices(data);

            Assert.That(data.Soups.Count(), Is.EqualTo(4));
            Assert.That(data.SchoolUsers.Count(), Is.EqualTo(3));

            var result = await mealServices.GetSoupsAsync("gdhfgfdhs");
            var result1 = await mealServices.GetSoupsAsync("dfgfdgadfg");
            var result2 = await mealServices.GetSoupsAsync("hgagfjsdhjfdgdfdgddghfdshf");

            Assert.That(result.Count(), Is.EqualTo(2));
            Assert.That(result1.Count(), Is.EqualTo(1));
            Assert.That(result2.Count(), Is.EqualTo(0));


        }


        [Test]
        public async Task GetMainDishesAsyncShouldGetAllMainDishesIfNotDeleted()
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

            await data.MainDishes.AddRangeAsync(new List<MainDish>()
            {
                new MainDish()
                {
                    Name = "Foo",
                    Allergens = "dfasugdgf",
                    Ingredients = "juhdsfhfdfdsf",
                    ImageUrl = "jhdsfjhdsf",
                    IsDeleted = true,
                    SchoolUserId = "gdhfgfdhs"
                },
                new MainDish()
                {
                    Name = "Foo2",
                    Allergens = "dfasugdgf",
                    Ingredients = "juhdsfhfdfdsf",
                    ImageUrl = "jhdsfjhdsf",
                    IsDeleted = false,
                    SchoolUserId = "gdhfgfdhs"
                },
                new MainDish()
                {
                    Name = "Foo1",
                    Allergens = "dfasugdgf",
                    Ingredients = "juhdsfhfdfdsf",
                    ImageUrl = "jhdsfjhdsf",
                    IsDeleted = false,
                    SchoolUserId = "gdhfgfdhs"
                },
                new MainDish()
                {
                    Name = "Foo",
                    Allergens = "dfasugdgf",
                    Ingredients = "juhdsfhfdfdsf",
                    ImageUrl = "jhdsfjhdsf",
                    IsDeleted = false,
                    SchoolUserId = "dfgfdgadfg"
                }
            });

            await data.SaveChangesAsync();

            var mealServices = new MealServices(data);

            Assert.That(data.MainDishes.Count(), Is.EqualTo(4));
            Assert.That(data.SchoolUsers.Count(), Is.EqualTo(3));

            var result = await mealServices.GetMainDishsAsync("gdhfgfdhs");
            var result1 = await mealServices.GetMainDishsAsync("dfgfdgadfg");
            var result2 = await mealServices.GetSoupsAsync("hgagfjsdhjfdgdfdgddghfdshf");

            Assert.That(result.Count(), Is.EqualTo(2));
            Assert.That(result1.Count(), Is.EqualTo(1));
            Assert.That(result2.Count(), Is.EqualTo(0));


        }


        [Test]
        public async Task GetDessertsAsyncShouldGetAllDessertsIfNotDeleted()
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

            await data.Desserts.AddRangeAsync(new List<Dessert>()
            {
                new Dessert()
                {
                    Name = "Foo",
                    Allergens = "dfasugdgf",
                    Ingredients = "juhdsfhfdfdsf",
                    ImageUrl = "jhdsfjhdsf",
                    IsDeleted = true,
                    SchoolUserId = "gdhfgfdhs"
                },
                new Dessert()
                {
                    Name = "Foo2",
                    Allergens = "dfasugdgf",
                    Ingredients = "juhdsfhfdfdsf",
                    ImageUrl = "jhdsfjhdsf",
                    IsDeleted = false,
                    SchoolUserId = "gdhfgfdhs"
                },
                new Dessert()
                {
                    Name = "Foo1",
                    Allergens = "dfasugdgf",
                    Ingredients = "juhdsfhfdfdsf",
                    ImageUrl = "jhdsfjhdsf",
                    IsDeleted = false,
                    SchoolUserId = "gdhfgfdhs"
                },
                new Dessert()
                {
                    Name = "Foo",
                    Allergens = "dfasugdgf",
                    Ingredients = "juhdsfhfdfdsf",
                    ImageUrl = "jhdsfjhdsf",
                    IsDeleted = false,
                    SchoolUserId = "dfgfdgadfg"
                }
            });

            await data.SaveChangesAsync();

            var mealServices = new MealServices(data);

            Assert.That(data.Desserts.Count(), Is.EqualTo(4));
            Assert.That(data.SchoolUsers.Count(), Is.EqualTo(3));

            var result = await mealServices.GetDessertsAsync("gdhfgfdhs");
            var result1 = await mealServices.GetDessertsAsync("dfgfdgadfg");
            var result2 = await mealServices.GetDessertsAsync("hgagfjsdhjfdgdfdgddghfdshf");

            Assert.That(result.Count(), Is.EqualTo(2));
            Assert.That(result1.Count(), Is.EqualTo(1));
            Assert.That(result2.Count(), Is.EqualTo(0));


        }

        [Test]
        public async Task GetSoupViewModelAsyncShouldReturnCorrectModelIfNotDeleted()
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

            await data.Soups.AddRangeAsync(new List<Soup>()
            {
                new Soup()
                {
                    Name = "Foo",
                    Allergens = "dfasugdgf",
                    Ingredients = "juhdsfhfdfdsf",
                    ImageUrl = "jhdsfjhdsf",
                    IsDeleted = true,
                    SchoolUserId = "gdhfgfdhs"
                },
                new Soup()
                {
                    Name = "Foo2",
                    Allergens = "dfasugdgf",
                    Ingredients = "juhdsfhfdfdsf",
                    ImageUrl = "jhdsfjhdsf",
                    IsDeleted = false,
                    SchoolUserId = "gdhfgfdhs"
                },
                new Soup()
                {
                    Name = "Foo1",
                    Allergens = "dfasugdgf",
                    Ingredients = "juhdsfhfdfdsf",
                    ImageUrl = "jhdsfjhdsf",
                    IsDeleted = false,
                    SchoolUserId = "gdhfgfdhs"
                },
                new Soup()
                {
                    Name = "Foo",
                    Allergens = "dfasugdgf",
                    Ingredients = "juhdsfhfdfdsf",
                    ImageUrl = "jhdsfjhdsf",
                    IsDeleted = false,
                    SchoolUserId = "dfgfdgadfg"
                }
            });

            await data.SaveChangesAsync();

            var mealServices = new MealServices(data);

            Assert.That(data.Soups.Count(), Is.EqualTo(4));
            Assert.That(data.SchoolUsers.Count(), Is.EqualTo(3));

            var result = await mealServices.GetSoupViewModelAsync("gdhfgfdhs");
            var result1 = await mealServices.GetSoupViewModelAsync("dfgfdgadfg");
            var result2 = await mealServices.GetSoupViewModelAsync("hgagfjsdhjfdgdfdgddghfdshf");

            Assert.That(result.Count(), Is.EqualTo(2));
            Assert.That(result1.Count(), Is.EqualTo(1));
            Assert.That(result2.Count(), Is.EqualTo(0));


        }

        [Test]
        public async Task GetMainDishViewModelAsyncShouldReturnCorrectModelIfNotDeleted()
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

            await data.MainDishes.AddRangeAsync(new List<MainDish>()
            {
                new MainDish()
                {
                    Name = "Foo",
                    Allergens = "dfasugdgf",
                    Ingredients = "juhdsfhfdfdsf",
                    ImageUrl = "jhdsfjhdsf",
                    IsDeleted = true,
                    SchoolUserId = "gdhfgfdhs"
                },
                new MainDish()
                {
                    Name = "Foo2",
                    Allergens = "dfasugdgf",
                    Ingredients = "juhdsfhfdfdsf",
                    ImageUrl = "jhdsfjhdsf",
                    IsDeleted = false,
                    SchoolUserId = "gdhfgfdhs"
                },
                new MainDish()
                {
                    Name = "Foo1",
                    Allergens = "dfasugdgf",
                    Ingredients = "juhdsfhfdfdsf",
                    ImageUrl = "jhdsfjhdsf",
                    IsDeleted = false,
                    SchoolUserId = "gdhfgfdhs"
                },
                new MainDish()
                {
                    Name = "Foo",
                    Allergens = "dfasugdgf",
                    Ingredients = "juhdsfhfdfdsf",
                    ImageUrl = "jhdsfjhdsf",
                    IsDeleted = false,
                    SchoolUserId = "dfgfdgadfg"
                }
            });

            await data.SaveChangesAsync();

            var mealServices = new MealServices(data);

            Assert.That(data.MainDishes.Count(), Is.EqualTo(4));
            Assert.That(data.SchoolUsers.Count(), Is.EqualTo(3));

            var result = await mealServices.GetMainDishViewModelAsync("gdhfgfdhs");
            var result1 = await mealServices.GetMainDishViewModelAsync("dfgfdgadfg");
            var result2 = await mealServices.GetMainDishViewModelAsync("hgagfjsdhjfdgdfdgddghfdshf");

            Assert.That(result.Count(), Is.EqualTo(2));
            Assert.That(result1.Count(), Is.EqualTo(1));
            Assert.That(result2.Count(), Is.EqualTo(0));


        }

        [Test]
        public async Task GetDessertViewModelAsyncShouldGetAllCorrectModelIfNotDeleted()
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

            await data.Desserts.AddRangeAsync(new List<Dessert>()
            {
                new Dessert()
                {
                    Name = "Foo",
                    Allergens = "dfasugdgf",
                    Ingredients = "juhdsfhfdfdsf",
                    ImageUrl = "jhdsfjhdsf",
                    IsDeleted = true,
                    SchoolUserId = "gdhfgfdhs"
                },
                new Dessert()
                {
                    Name = "Foo2",
                    Allergens = "dfasugdgf",
                    Ingredients = "juhdsfhfdfdsf",
                    ImageUrl = "jhdsfjhdsf",
                    IsDeleted = false,
                    SchoolUserId = "gdhfgfdhs"
                },
                new Dessert()
                {
                    Name = "Foo1",
                    Allergens = "dfasugdgf",
                    Ingredients = "juhdsfhfdfdsf",
                    ImageUrl = "jhdsfjhdsf",
                    IsDeleted = false,
                    SchoolUserId = "gdhfgfdhs"
                },
                new Dessert()
                {
                    Name = "Foo",
                    Allergens = "dfasugdgf",
                    Ingredients = "juhdsfhfdfdsf",
                    ImageUrl = "jhdsfjhdsf",
                    IsDeleted = false,
                    SchoolUserId = "dfgfdgadfg"
                }
            });

            await data.SaveChangesAsync();

            var mealServices = new MealServices(data);

            Assert.That(data.Desserts.Count(), Is.EqualTo(4));
            Assert.That(data.SchoolUsers.Count(), Is.EqualTo(3));

            var result = await mealServices.GetDessertViewModelAsync("gdhfgfdhs");
            var result1 = await mealServices.GetDessertViewModelAsync("dfgfdgadfg");
            var result2 = await mealServices.GetDessertViewModelAsync("hgagfjsdhjfdgdfdgddghfdshf");

            Assert.That(result.Count(), Is.EqualTo(2));
            Assert.That(result1.Count(), Is.EqualTo(1));
            Assert.That(result2.Count(), Is.EqualTo(0));


        }


        [Test]
        public async Task FindSoupAsyncAsyncShouldReturnCorectDataIfNotDeleted()
        {

            using var data = DatabaseMock.Instance;

            await data.Soups.AddRangeAsync(new List<Soup>()
            {
                new Soup()
                {
                    Id = Guid.Parse("f278f1e17ee84269850e47f0ce75d78c"),
                    Name = "Foo",
                    Allergens = "dfasugdgf",
                    Ingredients = "juhdsfhfdfdsf",
                    ImageUrl = "jhdsfjhdsf",
                    IsDeleted = true,
                    SchoolUserId = "gdhfgfdhs"
                },
                new Soup()
                {
                    Name = "Foo2",
                    Allergens = "dfasugdgf",
                    Ingredients = "juhdsfhfdfdsf",
                    ImageUrl = "jhdsfjhdsf",
                    IsDeleted = false,
                    SchoolUserId = "gdhfgfdhs"
                },
                new Soup()
                {
                    Id = Guid.Parse("ad5f280b24c64d909a5812e45031ceaa"),
                    Name = "Foo1",
                    Allergens = "dfasugdgf",
                    Ingredients = "juhdsfhfdfdsf",
                    ImageUrl = "jhdsfjhdsf",
                    IsDeleted = false,
                    SchoolUserId = "gdhfgfdhs"
                },
                new Soup()
                {
                    Name = "Foo",
                    Allergens = "dfasugdgf",
                    Ingredients = "juhdsfhfdfdsf",
                    ImageUrl = "jhdsfjhdsf",
                    IsDeleted = false,
                    SchoolUserId = "dfgfdgadfg"
                }
            });

            await data.SaveChangesAsync();

            var mealServices = new MealServices(data);

            Assert.That(data.Soups.Count(), Is.EqualTo(4));

            var result = await mealServices.FindSoupAsync(Guid.Parse("ad5f280b24c64d909a5812e45031ceaa"));

            Assert.That(result.Name, Is.EqualTo("Foo1"));
            Assert.That(result.ImageUrl, Is.EqualTo("jhdsfjhdsf"));
            Assert.That(result.SchoolUserId, Is.EqualTo("gdhfgfdhs"));


        }

        [Test]
        public async Task FindSoupAsyncAsyncShouldThrowArgumentExceptionIfDeleted()
        {

            using var data = DatabaseMock.Instance;

            await data.Soups.AddRangeAsync(new List<Soup>()
            {
                new Soup()
                {
                    Id = Guid.Parse("f278f1e17ee84269850e47f0ce75d78c"),
                    Name = "Foo",
                    Allergens = "dfasugdgf",
                    Ingredients = "juhdsfhfdfdsf",
                    ImageUrl = "jhdsfjhdsf",
                    IsDeleted = true,
                    SchoolUserId = "gdhfgfdhs"
                },
                new Soup()
                {
                    Name = "Foo2",
                    Allergens = "dfasugdgf",
                    Ingredients = "juhdsfhfdfdsf",
                    ImageUrl = "jhdsfjhdsf",
                    IsDeleted = false,
                    SchoolUserId = "gdhfgfdhs"
                },
                new Soup()
                {
                    Id = Guid.Parse("ad5f280b24c64d909a5812e45031ceaa"),
                    Name = "Foo1",
                    Allergens = "dfasugdgf",
                    Ingredients = "juhdsfhfdfdsf",
                    ImageUrl = "jhdsfjhdsf",
                    IsDeleted = false,
                    SchoolUserId = "gdhfgfdhs"
                },
                new Soup()
                {
                    Name = "Foo",
                    Allergens = "dfasugdgf",
                    Ingredients = "juhdsfhfdfdsf",
                    ImageUrl = "jhdsfjhdsf",
                    IsDeleted = false,
                    SchoolUserId = "dfgfdgadfg"
                }
            });

            await data.SaveChangesAsync();

            var mealServices = new MealServices(data);

            Assert.That(data.Soups.Count(), Is.EqualTo(4));

            Assert.ThrowsAsync<ArgumentException>(async () => await mealServices.FindSoupAsync(Guid.Parse("f278f1e17ee84269850e47f0ce75d78c")), InvalidSoupId);


        }

        [Test]
        public async Task FindMainDishAsyncAsyncShouldReturnCorectDataIfNotDeleted()
        {

            using var data = DatabaseMock.Instance;

            await data.MainDishes.AddRangeAsync(new List<MainDish>()
            {
                new MainDish()
                {
                    Id = Guid.Parse("f278f1e17ee84269850e47f0ce75d78c"),
                    Name = "Foo",
                    Allergens = "dfasugdgf",
                    Ingredients = "juhdsfhfdfdsf",
                    ImageUrl = "jhdsfjhdsf",
                    IsDeleted = true,
                    SchoolUserId = "gdhfgfdhs"
                },
                new MainDish()
                {
                    Name = "Foo2",
                    Allergens = "dfasugdgf",
                    Ingredients = "juhdsfhfdfdsf",
                    ImageUrl = "jhdsfjhdsf",
                    IsDeleted = false,
                    SchoolUserId = "gdhfgfdhs"
                },
                new MainDish()
                {
                    Id = Guid.Parse("ad5f280b24c64d909a5812e45031ceaa"),
                    Name = "Foo1",
                    Allergens = "dfasugdgf",
                    Ingredients = "juhdsfhfdfdsf",
                    ImageUrl = "jhdsfjhdsf",
                    IsDeleted = false,
                    SchoolUserId = "gdhfgfdhs"
                },
                new MainDish()
                {
                    Name = "Foo",
                    Allergens = "dfasugdgf",
                    Ingredients = "juhdsfhfdfdsf",
                    ImageUrl = "jhdsfjhdsf",
                    IsDeleted = false,
                    SchoolUserId = "dfgfdgadfg"
                }
            });

            await data.SaveChangesAsync();

            var mealServices = new MealServices(data);

            Assert.That(data.MainDishes.Count(), Is.EqualTo(4));

            var result = await mealServices.FindMainDishAsync(Guid.Parse("ad5f280b24c64d909a5812e45031ceaa"));

            Assert.That(result.Name, Is.EqualTo("Foo1"));
            Assert.That(result.ImageUrl, Is.EqualTo("jhdsfjhdsf"));
            Assert.That(result.SchoolUserId, Is.EqualTo("gdhfgfdhs"));


        }

        [Test]
        public async Task FindMainDishAsyncAsyncShouldThrowArgumentExceptionIfDeleted()
        {

            using var data = DatabaseMock.Instance;

            await data.MainDishes.AddRangeAsync(new List<MainDish>()
            {
                new MainDish()
                {
                    Id = Guid.Parse("f278f1e17ee84269850e47f0ce75d78c"),
                    Name = "Foo",
                    Allergens = "dfasugdgf",
                    Ingredients = "juhdsfhfdfdsf",
                    ImageUrl = "jhdsfjhdsf",
                    IsDeleted = true,
                    SchoolUserId = "gdhfgfdhs"
                },
                new MainDish()
                {
                    Name = "Foo2",
                    Allergens = "dfasugdgf",
                    Ingredients = "juhdsfhfdfdsf",
                    ImageUrl = "jhdsfjhdsf",
                    IsDeleted = false,
                    SchoolUserId = "gdhfgfdhs"
                },
                new MainDish()
                {
                    Id = Guid.Parse("ad5f280b24c64d909a5812e45031ceaa"),
                    Name = "Foo1",
                    Allergens = "dfasugdgf",
                    Ingredients = "juhdsfhfdfdsf",
                    ImageUrl = "jhdsfjhdsf",
                    IsDeleted = false,
                    SchoolUserId = "gdhfgfdhs"
                },
                new MainDish()
                {
                    Name = "Foo",
                    Allergens = "dfasugdgf",
                    Ingredients = "juhdsfhfdfdsf",
                    ImageUrl = "jhdsfjhdsf",
                    IsDeleted = false,
                    SchoolUserId = "dfgfdgadfg"
                }
            });

            await data.SaveChangesAsync();

            var mealServices = new MealServices(data);

            Assert.That(data.MainDishes.Count(), Is.EqualTo(4));

            Assert.ThrowsAsync<ArgumentException>(async () => await mealServices.FindMainDishAsync(Guid.Parse("f278f1e17ee84269850e47f0ce75d78c")), InvalidSoupId);


        }

        [Test]
        public async Task FindDessertAsyncAsyncShouldReturnCorectDataIfNotDeleted()
        {

            using var data = DatabaseMock.Instance;

            await data.Desserts.AddRangeAsync(new List<Dessert>()
            {
                new Dessert()
                {
                    Id = Guid.Parse("f278f1e17ee84269850e47f0ce75d78c"),
                    Name = "Foo",
                    Allergens = "dfasugdgf",
                    Ingredients = "juhdsfhfdfdsf",
                    ImageUrl = "jhdsfjhdsf",
                    IsDeleted = true,
                    SchoolUserId = "gdhfgfdhs"
                },
                new Dessert()
                {
                    Name = "Foo2",
                    Allergens = "dfasugdgf",
                    Ingredients = "juhdsfhfdfdsf",
                    ImageUrl = "jhdsfjhdsf",
                    IsDeleted = false,
                    SchoolUserId = "gdhfgfdhs"
                },
                new Dessert()
                {
                    Id = Guid.Parse("ad5f280b24c64d909a5812e45031ceaa"),
                    Name = "Foo1",
                    Allergens = "dfasugdgf",
                    Ingredients = "juhdsfhfdfdsf",
                    ImageUrl = "jhdsfjhdsf",
                    IsDeleted = false,
                    SchoolUserId = "gdhfgfdhs"
                },
                new Dessert()
                {
                    Name = "Foo",
                    Allergens = "dfasugdgf",
                    Ingredients = "juhdsfhfdfdsf",
                    ImageUrl = "jhdsfjhdsf",
                    IsDeleted = false,
                    SchoolUserId = "dfgfdgadfg"
                }
            });

            await data.SaveChangesAsync();

            var mealServices = new MealServices(data);

            Assert.That(data.Desserts.Count(), Is.EqualTo(4));

            var result = await mealServices.FindDessertAsync(Guid.Parse("ad5f280b24c64d909a5812e45031ceaa"));

            Assert.That(result.Name, Is.EqualTo("Foo1"));
            Assert.That(result.ImageUrl, Is.EqualTo("jhdsfjhdsf"));
            Assert.That(result.SchoolUserId, Is.EqualTo("gdhfgfdhs"));


        }

        [Test]
        public async Task FindDessertsAsyncAsyncShouldThrowArgumentExceptionIfDeleted()
        {

            using var data = DatabaseMock.Instance;

            await data.Desserts.AddRangeAsync(new List<Dessert>()
            {
                new Dessert()
                {
                    Id = Guid.Parse("f278f1e17ee84269850e47f0ce75d78c"),
                    Name = "Foo",
                    Allergens = "dfasugdgf",
                    Ingredients = "juhdsfhfdfdsf",
                    ImageUrl = "jhdsfjhdsf",
                    IsDeleted = true,
                    SchoolUserId = "gdhfgfdhs"
                },
                new Dessert()
                {
                    Name = "Foo2",
                    Allergens = "dfasugdgf",
                    Ingredients = "juhdsfhfdfdsf",
                    ImageUrl = "jhdsfjhdsf",
                    IsDeleted = false,
                    SchoolUserId = "gdhfgfdhs"
                },
                new Dessert()
                {
                    Id = Guid.Parse("ad5f280b24c64d909a5812e45031ceaa"),
                    Name = "Foo1",
                    Allergens = "dfasugdgf",
                    Ingredients = "juhdsfhfdfdsf",
                    ImageUrl = "jhdsfjhdsf",
                    IsDeleted = false,
                    SchoolUserId = "gdhfgfdhs"
                },
                new Dessert()
                {
                    Name = "Foo",
                    Allergens = "dfasugdgf",
                    Ingredients = "juhdsfhfdfdsf",
                    ImageUrl = "jhdsfjhdsf",
                    IsDeleted = false,
                    SchoolUserId = "dfgfdgadfg"
                }
            });

            await data.SaveChangesAsync();

            var mealServices = new MealServices(data);

            Assert.That(data.Desserts.Count(), Is.EqualTo(4));

            Assert.ThrowsAsync<ArgumentException>(async () => await mealServices.FindDessertAsync(Guid.Parse("f278f1e17ee84269850e47f0ce75d78c")), InvalidSoupId);


        }

        [Test]
        public async Task AddMealsAsyncShouldReturnCorectDataIfSchoolUserNotDeleted()
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
                    IsDeleted = false,
                },
                new SchoolUser()
                {
                    Id = "dfgfdgadfg",
                    Email = "test@test.bg",
                    UserName = "test@test.bg",
                    SchoolName = "hdsfhdsfsdf",
                    IsSchool = true,
                    IsDeleted = true,
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

            await data.Soups.AddRangeAsync(new List<Soup>()
            {
                new Soup()
                {
                    Id = Guid.Parse("687edc6b6e20407cb7e3d2e8a9b5fb82"),
                    Name = "Foo",
                    Allergens = "dfasugdgf",
                    Ingredients = "juhdsfhfdfdsf",
                    ImageUrl = "jhdsfjhdsf",
                    IsDeleted = false,
                    SchoolUserId = "gdhfgfdhs"
                },
                new Soup()
                {
                    Id = Guid.Parse("c1018a615bae4688af4d0df170e40b58"),
                    Name = "Foo2",
                    Allergens = "dfasugdgf",
                    Ingredients = "juhdsfhfdfdsf",
                    ImageUrl = "jhdsfjhdsf",
                    IsDeleted = false,
                    SchoolUserId = "gdhfgfdhs"
                },
                new Soup()
                {
                    Id = Guid.Parse("154b527640204502bd492a1ce367af87"),
                    Name = "Foo1",
                    Allergens = "dfasugdgf",
                    Ingredients = "juhdsfhfdfdsf",
                    ImageUrl = "jhdsfjhdsf",
                    IsDeleted = false,
                    SchoolUserId = "gdhfgfdhs"
                },
                new Soup()
                {
                    Name = "Foo",
                    Allergens = "dfasugdgf",
                    Ingredients = "juhdsfhfdfdsf",
                    ImageUrl = "jhdsfjhdsf",
                    IsDeleted = false,
                    SchoolUserId = "dfgfdgadfg"
                }
            });

            await data.MainDishes.AddRangeAsync(new List<MainDish>()
            {
                new MainDish()
                {
                    Id = Guid.Parse("687edc6b6e20407cb7e3d2e8a9b5fb82"),
                    Name = "Foo",
                    Allergens = "dfasugdgf",
                    Ingredients = "juhdsfhfdfdsf",
                    ImageUrl = "jhdsfjhdsf",
                    IsDeleted = false,
                    SchoolUserId = "gdhfgfdhs"
                },
                new MainDish()
                {
                    Id = Guid.Parse("c1018a615bae4688af4d0df170e40b58"),
                    Name = "Foo2",
                    Allergens = "dfasugdgf",
                    Ingredients = "juhdsfhfdfdsf",
                    ImageUrl = "jhdsfjhdsf",
                    IsDeleted = false,
                    SchoolUserId = "gdhfgfdhs"
                },
                new MainDish()
                {
                    Id = Guid.Parse("154b527640204502bd492a1ce367af87"),
                    Name = "Foo1",
                    Allergens = "dfasugdgf",
                    Ingredients = "juhdsfhfdfdsf",
                    ImageUrl = "jhdsfjhdsf",
                    IsDeleted = false,
                    SchoolUserId = "gdhfgfdhs"
                },
                new MainDish()
                {
                    Name = "Foo",
                    Allergens = "dfasugdgf",
                    Ingredients = "juhdsfhfdfdsf",
                    ImageUrl = "jhdsfjhdsf",
                    IsDeleted = false,
                    SchoolUserId = "dfgfdgadfg"
                }
            });

            await data.Desserts.AddRangeAsync(new List<Dessert>()
            {
                new Dessert()
                {
                    Id = Guid.Parse("687edc6b6e20407cb7e3d2e8a9b5fb82"),
                    Name = "Foo",
                    Allergens = "dfasugdgf",
                    Ingredients = "juhdsfhfdfdsf",
                    ImageUrl = "jhdsfjhdsf",
                    IsDeleted = false,
                    SchoolUserId = "gdhfgfdhs"
                },
                new Dessert()
                {
                    Id = Guid.Parse("c1018a615bae4688af4d0df170e40b58"),
                    Name = "Foo2",
                    Allergens = "dfasugdgf",
                    Ingredients = "juhdsfhfdfdsf",
                    ImageUrl = "jhdsfjhdsf",
                    IsDeleted = false,
                    SchoolUserId = "gdhfgfdhs"
                },
                new Dessert()
                {
                    Id = Guid.Parse("154b527640204502bd492a1ce367af87"),
                    Name = "Foo1",
                    Allergens = "dfasugdgf",
                    Ingredients = "juhdsfhfdfdsf",
                    ImageUrl = "jhdsfjhdsf",
                    IsDeleted = false,
                    SchoolUserId = "gdhfgfdhs"
                },
                new Dessert()
                {
                    Name = "Foo",
                    Allergens = "dfasugdgf",
                    Ingredients = "juhdsfhfdfdsf",
                    ImageUrl = "jhdsfjhdsf",
                    IsDeleted = false,
                    SchoolUserId = "dfgfdgadfg"
                }
            });

            await data.SaveChangesAsync();

            var mealServices = new MealServices(data);

            Assert.That(data.Soups.Count(), Is.EqualTo(4));
            Assert.That(data.MainDishes.Count(), Is.EqualTo(4));
            Assert.That(data.Desserts.Count(), Is.EqualTo(4));
            Assert.That(data.SchoolUsers.Count(), Is.EqualTo(3));

            var model = new AddMealsToSchoolListViewModel()
            {
                FirstSoupId = Guid.Parse("687edc6b6e20407cb7e3d2e8a9b5fb82"),
                SecondSoupId = Guid.Parse("c1018a615bae4688af4d0df170e40b58"),
                ThirdSoupId = Guid.Parse("154b527640204502bd492a1ce367af87"),
                FirstMainDishId = Guid.Parse("687edc6b6e20407cb7e3d2e8a9b5fb82"),
                SecondMainDishId = Guid.Parse("c1018a615bae4688af4d0df170e40b58"),
                ThirdMainDishId = Guid.Parse("154b527640204502bd492a1ce367af87"),
                FirstDessertsId = Guid.Parse("687edc6b6e20407cb7e3d2e8a9b5fb82"),
                SecondDessertsId = Guid.Parse("c1018a615bae4688af4d0df170e40b58"),
                ThirdDessertsId = Guid.Parse("154b527640204502bd492a1ce367af87"),
            };

            var oldResult = await data.Soups.Where(x => x.IsSelected).ToArrayAsync();

            Assert.That(oldResult.Count(), Is.EqualTo(0));

            var oldResult1 = await data.MainDishes.Where(x => x.IsSelected).ToArrayAsync();

            Assert.That(oldResult1.Count(), Is.EqualTo(0));

            var oldResult2 = await data.Desserts.Where(x => x.IsSelected).ToArrayAsync();

            Assert.That(oldResult2.Count(), Is.EqualTo(0));



            await mealServices.AddMealsAsync(model, "gdhfgfdhs");

            var result = await data.Soups.Where(x => x.IsSelected).ToArrayAsync();

            Assert.That(result.Count(), Is.EqualTo(3));

            var result1 = await data.MainDishes.Where(x => x.IsSelected).ToArrayAsync();

            Assert.That(result1.Count(), Is.EqualTo(3));

            var result2 = await data.Desserts.Where(x => x.IsSelected).ToArrayAsync();

            Assert.That(result2.Count(), Is.EqualTo(3));

        }

        [Test]
        public async Task AddMealsAsyncShouldThrowArgumentExceptionIfSchoolUserIdIsNull()
        {
            using var data = DatabaseMock.Instance;

            var modelMock = new Mock<AddMealsToSchoolListViewModel>();
            var model = modelMock.Object;

            await data.SaveChangesAsync();

            var mealServices = new MealServices(data);

            Assert.ThrowsAsync<ArgumentException>(async () => await mealServices.AddMealsAsync(model, "gdhfgfdhs"), InvalidSchoolUserId);
        }

        [Test]
        public async Task GetRestOfMealsUnselectedShouldTReturnCorrectData()
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
                    IsDeleted = false,
                },
                new SchoolUser()
                {
                    Id = "dfgfdgadfg",
                    Email = "test@test.bg",
                    UserName = "test@test.bg",
                    SchoolName = "hdsfhdsfsdf",
                    IsSchool = true,
                    IsDeleted = true,
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

            await data.Soups.AddRangeAsync(new List<Soup>()
            {
                new Soup()
                {
                    Id = Guid.Parse("687edc6b6e20407cb7e3d2e8a9b5fb82"),
                    Name = "Foo",
                    Allergens = "dfasugdgf",
                    Ingredients = "juhdsfhfdfdsf",
                    ImageUrl = "jhdsfjhdsf",
                    IsDeleted = false,
                    SchoolUserId = "gdhfgfdhs",
                    IsSelected = true,
                },
                new Soup()
                {
                    Id = Guid.Parse("c1018a615bae4688af4d0df170e40b58"),
                    Name = "Foo2",
                    Allergens = "dfasugdgf",
                    Ingredients = "juhdsfhfdfdsf",
                    ImageUrl = "jhdsfjhdsf",
                    IsDeleted = false,
                    SchoolUserId = "gdhfgfdhs",
                    IsSelected = true,
                    
                },
                new Soup()
                {
                    Id = Guid.Parse("154b527640204502bd492a1ce367af87"),
                    Name = "Foo1",
                    Allergens = "dfasugdgf",
                    Ingredients = "juhdsfhfdfdsf",
                    ImageUrl = "jhdsfjhdsf",
                    IsDeleted = false,
                    SchoolUserId = "gdhfgfdhs"
                },
                new Soup()
                {
                    Name = "Foo",
                    Allergens = "dfasugdgf",
                    Ingredients = "juhdsfhfdfdsf",
                    ImageUrl = "jhdsfjhdsf",
                    IsDeleted = false,
                    SchoolUserId = "dfgfdgadfg"
                }
            });

            await data.MainDishes.AddRangeAsync(new List<MainDish>()
            {
                new MainDish()
                {
                    Id = Guid.Parse("986d982d8c0d4280a3d5a2cd21ef86bc"),
                    Name = "Foo",
                    Allergens = "dfasugdgf",
                    Ingredients = "juhdsfhfdfdsf",
                    ImageUrl = "jhdsfjhdsf",
                    IsDeleted = false,
                    SchoolUserId = "gdhfgfdhs",
                    IsSelected = true,
                },
                new MainDish()
                {
                    Id = Guid.Parse("e39362160b5d45dfbc76443403ae3726"),
                    Name = "Foo2",
                    Allergens = "dfasugdgf",
                    Ingredients = "juhdsfhfdfdsf",
                    ImageUrl = "jhdsfjhdsf",
                    IsDeleted = false,
                    SchoolUserId = "gdhfgfdhs",
                    IsSelected = true,
                    
                },
                new MainDish()
                {
                    Id = Guid.Parse("4119740efc6c4ed19810ffc97e061e0c"),
                    Name = "Foo1",
                    Allergens = "dfasugdgf",
                    Ingredients = "juhdsfhfdfdsf",
                    ImageUrl = "jhdsfjhdsf",
                    IsDeleted = false,
                    SchoolUserId = "gdhfgfdhs",
                    IsSelected = true,
                },
                new MainDish()
                {
                    Name = "Foo",
                    Allergens = "dfasugdgf",
                    Ingredients = "juhdsfhfdfdsf",
                    ImageUrl = "jhdsfjhdsf",
                    IsDeleted = false,
                    SchoolUserId = "dfgfdgadfg"
                }
            });

            await data.Desserts.AddRangeAsync(new List<Dessert>()
            {
                new Dessert()
                {
                    Id = Guid.Parse("1418a02a38fb418cb7d7bfa9d22dfd89"),
                    Name = "Foo",
                    Allergens = "dfasugdgf",
                    Ingredients = "juhdsfhfdfdsf",
                    ImageUrl = "jhdsfjhdsf",
                    IsDeleted = false,
                    SchoolUserId = "gdhfgfdhs",
                    IsSelected = true,
                },
                new Dessert()
                {
                    Id = Guid.Parse("89eb0a438c004127890a8f82ae55ee41"),
                    Name = "Foo2",
                    Allergens = "dfasugdgf",
                    Ingredients = "juhdsfhfdfdsf",
                    ImageUrl = "jhdsfjhdsf",
                    IsDeleted = false,
                    SchoolUserId = "gdhfgfdhs"
                },
                new Dessert()
                {
                    Id = Guid.Parse("5068bc9c0868486aab1bd8bcdedb56fd"),
                    Name = "Foo1",
                    Allergens = "dfasugdgf",
                    Ingredients = "juhdsfhfdfdsf",
                    ImageUrl = "jhdsfjhdsf",
                    IsDeleted = false,
                    SchoolUserId = "gdhfgfdhs"
                },
                new Dessert()
                {
                    Name = "Foo",
                    Allergens = "dfasugdgf",
                    Ingredients = "juhdsfhfdfdsf",
                    ImageUrl = "jhdsfjhdsf",
                    IsDeleted = false,
                    SchoolUserId = "dfgfdgadfg"
                }
            });

            await data.SaveChangesAsync();

            var mealServices = new MealServices(data);

            Assert.That(data.Soups.Count(), Is.EqualTo(4));
            Assert.That(data.MainDishes.Count(), Is.EqualTo(4));
            Assert.That(data.Desserts.Count(), Is.EqualTo(4));
            Assert.That(data.SchoolUsers.Count(), Is.EqualTo(3));

            var model = new List<Guid>()
            {
                Guid.Parse("687edc6b6e20407cb7e3d2e8a9b5fb82"),
                Guid.Parse("986d982d8c0d4280a3d5a2cd21ef86bc"),
                Guid.Parse("e39362160b5d45dfbc76443403ae3726"),
                Guid.Parse("1418a02a38fb418cb7d7bfa9d22dfd89"),
            };

            var oldResult = await data.Soups.Where(x => x.IsSelected).ToArrayAsync();

            Assert.That(oldResult.Count(), Is.EqualTo(2));

            var oldResult1 = await data.MainDishes.Where(x => x.IsSelected).ToArrayAsync();

            Assert.That(oldResult1.Count(), Is.EqualTo(3));

            var oldResult2 = await data.Desserts.Where(x => x.IsSelected).ToArrayAsync();

            Assert.That(oldResult2.Count(), Is.EqualTo(1));



            await mealServices.GetRestOfMealsUnselected(model, "gdhfgfdhs");

            var result = await data.Soups.Where(x => x.IsSelected && x.SchoolUserId == "gdhfgfdhs").ToListAsync();

            Assert.That(result.Count(), Is.EqualTo(1));

            var result1 = await data.MainDishes.Where(x => x.IsSelected && x.SchoolUserId == "gdhfgfdhs").ToArrayAsync();

            Assert.That(result1.Count(), Is.EqualTo(2));

            var result2 = await data.Desserts.Where(x => x.IsSelected && x.SchoolUserId == "gdhfgfdhs").ToArrayAsync();

            Assert.That(result2.Count(), Is.EqualTo(1));
        }

        [Test]
        public async Task AddSoupAsyncShouldAddCorrectDataToDataBase()
        {
            using var data = DatabaseMock.Instance;

            await data.SchoolUsers.AddAsync(new SchoolUser
            {
                Id = "hgagfjsdhjdghfdshf",
                Email = "test@test.bg",
                UserName = "test@test.bg",
                SchoolName = "Pesho"
            });


            var soup = new AddSoupViewModel
            {

                Name = "Pesho",
                Allergens = "Goshov",
                Ingredients = "khgdfhjadssa",
                ImageUrl = "jhdsffds",
                
            };

            var soup1 = new AddSoupViewModel
            {

                Name = "Pesho",
                Allergens = "Goshov",
                Ingredients = "khgdfhjadssa",
                ImageUrl = "jhdsffds",

            };

            await data.SaveChangesAsync();

            var mealServices = new MealServices(data);

            await mealServices.AddSoupAsync(soup, "hgagfjsdhjdghfdshf");


            Assert.That(data.Soups.Count(), Is.EqualTo(1));

            await mealServices.AddSoupAsync(soup1, "hgagfjsdhjdghfdshf");


            Assert.That(data.Soups.Count(), Is.EqualTo(2));
        }

        [Test]
        public async Task AddSoupAsyncShouldShouldThrowArgumentExceptionIfInvalidSchoolUserId()
        {
            using var data = DatabaseMock.Instance;

            await data.SchoolUsers.AddAsync(new SchoolUser
            {
                Id = "hgagfjsdhjdghfdshf",
                Email = "test@test.bg",
                UserName = "test@test.bg",
                SchoolName = "Pesho"
            });


            var soup = new AddSoupViewModel
            {

                Name = "Pesho",
                Allergens = "Goshov",
                Ingredients = "khgdfhjadssa",
                ImageUrl = "jhdsffds",

            };

            var soup1 = new AddSoupViewModel
            {

                Name = "Pesho",
                Allergens = "Goshov",
                Ingredients = "khgdfhjadssa",
                ImageUrl = "jhdsffds",

            };

            await data.SaveChangesAsync();

            var mealServices = new MealServices(data);

            await mealServices.AddSoupAsync(soup, "hgagfjsdhjdghfdshf");


            Assert.That(data.Soups.Count(), Is.EqualTo(1));

            Assert.ThrowsAsync<ArgumentException>(async () => await mealServices.AddSoupAsync(soup1, "dsadada"), InvalidSchoolUserId);

        }

        [Test]
        public async Task AddMainDishAsyncShouldAddCorrectDataToDataBase()
        {
            using var data = DatabaseMock.Instance;

            await data.SchoolUsers.AddAsync(new SchoolUser
            {
                Id = "hgagfjsdhjdghfdshf",
                Email = "test@test.bg",
                UserName = "test@test.bg",
                SchoolName = "Pesho"
            });


            var mainDish = new AddMainDishViewModel
            {

                Name = "Pesho",
                Allergens = "Goshov",
                Ingredients = "khgdfhjadssa",
                ImageUrl = "jhdsffds",

            };

            var mainDish1 = new AddMainDishViewModel
            {

                Name = "Pesho",
                Allergens = "Goshov",
                Ingredients = "khgdfhjadssa",
                ImageUrl = "jhdsffds",

            };

            await data.SaveChangesAsync();

            var mealServices = new MealServices(data);

            await mealServices.AddMainDishAsync(mainDish, "hgagfjsdhjdghfdshf");


            Assert.That(data.MainDishes.Count(), Is.EqualTo(1));

            await mealServices.AddMainDishAsync(mainDish1, "hgagfjsdhjdghfdshf");


            Assert.That(data.MainDishes.Count(), Is.EqualTo(2));
        }

        [Test]
        public async Task AddMainDishAsyncShouldShouldThrowArgumentExceptionIfInvalidSchoolUserId()
        {
            using var data = DatabaseMock.Instance;

            await data.SchoolUsers.AddAsync(new SchoolUser
            {
                Id = "hgagfjsdhjdghfdshf",
                Email = "test@test.bg",
                UserName = "test@test.bg",
                SchoolName = "Pesho"
            });


            var mainDish = new AddMainDishViewModel
            {

                Name = "Pesho",
                Allergens = "Goshov",
                Ingredients = "khgdfhjadssa",
                ImageUrl = "jhdsffds",

            };

            var mainDish1 = new AddMainDishViewModel
            {

                Name = "Pesho",
                Allergens = "Goshov",
                Ingredients = "khgdfhjadssa",
                ImageUrl = "jhdsffds",

            };

            await data.SaveChangesAsync();

            var mealServices = new MealServices(data);

            await mealServices.AddMainDishAsync(mainDish, "hgagfjsdhjdghfdshf");


            Assert.That(data.MainDishes.Count(), Is.EqualTo(1));

            Assert.ThrowsAsync<ArgumentException>(async () => await mealServices.AddMainDishAsync(mainDish1, "dsadada"), InvalidSchoolUserId);

        }

        [Test]
        public async Task AddDessertAsyncShouldAddCorrectDataToDataBase()
        {
            using var data = DatabaseMock.Instance;

            await data.SchoolUsers.AddAsync(new SchoolUser
            {
                Id = "hgagfjsdhjdghfdshf",
                Email = "test@test.bg",
                UserName = "test@test.bg",
                SchoolName = "Pesho"
            });


            var dessert = new AddDessertViewModel
            {

                Name = "Pesho",
                Allergens = "Goshov",
                Ingredients = "khgdfhjadssa",
                ImageUrl = "jhdsffds",

            };

            var dessert1 = new AddDessertViewModel
            {

                Name = "Pesho",
                Allergens = "Goshov",
                Ingredients = "khgdfhjadssa",
                ImageUrl = "jhdsffds",

            };

            await data.SaveChangesAsync();

            var mealServices = new MealServices(data);

            await mealServices.AddDessertAsync(dessert, "hgagfjsdhjdghfdshf");


            Assert.That(data.Desserts.Count(), Is.EqualTo(1));

            await mealServices.AddDessertAsync(dessert1, "hgagfjsdhjdghfdshf");


            Assert.That(data.Desserts.Count(), Is.EqualTo(2));
        }

        [Test]
        public async Task AddDessertAsyncShouldShouldThrowArgumentExceptionIfInvalidSchoolUserId()
        {
            using var data = DatabaseMock.Instance;

            await data.SchoolUsers.AddAsync(new SchoolUser
            {
                Id = "hgagfjsdhjdghfdshf",
                Email = "test@test.bg",
                UserName = "test@test.bg",
                SchoolName = "Pesho"
            });


            var dessert = new AddDessertViewModel
            {

                Name = "Pesho",
                Allergens = "Goshov",
                Ingredients = "khgdfhjadssa",
                ImageUrl = "jhdsffds",

            };

            var dessert1 = new AddDessertViewModel
            {

                Name = "Pesho",
                Allergens = "Goshov",
                Ingredients = "khgdfhjadssa",
                ImageUrl = "jhdsffds",

            };

            await data.SaveChangesAsync();

            var mealServices = new MealServices(data);

            await mealServices.AddDessertAsync(dessert, "hgagfjsdhjdghfdshf");


            Assert.That(data.Desserts.Count(), Is.EqualTo(1));

            Assert.ThrowsAsync<ArgumentException>(async () => await mealServices.AddDessertAsync(dessert1, "dsadada"), InvalidSchoolUserId);

        }

        [Test]
        public async Task DeleteSoupAsyncShouldSetFlagIsDeletedToTrue()
        {

            using var data = DatabaseMock.Instance;

            var id = "042ada31-e666-41b6-a7ea-543d7372cf32";

            await data.Soups.AddAsync(new Soup
            {
                Id = Guid.Parse(id),
                Name = "name",
                Allergens = "dfsfdf",
                Ingredients = "Wow",
                ImageUrl = "dasfgfs",
                SchoolUserId = "sadgdsgs"
            });

            await data.SaveChangesAsync();

            var mealServices = new MealServices(data);

            await mealServices.DeleteSoupAsync(Guid.Parse(id));

            var soup = await data.Soups.FirstOrDefaultAsync();

            Assert.That(soup?.IsDeleted, Is.EqualTo(true));


        }

        [Test]
        public async Task DeleteMainDishAsyncShouldSetFlagIsDeletedToTrue()
        {

            using var data = DatabaseMock.Instance;

            var id = "042ada31-e666-41b6-a7ea-543d7372cf32";

            await data.MainDishes.AddAsync(new MainDish
            {
                Id = Guid.Parse(id),
                Name = "name",
                Allergens = "dfsfdf",
                Ingredients = "Wow",
                ImageUrl = "dasfgfs",
                SchoolUserId = "sadgdsgs"
            });

            await data.SaveChangesAsync();

            var mealServices = new MealServices(data);

            await mealServices.DeleteMainDishAsync(Guid.Parse(id));

            var mainDish = await data.MainDishes.FirstOrDefaultAsync();

            Assert.That(mainDish?.IsDeleted, Is.EqualTo(true));


        }

        [Test]
        public async Task DeleteDessertAsyncShouldSetFlagIsDeletedToTrue()
        {

            using var data = DatabaseMock.Instance;

            var id = "042ada31-e666-41b6-a7ea-543d7372cf32";

            await data.Desserts.AddAsync(new Dessert
            {
                Id = Guid.Parse(id),
                Name = "name",
                Allergens = "dfsfdf",
                Ingredients = "Wow",
                ImageUrl = "dasfgfs",
                SchoolUserId = "sadgdsgs"
            });

            await data.SaveChangesAsync();

            var mealServices = new MealServices(data);

            await mealServices.DeleteDessertAsync(Guid.Parse(id));

            var dessert = await data.Desserts.FirstOrDefaultAsync();

            Assert.That(dessert?.IsDeleted, Is.EqualTo(true));


        }

        [Test]
        public async Task GetSoupForEditAsyncShouldReturnCorrectViewModel()
        {

            using var data = DatabaseMock.Instance;

            var id = "042ada31-e666-41b6-a7ea-543d7372cf32";

            await data.Soups.AddAsync(new Soup
            {
                Id = Guid.Parse(id),
                Name = "name",
                SchoolUser = new SchoolUser()
                {
                    Id = "khgdfhjadssa",
                    Email = "test@test.bg",
                    SchoolName = "Ima",
                    UserName = "test@test.bg"

                },
                Ingredients = "hjgadfadf",
                Allergens = "jhdgsfsdf",
                ImageUrl = "djaskhfakf"
            });

            await data.SaveChangesAsync();

            var mealServices = new MealServices(data);

            var editSoupViewModel = await mealServices.GetSoupForEditAsync(Guid.Parse(id));


            Assert.Multiple(() =>
            {
                Assert.IsNotNull(editSoupViewModel);
                Assert.That(editSoupViewModel?.Id.ToString(), Is.EqualTo(id));
                Assert.That(editSoupViewModel?.Name, Is.EqualTo("name"));
                Assert.That(editSoupViewModel?.Ingredients, Is.EqualTo("hjgadfadf"));
                Assert.That(editSoupViewModel?.Allergens, Is.EqualTo("jhdgsfsdf"));
                Assert.That(editSoupViewModel?.ImageUrl, Is.EqualTo("djaskhfakf"));
            });


        }

        [Test]
        public async Task GetSoupForEditAsyncShouldThrowArgumentExceptionIfChildIdIsInvalid()
        {

            using var data = DatabaseMock.Instance;

            var id = "042ada31-e666-41b6-a7ea-543d7372cf32";

            await data.Soups.AddAsync(new Soup
            {
                Id = Guid.Parse(id),
                Name = "name",
                SchoolUser = new SchoolUser()
                {
                    Id = "khgdfhjadssa",
                    Email = "test@test.bg",
                    SchoolName = "Ima",
                    UserName = "test@test.bg"

                },
                Ingredients = "hjgadfadf",
                Allergens = "jhdgsfsdf",
                ImageUrl = "djaskhfakf"
            });

            await data.SaveChangesAsync();

            var mealServices = new MealServices(data);

            Assert.ThrowsAsync<ArgumentException>(async () => await mealServices.GetSoupForEditAsync(Guid.Parse("e39362160b5d45dfbc76443403ae3726")), InvalidMainDishId);


        }

        [Test]
        public async Task GetMainDishForEditAsyncShouldReturnCorrectViewModel()
        {

            using var data = DatabaseMock.Instance;

            var id = "042ada31-e666-41b6-a7ea-543d7372cf32";

            await data.MainDishes.AddAsync(new MainDish
            {
                Id = Guid.Parse(id),
                Name = "name",
                SchoolUser = new SchoolUser()
                {
                    Id = "khgdfhjadssa",
                    Email = "test@test.bg",
                    SchoolName = "Ima",
                    UserName = "test@test.bg"

                },
                Ingredients = "hjgadfadf",
                Allergens = "jhdgsfsdf",
                ImageUrl = "djaskhfakf"
            });

            await data.SaveChangesAsync();

            var mealServices = new MealServices(data);

            var editMainDishViewModel = await mealServices.GetMainDishForEditAsync(Guid.Parse(id));


            Assert.Multiple(() =>
            {
                Assert.IsNotNull(editMainDishViewModel);
                Assert.That(editMainDishViewModel?.Id.ToString(), Is.EqualTo(id));
                Assert.That(editMainDishViewModel?.Name, Is.EqualTo("name"));
                Assert.That(editMainDishViewModel?.Ingredients, Is.EqualTo("hjgadfadf"));
                Assert.That(editMainDishViewModel?.Allergens, Is.EqualTo("jhdgsfsdf"));
                Assert.That(editMainDishViewModel?.ImageUrl, Is.EqualTo("djaskhfakf"));
            });


        }

        [Test]
        public async Task GetMainDishForEditAsyncShouldThrowArgumentExceptionIfChildIdIsInvalid()
        {

            using var data = DatabaseMock.Instance;

            var id = "042ada31-e666-41b6-a7ea-543d7372cf32";

            await data.MainDishes.AddAsync(new MainDish
            {
                Id = Guid.Parse(id),
                Name = "name",
                SchoolUser = new SchoolUser()
                {
                    Id = "khgdfhjadssa",
                    Email = "test@test.bg",
                    SchoolName = "Ima",
                    UserName = "test@test.bg"

                },
                Ingredients = "hjgadfadf",
                Allergens = "jhdgsfsdf",
                ImageUrl = "djaskhfakf"
            });

            await data.SaveChangesAsync();

            var mealServices = new MealServices(data);

            Assert.ThrowsAsync<ArgumentException>(async () => await mealServices.GetMainDishForEditAsync(Guid.Parse("e39362160b5d45dfbc76443403ae3726")), InvalidMainDishId);


        }

        [Test]
        public async Task GetDessertForEditAsyncShouldReturnCorrectViewModel()
        {

            using var data = DatabaseMock.Instance;

            var id = "042ada31-e666-41b6-a7ea-543d7372cf32";

            await data.Desserts.AddAsync(new Dessert
            {
                Id = Guid.Parse(id),
                Name = "name",
                SchoolUser = new SchoolUser()
                {
                    Id = "khgdfhjadssa",
                    Email = "test@test.bg",
                    SchoolName = "Ima",
                    UserName = "test@test.bg"

                },
                Ingredients = "hjgadfadf",
                Allergens = "jhdgsfsdf",
                ImageUrl = "djaskhfakf"
            });

            await data.SaveChangesAsync();

            var mealServices = new MealServices(data);

            var editDessertViewModel = await mealServices.GetDessertForEditAsync(Guid.Parse(id));


            Assert.Multiple(() =>
            {
                Assert.IsNotNull(editDessertViewModel);
                Assert.That(editDessertViewModel?.Id.ToString(), Is.EqualTo(id));
                Assert.That(editDessertViewModel?.Name, Is.EqualTo("name"));
                Assert.That(editDessertViewModel?.Ingredients, Is.EqualTo("hjgadfadf"));
                Assert.That(editDessertViewModel?.Allergens, Is.EqualTo("jhdgsfsdf"));
                Assert.That(editDessertViewModel?.ImageUrl, Is.EqualTo("djaskhfakf"));
            });


        }

        
        [Test]
        public async Task GetDessertForEditAsyncShouldThrowArgumentExceptionIfChildIdIsInvalid()
        {

            using var data = DatabaseMock.Instance;

            var id = "042ada31-e666-41b6-a7ea-543d7372cf32";

            await data.Desserts.AddAsync(new Dessert
            {
                Id = Guid.Parse(id),
                Name = "name",
                SchoolUser = new SchoolUser()
                {
                    Id = "khgdfhjadssa",
                    Email = "test@test.bg",
                    SchoolName = "Ima",
                    UserName = "test@test.bg"

                },
                Ingredients = "hjgadfadf",
                Allergens = "jhdgsfsdf",
                ImageUrl = "djaskhfakf"
            });

            await data.SaveChangesAsync();

            var mealServices = new MealServices(data);

            Assert.ThrowsAsync<ArgumentException>(async () => await mealServices.GetDessertForEditAsync(Guid.Parse("e39362160b5d45dfbc76443403ae3726")), InvalidSoupId);


        }


        [Test]
        public async Task EditSoupAsyncShouldReturnCorectData()
        {
            using var data = DatabaseMock.Instance;

            var id = "042ada31-e666-41b6-a7ea-543d7372cf32";

            
            await data.Soups.AddAsync(new Soup
            {
                Id = Guid.Parse(id),
                Name = "sddsad",
                Allergens = "dafsadsad",
                Ingredients = "khgdfhjadssa",
                ImageUrl = "jhdsffds",
                SchoolUserId = "kjdsafhjksdf"

            });

            await data.SaveChangesAsync();

            var mealServices = new MealServices(data);

            var model = new EditSoupViewModel()
            {
                Id = Guid.Parse(id),
                Name = "Pesho",
                Allergens = "Goshov",
                Ingredients = "dasdsadasd",
                ImageUrl = "dadsadads"
            };

            await mealServices.EditSoupAsync(model);

            var soup = await data.Soups.FirstOrDefaultAsync();
            Assert.Multiple(() =>
            {
                Assert.That(soup?.IsDeleted, Is.EqualTo(false));
                Assert.That(soup?.Id.ToString(), Is.EqualTo(id));
                Assert.That(soup?.Name, Is.EqualTo("Pesho"));
                Assert.That(soup?.Allergens, Is.EqualTo("Goshov"));
                Assert.That(soup?.Ingredients, Is.EqualTo("dasdsadasd"));
                Assert.That(soup?.ImageUrl, Is.EqualTo("dadsadads"));
            });
        }

        [Test]
        public async Task EditMainDishAsyncShouldReturnCorectData()
        {
            using var data = DatabaseMock.Instance;

            var id = "042ada31-e666-41b6-a7ea-543d7372cf32";


            await data.MainDishes.AddAsync(new MainDish
            {
                Id = Guid.Parse(id),
                Name = "sddsad",
                Allergens = "dafsadsad",
                Ingredients = "khgdfhjadssa",
                ImageUrl = "jhdsffds",
                SchoolUserId = "kjdsafhjksdf"

            });

            await data.SaveChangesAsync();

            var mealServices = new MealServices(data);

            var model = new EditMainDishViewModel()
            {
                Id = Guid.Parse(id),
                Name = "Pesho",
                Allergens = "Goshov",
                Ingredients = "dasdsadasd",
                ImageUrl = "dadsadads"
            };

            await mealServices.EditMainDishAsync(model);

            var mainDish = await data.MainDishes.FirstOrDefaultAsync();
            Assert.Multiple(() =>
            {
                Assert.That(mainDish?.IsDeleted, Is.EqualTo(false));
                Assert.That(mainDish?.Id.ToString(), Is.EqualTo(id));
                Assert.That(mainDish?.Name, Is.EqualTo("Pesho"));
                Assert.That(mainDish?.Allergens, Is.EqualTo("Goshov"));
                Assert.That(mainDish?.Ingredients, Is.EqualTo("dasdsadasd"));
                Assert.That(mainDish?.ImageUrl, Is.EqualTo("dadsadads"));
            });
        }

        [Test]
        public async Task EditDessertAsyncShouldReturnCorectData()
        {
            using var data = DatabaseMock.Instance;

            var id = "042ada31-e666-41b6-a7ea-543d7372cf32";


            await data.Desserts.AddAsync(new Dessert
            {
                Id = Guid.Parse(id),
                Name = "sddsad",
                Allergens = "dafsadsad",
                Ingredients = "khgdfhjadssa",
                ImageUrl = "jhdsffds",
                SchoolUserId = "kjdsafhjksdf"

            });

            await data.SaveChangesAsync();

            var mealServices = new MealServices(data);

            var model = new EditDessertViewModel()
            {
                Id = Guid.Parse(id),
                Name = "Pesho",
                Allergens = "Goshov",
                Ingredients = "dasdsadasd",
                ImageUrl = "dadsadads"
            };

            await mealServices.EditDessertAsync(model);

            var dessert = await data.Desserts.FirstOrDefaultAsync();
            Assert.Multiple(() =>
            {
                Assert.That(dessert?.IsDeleted, Is.EqualTo(false));
                Assert.That(dessert?.Id.ToString(), Is.EqualTo(id));
                Assert.That(dessert?.Name, Is.EqualTo("Pesho"));
                Assert.That(dessert?.Allergens, Is.EqualTo("Goshov"));
                Assert.That(dessert?.Ingredients, Is.EqualTo("dasdsadasd"));
                Assert.That(dessert?.ImageUrl, Is.EqualTo("dadsadads"));
            });
        }

    }
}
