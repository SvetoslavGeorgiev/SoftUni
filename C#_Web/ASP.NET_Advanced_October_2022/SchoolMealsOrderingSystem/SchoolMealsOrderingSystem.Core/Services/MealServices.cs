namespace SchoolMealsOrderingSystem.Core.Services
{
    using Microsoft.EntityFrameworkCore;
    using SchoolMealsOrderingSystem.Core.Contracts;
    using SchoolMealsOrderingSystem.Core.Models.Meal;
    using SchoolMealsOrderingSystem.Data;
    using SchoolMealsOrderingSystem.Data.Entities.Meals;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using static Data.Constants.DessertConstatnts;
    using static Data.Constants.MainDishConstants;
    using static Data.Constants.SchoolUserConstants;
    using static Data.Constants.SoupConstants;

    public class MealServices : IMealServices
    {
        private readonly SchoolMealsOrderingSystemDbContext schoolMealsOrderingSystemDbContext;

        public MealServices(SchoolMealsOrderingSystemDbContext _schoolMealsOrderingSystemDbContext)
        {
            schoolMealsOrderingSystemDbContext = _schoolMealsOrderingSystemDbContext;
        }


        public async Task<IEnumerable<Soup>> GetSoupsAsync(string schoolUserId)
        {
            var result = await schoolMealsOrderingSystemDbContext
                .Soups
                .Where(s => s.SchoolUserId == schoolUserId)
                .ToListAsync();

            return result;
        }

        public async Task<IEnumerable<MainDish>> GetMainDishsAsync(string schoolUserId)
        {
            var result = await schoolMealsOrderingSystemDbContext
                .MainDishes
                .Where(s => s.SchoolUserId == schoolUserId)
                .ToListAsync();

            return result;
        }

        public async Task<IEnumerable<Dessert>> GetDessertsAsync(string schoolUserId)
        {
            var result = await schoolMealsOrderingSystemDbContext
                .Desserts
                .Where(s => s.SchoolUserId == schoolUserId)
                .ToListAsync();

            return result;
        }

        public async Task<Soup> FindSoupAsync(Guid Id)
        {
            var result = await schoolMealsOrderingSystemDbContext
                .Soups
                .Where(s => s.Id == Id && !s.IsDeleted)
                .FirstOrDefaultAsync();

            if (result == null)
            {
                throw new ArgumentException(InvalidSoupId);
            }

            return result;
        }

        public async Task AddMealsAsync(AddMealsToSchoolListViewModel model, string userId)
        {
            var user = await schoolMealsOrderingSystemDbContext
                .SchoolUsers
                .Where(su => su.Id == userId && !su.IsDeleted)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException(InvalidSchoolUserId);
            }

            user.SoupsForParents.Add(await FindSoupAsync(model.FirstSoupId));
            user.SoupsForParents.Add(await FindSoupAsync(model.SecondSoupId));
            user.SoupsForParents.Add(await FindSoupAsync(model.ThirdSoupId));
            user.MainDishesForParents.Add(await FindMainDishAsync(model.FirstMainDishId));
            user.MainDishesForParents.Add(await FindMainDishAsync(model.SecondMainDishId));
            user.MainDishesForParents.Add(await FindMainDishAsync(model.ThirdMainDishId));
            user.DessertsForParents.Add(await FindDessertAsync(model.FirstDessertsId));
            user.DessertsForParents.Add(await FindDessertAsync(model.SecondDessertsId));
            user.DessertsForParents.Add(await FindDessertAsync(model.ThirdDessertsId));
        }

        public async Task<MainDish> FindMainDishAsync(Guid Id)
        {
            var result = await schoolMealsOrderingSystemDbContext
                .MainDishes
                .Where(s => s.Id == Id && !s.IsDeleted)
                .FirstOrDefaultAsync();

            if (result == null)
            {
                throw new ArgumentException(InvalidMainDishId);
            }

            return result;
        }

        public async Task<Dessert> FindDessertAsync(Guid Id)
        {
            var result = await schoolMealsOrderingSystemDbContext
                .Desserts
                .Where(s => s.Id == Id && !s.IsDeleted)
                .FirstOrDefaultAsync();

            if (result == null)
            {
                throw new ArgumentException(InvalidDessertId);
            }

            return result;
        }

        public async Task AddSoupAsync(AddSoupViewModel model, string schoolUserId)
        {

            var schoolUser = await schoolMealsOrderingSystemDbContext
                .SchoolUsers
                .Where(su => su.Id == schoolUserId && !su.IsDeleted)
                .Include(su => su.Soups)
                .FirstOrDefaultAsync();

            if (schoolUser == null)
            {
                throw new ArgumentException(InvalidMainDishId);
            }

            var soup = new Soup()
            {
                Name = model.Name,
                Description = model.Description,
                Ingredients = model.Ingredients,
                Allergens = model.Allergens,
                SchoolUserId = schoolUserId
            };


            schoolUser.Soups.Add(soup);


            await schoolMealsOrderingSystemDbContext.Soups.AddAsync(soup);

            

            await schoolMealsOrderingSystemDbContext.SaveChangesAsync();

        }

        public async Task AddMainDishAsync(AddMainDishViewModel model, string schoolUserId)
        {
            var schoolUser = await schoolMealsOrderingSystemDbContext
                .SchoolUsers
                .Where(su => su.Id == schoolUserId && !su.IsDeleted)
                .Include(su => su.MainDishes)
                .FirstOrDefaultAsync();

            if (schoolUser == null)
            {
                throw new ArgumentException(InvalidMainDishId);
            }

            var mainDish = new MainDish()
            {
                Name = model.Name,
                Description = model.Description,
                Ingredients = model.Ingredients,
                Allergens = model.Allergens,
                SchoolUserId = schoolUserId
            };


            schoolUser.MainDishes.Add(mainDish);


            await schoolMealsOrderingSystemDbContext.MainDishes.AddAsync(mainDish);



            await schoolMealsOrderingSystemDbContext.SaveChangesAsync();
        }

        public async Task AddDessertAsync(AddDessertViewModel model, string schoolUserId)
        {
            var schoolUser = await schoolMealsOrderingSystemDbContext
                .SchoolUsers
                .Where(su => su.Id == schoolUserId && !su.IsDeleted)
                .Include(su => su.Desserts)
                .FirstOrDefaultAsync();

            if (schoolUser == null)
            {
                throw new ArgumentException(InvalidMainDishId);
            }

            var dessert = new Dessert()
            {
                Name = model.Name,
                Description = model.Description,
                Ingredients = model.Ingredients,
                Allergens = model.Allergens,
                SchoolUserId = schoolUserId
            };


            schoolUser.Desserts.Add(dessert);


            await schoolMealsOrderingSystemDbContext.Desserts.AddAsync(dessert);



            await schoolMealsOrderingSystemDbContext.SaveChangesAsync();
        }

        public async Task DeleteSoupAsync(Guid Id)
        {
            var soup = await FindSoupAsync(Id);


            soup.IsDeleted = true;

            await schoolMealsOrderingSystemDbContext.SaveChangesAsync();
        }

        public async Task DeleteMainDishAsync(Guid Id)
        {
            var mainDish = await FindMainDishAsync(Id);


            mainDish.IsDeleted = true;

            await schoolMealsOrderingSystemDbContext.SaveChangesAsync();
        }

        public async Task DeleteDessertAsync(Guid Id)
        {
            var dessert = await FindDessertAsync(Id);


            dessert.IsDeleted = true;

            await schoolMealsOrderingSystemDbContext.SaveChangesAsync();
        }

        
    }
}
