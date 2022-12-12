namespace SchoolMealsOrderingSystem.Core.Services
{
    using Microsoft.EntityFrameworkCore;
    using SchoolMealsOrderingSystem.Core.Contracts;
    using SchoolMealsOrderingSystem.Core.Models.Meal;
    using SchoolMealsOrderingSystem.Data;
    using SchoolMealsOrderingSystem.Data.Entities.Meals;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using static Data.Constants.SchoolUserConstants;
    using static Data.Constants.SoupConstants;
    using static Data.Constants.MainDishConstants;
    using static Data.Constants.DessertConstatnts;

    public class MealServices : IMealServices
    {
        private readonly SchoolMealsOrderingSystemDbContext schoolMealsOrderingSystemDbContext;

        public MealServices(SchoolMealsOrderingSystemDbContext _schoolMealsOrderingSystemDbContext)
        {
            schoolMealsOrderingSystemDbContext = _schoolMealsOrderingSystemDbContext;
        }


        public async Task<IEnumerable<Soup>> GetSoupsAsync()
        {
            var result = await schoolMealsOrderingSystemDbContext
                .Soups
                .ToListAsync();

            return result;
        }

        public async Task<IEnumerable<MainDish>> GetMainDishsAsync()
        {
            var result = await schoolMealsOrderingSystemDbContext
                .MainDishes
                .ToListAsync();

            return result;
        }

        public async Task<IEnumerable<Dessert>> GetDessertsAsync()
        {
            var result = await schoolMealsOrderingSystemDbContext
                .Desserts
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

            user.Soups.Add(await FindSoupAsync(model.FirstSoupId));
            user.Soups.Add(await FindSoupAsync(model.SecondSoupId));
            user.Soups.Add(await FindSoupAsync(model.ThirdSoupId));
            user.MainDishes.Add(await FindMainDishAsync(model.FirstMainDishId));
            user.MainDishes.Add(await FindMainDishAsync(model.SecondMainDishId));
            user.MainDishes.Add(await FindMainDishAsync(model.ThirdMainDishId));
            user.Desserts.Add(await FindDessertAsync(model.FirstDessertsId));
            user.Desserts.Add(await FindDessertAsync(model.SecondDessertsId));
            user.Desserts.Add(await FindDessertAsync(model.ThirdDessertsId));
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
    }
}
