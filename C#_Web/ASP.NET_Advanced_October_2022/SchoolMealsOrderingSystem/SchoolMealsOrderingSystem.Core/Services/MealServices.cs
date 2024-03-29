﻿namespace SchoolMealsOrderingSystem.Core.Services
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
                .Where(s => s.SchoolUserId == schoolUserId && !s.IsDeleted)
                .ToListAsync();

            return result;
        }


        public async Task<IEnumerable<MainDish>> GetMainDishsAsync(string schoolUserId)
        {
            var result = await schoolMealsOrderingSystemDbContext
                .MainDishes
                .Where(m => m.SchoolUserId == schoolUserId && !m.IsDeleted)
                .ToListAsync();

            return result;
        }

        public async Task<IEnumerable<Dessert>> GetDessertsAsync(string schoolUserId)
        {
            var result = await schoolMealsOrderingSystemDbContext
                .Desserts
                .Where(d => d.SchoolUserId == schoolUserId && !d.IsDeleted)
                .ToListAsync();

            return result;
        }
        public async Task<IEnumerable<SoupViewModel>> GetSoupViewModelAsync(string schoolUserId)
        {
            var result = await schoolMealsOrderingSystemDbContext
                .Soups
                .Where(s => s.SchoolUserId == schoolUserId && !s.IsDeleted)
                .Select(s => new SoupViewModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    ImageUrl = s.ImageUrl,
                    Allergens = s.Allergens,
                    Ingredients = s.Ingredients

                })
                .ToListAsync();

            return result;
        }
        public async Task<IEnumerable<MainDishViewModel>> GetMainDishViewModelAsync(string schoolUserId)
        {
            var result = await schoolMealsOrderingSystemDbContext
                .MainDishes
                .Where(m => m.SchoolUserId == schoolUserId && !m.IsDeleted)
                .Select(m => new MainDishViewModel
                {
                    Id = m.Id,
                    Name = m.Name,
                    ImageUrl = m.ImageUrl,
                    Allergens = m.Allergens,
                    Ingredients = m.Ingredients

                })
                .ToListAsync();

            return result;
        }

        public async Task<IEnumerable<DessertViewModel>> GetDessertViewModelAsync(string schoolUserId)
        {
            var result = await schoolMealsOrderingSystemDbContext
                .Desserts
                .Where(d => d.SchoolUserId == schoolUserId && !d.IsDeleted)
                .Select(d => new DessertViewModel
                {
                    Id = d.Id,
                    Name = d.Name,
                    ImageUrl = d.ImageUrl,
                    Allergens = d.Allergens,
                    Ingredients = d.Ingredients

                })
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

            var selectedIdList = new List<Guid>();

            var firstSoup = await FindSoupAsync(model.FirstSoupId);
            firstSoup.IsSelected = true;
            selectedIdList.Add(firstSoup.Id);
            var secondSoup = await FindSoupAsync(model.SecondSoupId);
            secondSoup.IsSelected = true;
            selectedIdList.Add(secondSoup.Id);
            var thirdSoup = await FindSoupAsync(model.ThirdSoupId);
            thirdSoup.IsSelected = true;
            selectedIdList.Add(thirdSoup.Id);
            var firstMainDish = await FindMainDishAsync(model.FirstMainDishId);
            firstMainDish.IsSelected = true;
            selectedIdList.Add(firstMainDish.Id);
            var secondtMainDish = await FindMainDishAsync(model.SecondMainDishId);
            secondtMainDish.IsSelected = true;
            selectedIdList.Add(secondtMainDish.Id);
            var thirdMainDish = await FindMainDishAsync(model.ThirdMainDishId);
            thirdMainDish.IsSelected = true;
            selectedIdList.Add(thirdMainDish.Id);
            var firstDessert = await FindDessertAsync(model.FirstDessertsId);
            firstDessert.IsSelected = true;
            selectedIdList.Add(firstDessert.Id);
            var secondDessert = await FindDessertAsync(model.SecondDessertsId);
            secondDessert.IsSelected = true;
            selectedIdList.Add(secondDessert.Id);
            var thirdDessert = await FindDessertAsync(model.ThirdDessertsId);
            thirdDessert.IsSelected = true;
            selectedIdList.Add(thirdDessert.Id);

            await GetRestOfMealsUnselected(selectedIdList, user.Id);

        }

        public async Task GetRestOfMealsUnselected(List<Guid> selectedIdList, string id)
        {
            var soups = await GetSoupsAsync(id);
            var mainDishes = await GetMainDishsAsync(id);
            var desserts = await GetDessertsAsync(id);

            foreach (var soup in soups)
            {
                if (!selectedIdList.Any(x => x.Equals(soup.Id)))
                {
                    soup.IsSelected = false;
                }
            }

            foreach (var mainDish in mainDishes)
            {
                if (!selectedIdList.Any(x => x.Equals(mainDish.Id)))
                {
                    mainDish.IsSelected = false;
                }
            }

            foreach (var dessert in desserts)
            {
                if (!selectedIdList.Any(x => x.Equals(dessert.Id)))
                {
                    dessert.IsSelected = false;
                }
            }

            await schoolMealsOrderingSystemDbContext.SaveChangesAsync();
        }

        public async Task<MainDish> FindMainDishAsync(Guid Id)
        {
            var result = await schoolMealsOrderingSystemDbContext
                .MainDishes
                .Where(m => m.Id == Id && !m.IsDeleted)
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
                .Where(d => d.Id == Id && !d.IsDeleted)
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
                throw new ArgumentException(InvalidSchoolUserId);
            }

            var soup = new Soup()
            {
                Name = model.Name,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
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
                throw new ArgumentException(InvalidSchoolUserId);
            }

            var mainDish = new MainDish()
            {
                Name = model.Name,
                Description = model.Description,
                Ingredients = model.Ingredients,
                Allergens = model.Allergens,
                ImageUrl = model.ImageUrl,
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
                throw new ArgumentException(InvalidSchoolUserId);
            }

            var dessert = new Dessert()
            {
                Name = model.Name,
                Description = model.Description,
                Ingredients = model.Ingredients,
                ImageUrl = model.ImageUrl,
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

        public async Task<EditSoupViewModel> GetSoupForEditAsync(Guid soupId)
        {
            var soup = await schoolMealsOrderingSystemDbContext
                .Soups
                .Where(s => s.Id.Equals(soupId) && !s.IsDeleted)
                .Select(s => new EditSoupViewModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    Description = s.Description == null ? string.Empty : s.Description,
                    Allergens = s.Allergens,
                    Ingredients = s.Ingredients,
                    ImageUrl = s.ImageUrl,
                })
                .SingleOrDefaultAsync();

            if (soup == null)
            {
                throw new ArgumentException(InvalidSoupId);
            }

            return soup;
        }

        public async Task EditSoupAsync(EditSoupViewModel editSoupViewModel)
        {
            var soup = await schoolMealsOrderingSystemDbContext
                .Soups
                .FindAsync(editSoupViewModel.Id);

            if (soup != null)
            {
                soup.Name= editSoupViewModel.Name;
                soup.Description= editSoupViewModel.Description;
                soup.Allergens= editSoupViewModel.Allergens;
                soup.ImageUrl= editSoupViewModel.ImageUrl;
                soup.Ingredients = editSoupViewModel.Ingredients;
            }

            await schoolMealsOrderingSystemDbContext.SaveChangesAsync();
        }

        public async Task<EditMainDishViewModel> GetMainDishForEditAsync(Guid mainDishId)
        {
            var mainDish = await schoolMealsOrderingSystemDbContext
                .MainDishes
                .Where(m => m.Id.Equals(mainDishId) && !m.IsDeleted)
                .Select(m => new EditMainDishViewModel
                {
                    Id = m.Id,
                    Name = m.Name,
                    Description = m.Description == null ? string.Empty : m.Description,
                    Allergens = m.Allergens,
                    Ingredients = m.Ingredients,
                    ImageUrl = m.ImageUrl,
                })
                .SingleOrDefaultAsync();

            if (mainDish == null)
            {
                throw new ArgumentException(InvalidSoupId);
            }

            return mainDish;
        }

        public async Task EditMainDishAsync(EditMainDishViewModel editMainDishViewModel)
        {
            var soup = await schoolMealsOrderingSystemDbContext
                .MainDishes
                .FindAsync(editMainDishViewModel.Id);

            if (soup != null)
            {
                soup.Name = editMainDishViewModel.Name;
                soup.Description = editMainDishViewModel.Description;
                soup.Allergens = editMainDishViewModel.Allergens;
                soup.ImageUrl = editMainDishViewModel.ImageUrl;
                soup.Ingredients = editMainDishViewModel.Ingredients;
            }

            await schoolMealsOrderingSystemDbContext.SaveChangesAsync();
        }

        public async Task<EditDessertViewModel> GetDessertForEditAsync(Guid dessertId)
        {
            var dessert = await schoolMealsOrderingSystemDbContext
                .Desserts
                .Where(d => d.Id.Equals(dessertId) && !d.IsDeleted)
                .Select(d => new EditDessertViewModel
                {
                    Id = d.Id,
                    Name = d.Name,
                    Description = d.Description == null ? string.Empty : d.Description,
                    Allergens = d.Allergens,
                    Ingredients = d.Ingredients,
                    ImageUrl = d.ImageUrl,
                })
                .SingleOrDefaultAsync();

            if (dessert == null)
            {
                throw new ArgumentException(InvalidSoupId);
            }

            return dessert;
        }

        public async Task EditDessertAsync(EditDessertViewModel editDessertViewModel)
        {
            var dessert = await schoolMealsOrderingSystemDbContext
                .Desserts
                .FindAsync(editDessertViewModel.Id);

            if (dessert != null)
            {   
                dessert.Name = editDessertViewModel.Name;
                dessert.Description = editDessertViewModel.Description;
                dessert.Allergens = editDessertViewModel.Allergens;
                dessert.ImageUrl = editDessertViewModel.ImageUrl;
                dessert.Ingredients = editDessertViewModel.Ingredients;
            }

            await schoolMealsOrderingSystemDbContext.SaveChangesAsync();
        }

    }
}
